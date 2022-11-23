using LoanAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoanAPI.Models.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AplicationDbContext _context;

        public CategoriesRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categories>> GetListCategories()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Categories> GetCategory(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task DeleteCategory(Categories category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Categories> CreateCategory(Categories category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task UpdateCategory(Categories category)
        {
            var categoryItem = await _context.Categories.FirstOrDefaultAsync(dbCategories => dbCategories.Id == category.Id);

            if (categoryItem != null)
            {
            categoryItem.Name = category.Name;
            categoryItem.Description = category.Description;

            await _context.SaveChangesAsync();
            }

        }
    }
}
