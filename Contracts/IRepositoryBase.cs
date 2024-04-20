using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool TrackChanges);

        IQueryable<T> FindByCondition(Expression<Func<T ,bool>> exp, bool TrackChanges);

        void Create(T entity);

        void Delete(T entity);

        void Update(T entity);

    }
}
