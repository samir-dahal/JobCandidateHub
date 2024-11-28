using System.Linq.Expressions;

namespace JobCandidateHub.API.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIDAsync(int id);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? pageNumber = default, int? pageSize = default, bool enableNoTracking = true, bool ignoreQueryFilters = false);
        Task InsertAsync(TEntity entity);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? pageNumber = default, int? pageSize = default, bool enableNoTracking = true, bool ignoreQueryFilters = false);
        void Update(TEntity entityToUpdate, string propertiesModified = "", string collectionPropertiesModified = "", string referencePropertiesModified = "", string collectionPropertiesNotModified = "", string referencePropertiesNotModified = "");
    }
}
