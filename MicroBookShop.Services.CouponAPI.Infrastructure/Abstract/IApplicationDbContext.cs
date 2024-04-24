using MicroBookShop.Services.CouponAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MicroBookShop.Services.CouponAPI.Infrastructure.Abstract;

public interface IApplicationDbContext
{
    DbSet<Coupon> Coupons { get; set; }

    ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(
           TEntity entity,
           CancellationToken cancellationToken = default)
           where TEntity : class;

    EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
    where TEntity : class;

    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken ct = default);

    EntityEntry<TEntity> Update<TEntity>(TEntity entity)
            where TEntity : class;

    DatabaseFacade Database { get; }

    void Dispose();
}
