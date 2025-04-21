using ECommerce.Domain.Primitives;
using ECommerce.Domain.Interfaces;

namespace ECommerce.Domain.Interfaces;

public interface IUnitOfWork
{
    Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : ValueObject;
}
