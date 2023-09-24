using Blog.API.DTO;

namespace Blog.API.Repositories.Interface {
	public interface IBlogRepository {

		public Task<List<GetBlogDto>> GetBlog();
		public Task<bool> PostBlog(CreateBlogDto blog);
		public Task<bool> DeleteBlog(Guid id);
	}
}
