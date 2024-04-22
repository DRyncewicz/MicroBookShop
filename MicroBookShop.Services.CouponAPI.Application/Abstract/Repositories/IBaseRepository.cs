namespace MicroBookShop.Services.CouponAPI.Application.Abstract.Repositories;

public interface IBaseRepository
{
    /// <summary>
    /// This method can only be used in a repository dedicated to a specific entity.
    /// </summary>
    /// <typeparam name="TEntity">Database entity.</typeparam>
    /// <returns>IQueryble with a list of entities from the database.</returns>
    IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;

    Task AddAsync<TEntity>(TEntity entity, CancellationToken ct = default) where TEntity : class;

    void Update<TEntity>(TEntity entity) where TEntity : class;

    void Delete<TEntity>(TEntity entity) where TEntity : class;

    Task<int> SaveAsync(CancellationToken ct = default);
}