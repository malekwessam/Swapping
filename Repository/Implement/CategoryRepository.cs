using Microsoft.EntityFrameworkCore;
using MoqaydaGP.Data;
using MoqaydaGP.Entities;
using MoqaydaGP.Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Implement
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MoqaydaDbContext DbContext;
        public CategoryRepository(MoqaydaDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            DbContext.Category.Add(category);
            await DbContext.SaveChangesAsync();
            return category;
        }
        public async Task<bool> DeleteCategoryAsync(short categoryId)
        {
            // this will return entity and that is tracked
            var categoryToRemove = await DbContext.Category.FindAsync(categoryId);
            DbContext.Category.Remove(categoryToRemove);
            return await DbContext.SaveChangesAsync() > 0;
        }

        public Task<Category> GetCategoryAndProductsAsync(short categoryId)
        {
            return DbContext.Category.AsNoTracking().Include(i => i.Product).FirstOrDefaultAsync(f => f.Id == categoryId);
        }

        public Task<Category> GetCategoryAsync(short categoryId)
        {
            return this.DbContext.Category.FindAsync(categoryId).AsTask();
        }

        public Task<Category> GetCategoryAsync(string name)
        {
            return this.DbContext.Category.FirstOrDefaultAsync(f => f.CategoryName.ToLower() == name.ToLower());
        }
        public Task<List<Category>> GetCategorysAsync()
        {
            return this.DbContext.Category.ToListAsync();
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            DbContext.Category.Update(category);
            await DbContext.SaveChangesAsync();
            return category;
        }
    }
}
