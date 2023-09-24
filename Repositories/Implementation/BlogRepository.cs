using Blog.API.Data;
using Blog.API.DTO;
using Blog.API.Models;
using Blog.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Repositories.Implementation {
	public class BlogRepository : IBlogRepository {

		private readonly ApplicationDbContext dbContext;

		public BlogRepository(ApplicationDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
        public async Task<List<GetBlogDto>> GetBlog() {

			var blogs = BlogDataToGetBlogDtoConverter( await dbContext.BlogPosts.ToListAsync() ) ;
			return blogs;
		}

		public async Task<bool> PostBlog(CreateBlogDto blogData) {

			BlogPost blog = new BlogPost() {
				Title = blogData.Title.Trim(),
				ShortDescription = blogData.ShortDescription.Trim(),
				Content = blogData.Content.Trim(),
				FeaturedImageUrl = blogData.FeaturedImageUrl.Trim(),
				UrlHandle = blogData.Title.Trim().Replace(" ","-"),
				PublishedDate = blogData.PublishedDate,
				Author = blogData.Author.Trim(),
				IsVisible = blogData.IsVisible,
			};

			try {

				var data = await dbContext.BlogPosts.AddAsync(blog);
				await dbContext.SaveChangesAsync();
				return true;
			} catch (Exception ex) {
				return false;
			}
		}
		public async Task<bool> DeleteBlog(Guid id) {
			try {
				var blogToDelete = await dbContext.BlogPosts.FirstOrDefaultAsync(b => b.Id == id);

				if(blogToDelete != null) {

					dbContext.BlogPosts.Remove(blogToDelete);
					await dbContext.SaveChangesAsync();
					return true;

				} else {
					return false;
				}
			}catch (Exception ex) {
				return false;
			}
		}
		// ______________________ Converter Functions _______________________________

		private List<GetBlogDto> BlogDataToGetBlogDtoConverter(List<BlogPost> blogs) {
			List<GetBlogDto> response = new List<GetBlogDto>();

			foreach (var blog in blogs)
            {
				response.Add(new GetBlogDto {
					Id = blog.Id,
					Title = blog.Title,
					Author = blog.Author,
					ShortDescription = blog.ShortDescription,
					Content = blog.Content,
					FeaturedImageUrl = blog.FeaturedImageUrl,
					PublishedDate = blog.PublishedDate,
					UrlHandle = blog.UrlHandle,
					IsVisible = blog.IsVisible,
				});
            }

			return response;
        }

	}
}
