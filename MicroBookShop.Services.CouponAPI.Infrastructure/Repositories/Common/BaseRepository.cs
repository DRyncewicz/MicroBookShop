﻿using MicroBookShop.Services.CouponAPI.Application.Abstract.Repositories;
using MicroBookShop.Services.CouponAPI.Infrastructure.Abstract;
using MicroBookShop.Services.CouponAPI.Infrastructure.Context;

namespace MicroBookShop.Services.CouponAPI.Infrastructure.Repositories.Common;

public class BaseRepository(ApplicationDbContext _dbContext) : IBaseRepository
{
    private readonly ApplicationDbContext _dbContext = _dbContext;

    public async Task AddAsync<TEntity>(TEntity entity, CancellationToken ct = default) where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));
        
        await _dbContext.AddAsync(entity, ct);
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        _dbContext.Remove(entity);
    }

    public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        => _dbContext.Set<TEntity>();

    public async Task<int> SaveAsync(CancellationToken ct = default)
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Update<TEntity>(TEntity entity) where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        _dbContext.Update(entity);
    }
}
