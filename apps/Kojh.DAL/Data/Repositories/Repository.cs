using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kojh.DAL.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kojh.DAL.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class,IEntity
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken, bool includeArchived = false)
        {
            var found = await _dbContext.Set<TEntity>().FindAsync(new object?[] { id }, cancellationToken);
            if (found is null || (!includeArchived && found.Archived)) return null;

            return found;
        }

        public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken, bool includeArchived = false)
        {
            return !includeArchived
              ? await _dbContext.Set<TEntity>().Where(x => x.Archived == false).Where(predicate).ToListAsync(cancellationToken)
              : await _dbContext.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

            return await Task.FromResult(entity);
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities, CancellationToken cancellationToken)
        {
            List<TEntity> addedEntities = [];
            foreach (var entity in entities)
            {
                entity.Id = Guid.NewGuid();
                addedEntities.Add(entity);
            }

            await _dbContext.Set<TEntity>().AddRangeAsync(addedEntities, cancellationToken);

            return addedEntities;
        }

        public async Task<TEntity?> RemoveAsync(Guid id, CancellationToken cancellationToken)
        {
            var removed = await _dbContext.Set<TEntity>()
              .FindAsync(new object?[] { id, cancellationToken }, cancellationToken);
            if (removed is null) return null;

            _dbContext.Set<TEntity>().Remove(removed);

            return await Task.FromResult(removed);
        }

        public async Task<List<TEntity>> RemoveRangeAsync(List<TEntity> entities, CancellationToken cancellationToken)
        {
            List<TEntity> removedEntities = [];
            foreach (var entity in entities)
            {
                var removed = await RemoveAsync(entity.Id, cancellationToken);

                if (removed is not null) removedEntities.Add(entity);
            }

            return removedEntities;
        }
        public async Task<TEntity?> ArchiveAsync(Guid id, CancellationToken cancellationToken)
        {
            var archived = await _dbContext.Set<TEntity>()
              .FindAsync(new object?[] { id, cancellationToken }, cancellationToken);
            if (archived is null) return null;

            archived.ArchivedAt = DateTime.UtcNow;
            archived.Archived = true;

            _dbContext.Set<TEntity>().Update(archived);

            return await Task.FromResult(archived);
        }
        public async Task<TEntity?> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
            entity.UpdatedAt = DateTime.UtcNow;

            _dbContext.Set<TEntity>().Update(entity);

            return await Task.FromResult(entity);
        }

        public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities, CancellationToken cancellationToken)
        {
            List<TEntity> updatedEntities = [];
            foreach (var entity in entities)
            {
                var updated = await UpdateAsync(entity, cancellationToken);

                if (updated is not null) updatedEntities.Add(entity);
            }

            return updatedEntities;
        }

        public async Task<List<TEntity>> ArchiveRangeAsync(List<TEntity> entities, CancellationToken cancellationToken)
        {
            foreach (var entity in entities)
            {
                entity.ArchivedAt = DateTime.UtcNow;
                entity.Archived = true;
            }

            return await UpdateRangeAsync(entities, cancellationToken);
        }
    }
}
