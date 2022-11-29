using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages.Admin.Blogs
{
    public class AddNameModel : PageModel
    {
        private readonly BlogDbContext blogDbContext;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }
        public AddNameModel(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var blogPost = new BlogPost() 
            {
            Heading=AddBlogPostRequest.Heading,
            PageTitle=AddBlogPostRequest.PageTitle,
            Content=AddBlogPostRequest.Content,
            ShortDescription=AddBlogPostRequest.ShortDescription,
            FeaturedImageUrl=AddBlogPostRequest.FeaturedImageUrl,
            PublishedDate=AddBlogPostRequest.PublishedDate,
            Author=AddBlogPostRequest.Author,
            Visible=AddBlogPostRequest.Visible
            };

            blogDbContext.BlogPosts.Add(blogPost);
            blogDbContext.SaveChanges();
            return RedirectToPage("/Admin/Blogs/ListOfPost");
        }
       

    }
}
