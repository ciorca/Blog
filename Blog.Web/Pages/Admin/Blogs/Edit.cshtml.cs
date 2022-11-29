using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly BlogDbContext blogDbContext;

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        public EditModel(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }
        public void OnGet(Guid id)
        {
          BlogPost= blogDbContext.BlogPosts.Find(id);
           
        }

        public IActionResult OnPost()
        {
         var existingBlogPost = blogDbContext.BlogPosts.Find(BlogPost.Id);
            if(existingBlogPost != null)
            {
                existingBlogPost.Heading = BlogPost.Heading;
                existingBlogPost.PageTitle = BlogPost.PageTitle;
                existingBlogPost.Content = BlogPost.Content;
                existingBlogPost.ShortDescription = BlogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
                existingBlogPost.PublishedDate = BlogPost.PublishedDate;
                existingBlogPost.Author = BlogPost.Author;
                existingBlogPost.Visible = BlogPost.Visible;

            }
            blogDbContext.SaveChanges();
            return RedirectToPage("/Admin/Blogs/ListOfPost");
        }
    }
}
