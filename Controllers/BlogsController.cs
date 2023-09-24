using Blog.API.DTO;
using Blog.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class BlogsController : ControllerBase {

		private readonly IBlogRepository blogRepository;

		public BlogsController(IBlogRepository blogRepository)
        {
			this.blogRepository = blogRepository;
		}

		[HttpGet("/get")]
		public async Task<IActionResult> GetBlogs() {

			var response = await blogRepository.GetBlog();

			return Ok(response);
		}

		[HttpPost("/post")]
		public async Task<IActionResult> PostBlog(CreateBlogDto blogData) {

			var response = await blogRepository.PostBlog(blogData);

			return Ok(response);
		}

		[HttpDelete("/remove/{id}")]
		public async Task<IActionResult> DeleteBlog(Guid id) {

			var response = await blogRepository.DeleteBlog(id);

			return Ok(response);
		}
    }
}
