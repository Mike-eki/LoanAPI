using LoanAPI.Context.IEntity;
using LoanAPI.IRepository;

namespace LoanAPI.Models.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int? id);
        Task<T> Insert(T entity);
        Task Update(T entity);
        Task DeleteById(int id);
    }
}
