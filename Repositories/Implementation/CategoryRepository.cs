using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Repositories.Implementation {
	public class CategoryRepository : ICategoryRepository {

		private readonly ApplicationDbContext _context;

		public CategoryRepository(ApplicationDbContext context) {
			_context = context;
		}

		public async Task<List<Category>> GetCategories() {
			var categoryList = await _context.Categories.ToListAsync();
			return categoryList;
		}

		public async Task<Category> CreateAsync(Category category) {

			 _context.Categories.Add(category);
			await _context.SaveChangesAsync();

			return category;
		}

		public async Task<bool> DeleteCategory(Guid id) {
			var categoryToDelete = await  _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
			if (categoryToDelete != null) {
				_context.Categories.Remove(categoryToDelete);
				await _context.SaveChangesAsync();
				return true;
			} else {
				return false;
			}
		}

	}
}
