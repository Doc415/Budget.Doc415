using Budget.Doc415.Data;
using Budget.Doc415.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Budget.Doc415.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BudgetDb _context;
        public CategoryRepository(BudgetDb context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                var categories = await _context.Categories.ToListAsync();
                return categories;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Database exception: {ex}");
                return await Task.FromResult(new List<Category>());
            }
        }

        public async Task<SelectList> GetCategories()
        {
            var categoryList = new SelectList(await _context.Categories.Select(x => x.Name).Distinct().ToListAsync());
            return categoryList;
        }

        public async Task DeleteCategory(int id)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(x => x.Id == id);
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Database exception: {ex}");
            }
        }

        public async Task InsertCategory(Category category)
        {
            try
            {
                var newCategory = new Category()
                {
                    Name = category.Name,
                };
                await _context.AddAsync(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Database exception: {ex}");
            }
        }

        public async Task UpdateCategory(int id, Category category)
        {
            try
            {
                var toUpdate = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                toUpdate.Name = category.Name;
                _context.Update(toUpdate);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Database exception: {ex}");
            }
        }
    }
}
