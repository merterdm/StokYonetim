using StokYonetim.Entites;
using System.Linq.Expressions;

namespace StokYonetim.DAL.Abstract
{
    public interface IRepositoryBase<T> where T : BaseEntity, new()
    {
        Task<int> CreateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> UpdateAsync(T entity);

        Task<T> GetByIdAsync(int id);

        Task<T> GetByAsync(Expression<Func<T, bool>> filter);

        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);

        Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>> filter = null
            , params Expression<Func<T, object>>[] input);
    }
}
