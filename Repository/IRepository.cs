using System.Linq.Expressions;

namespace Repository
{
    public interface IRepository<T> where T : class
    {
        T Create(T t);
        Task SaveChangesAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}