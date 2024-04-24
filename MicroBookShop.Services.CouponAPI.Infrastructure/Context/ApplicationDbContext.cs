using MicroBookShop.Services.CouponAPI.Application.Abstract.Services;
using MicroBookShop.Services.CouponAPI.Domain.Entities;
using MicroBookShop.Services.CouponAPI.Domain.Entities.Common;
using MicroBookShop.Services.CouponAPI.Infrastructure.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MicroBookShop.Services.CouponAPI.Infrastructure.Context;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options)
: base(options)
    {
    }

    public ApplicationDbContext(DbContextOptions options, IDateTimeService dateTime, ICurrentUserService userService) : base(options)
    {
        _dateTime = dateTime;
        _UserService = userService;
    }

    private readonly IDateTimeService _dateTime;

    private readonly ICurrentUserService _UserService;

    public DbSet<Coupon> Coupons { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _UserService.UserId;
                    entry.Entity.CreateAt = _dateTime.Now;
                    entry.Entity.StatusId = 1;
                    break;
                case EntityState.Modified:
                    entry.Entity.EditedBy = _UserService.UserId;
                    entry.Entity.EditedAt = _dateTime.Now;
                    break;
                case EntityState.Deleted:
                    entry.Entity.EditedBy = _UserService.UserId;
                    entry.Entity.EditedAt = _dateTime.Now;
                    entry.Entity.DeletedAt = _dateTime.Now;
                    entry.Entity.DeletedBy = _UserService.UserId;
                    entry.Entity.StatusId = 0;
                    entry.State = EntityState.Modified;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
