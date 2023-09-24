using Blog.API.Data;
using Blog.API.DTO;
using Blog.API.Models;
using Blog.API.Repositories.Implementation;
using Blog.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase {

		private readonly ICategoryRepository _categoryRepository;

		public CategoriesController(ICategoryRepository categoryRepository)
        {
			_categoryRepository = categoryRepository;
		}

		[HttpGet("/getcategory")]
		public async Task<IActionResult> GetCategories() {
			return Ok( await _categoryRepository.GetCategories());
		}

        [HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto request) {
			Category category = new Category {
				Name = request.Name.Trim(),
				UrlHandle = "genre-" + request.Name.Trim().Replace(" ", "-")
			};
			await _categoryRepository.CreateAsync(category);

			var response = new CategoryDto {
				Id = category.Id,
				Name = category.Name,
				UrlHandle = category.UrlHandle,
			};

			return Ok(response);
		}

		[HttpDelete("/removecategory/{id}")]
		public async Task<IActionResult> RemoveCategory(Guid id) {
			var response = await _categoryRepository.DeleteCategory(id);
			if (response) {
				return Ok(response);
			} else {
				return NotFound(response);
			}
		}
	}
}
