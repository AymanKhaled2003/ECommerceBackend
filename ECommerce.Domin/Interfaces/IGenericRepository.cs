
using ECommerce.Domain.Primitives;
using ECommerce.Domain.Specification;
using System.Linq.Expressions;

namespace ECommerce.Domain.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : ValueObject
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(List<TEntity> entities, CancellationToken cancellationToken = default);
    Task<bool> IsExist(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
    (IQueryable<TEntity> data, int count) GetWithSpec(Specification<TEntity> specification);
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    IReadOnlyList<TEntity> Get();
    Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    TEntity? GetEntityWithSpec(Specification<TEntity> specification);
    void Update(TEntity entity);
    IQueryable<TEntity> GetAllAsIQueryable(
        Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
          string IncludeProperties = null);
    void UpdateRange(IEnumerable<TEntity> entities);

    void Delete(TEntity entity);
    void DeleteRange(IEnumerable<TEntity> entity);
    Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
    void ExecuteUpdateRange(Expression<Func<TEntity, bool>> filter, Expression<Func<Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<TEntity>, Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<TEntity>>> expression);
  
}
