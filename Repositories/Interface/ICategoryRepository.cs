using Blog.API.Models;

namespace Blog.API.Repositories.Interface {
	public interface ICategoryRepository {

		public Task<List<Category>> GetCategories();
		public Task<Category> CreateAsync(Category category); 

		public Task<bool> DeleteCategory(Guid id);
	}
}
