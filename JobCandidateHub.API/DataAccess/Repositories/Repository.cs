using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobCandidateHub.API.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }
        public async Task<TEntity> GetByIDAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? pageNumber = default, int? pageSize = default, bool enableNoTracking = true, bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = enableNoTracking ? DbSet.AsNoTracking() : DbSet;

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var propertiesToInclude = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var includeProperty in propertiesToInclude)
            {
                query = query.Include(includeProperty.Trim());
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (pageNumber != null && pageSize != null)
            {
                var skip = ((int)pageNumber - 1) * (int)pageSize;
                query = query.Skip(skip).Take((int)pageSize);
            }
            return query;
        }
        public async Task InsertAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? pageNumber = null, int? pageSize = null, bool enableNoTracking = true, bool ignoreQueryFilters = false)
        {
            return await Get(filter, orderBy, includeProperties, pageNumber, pageSize, enableNoTracking, ignoreQueryFilters).ToListAsync();
        }

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
            {
                return await query.Where(filter).CountAsync();
            }
            else
            {
                return await query.CountAsync();
            }
        }

        public void Update(TEntity entityToUpdate, string propertiesModified = "", string collectionPropertiesModified = "", string referencePropertiesModified = "", string collectionPropertiesNotModified = "", string referencePropertiesNotModified = "")
        {
            var entity = Context.Entry(entityToUpdate);
            entity.State = EntityState.Modified;
            foreach (var property in propertiesModified.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Context.Entry(entityToUpdate).Property(property.Trim()).IsModified = true;
            }
        }
    }
}
