using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kojh.DAL.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken, bool includeArchived = false);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken, bool includeArchived = false);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entities, CancellationToken cancellationToken);
        Task<TEntity?> RemoveAsync(Guid id, CancellationToken cancellationToken);
        Task<List<TEntity>> RemoveRangeAsync(List<TEntity> entities, CancellationToken cancellationToken);
        Task<TEntity?> ArchiveAsync(Guid id, CancellationToken cancellationToken);
        Task<TEntity?> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities, CancellationToken cancellationToken);
    }
    
}
