using LoanAPI.Models.Entities;

namespace LoanAPI.Models.Repositories
{
    public interface ICategoriesRepository
    {
        Task<List<Categories>> GetListCategories();
        Task<Categories> GetCategory(int id);
        Task DeleteCategory(Categories category);
        Task<Categories> CreateCategory(Categories category);
        Task UpdateCategory(Categories category);
    }
}
