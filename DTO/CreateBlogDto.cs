namespace Blog.API.DTO {
	public class CreateBlogDto {
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string Content { get; set; }
		public string? FeaturedImageUrl { get; set; } = "";
		public string? UrlHandle { get; set; }
		public DateTime PublishedDate { get; set; } = DateTime.Now;
		public string Author { get; set; }
		public bool IsVisible { get; set; } = true;
	}
}
