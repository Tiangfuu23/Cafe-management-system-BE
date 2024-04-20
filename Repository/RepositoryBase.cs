using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        private readonly RepositoryContext repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll(bool TrackChanges)
        {
            return TrackChanges ? repositoryContext.Set<T>() : repositoryContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> exp, bool TrackChanges)
        {
            return TrackChanges ? repositoryContext.Set<T>().Where(exp) : repositoryContext.Set<T>().Where(exp).AsNoTracking();
        }


        public void Create(T entity)
        {
            repositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            repositoryContext.Set<T>().Remove(entity);

        }


        public void Update(T entity)
        {
            repositoryContext.Set<T>().Update(entity);

        }
    }
}
