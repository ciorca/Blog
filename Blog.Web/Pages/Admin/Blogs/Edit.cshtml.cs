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
        public async Task OnGet(Guid id)
        {
          BlogPost= await blogDbContext.BlogPosts.FindAsync(id);
           
        }

        public async Task<IActionResult> OnPostEdit()
        {
         var existingBlogPost = await blogDbContext.BlogPosts.FindAsync(BlogPost.Id);
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
           await blogDbContext.SaveChangesAsync();
            return RedirectToPage("/Admin/Blogs/ListOfPost");
        }

        public async Task< IActionResult> OnPostDelete()
        {
            var existingBlog= await blogDbContext.BlogPosts.FindAsync(BlogPost.Id);
            if(existingBlog != null)
            {
                blogDbContext.BlogPosts.Remove(existingBlog);
               await blogDbContext.SaveChangesAsync();
                return RedirectToPage("/Admin/Blogs/ListOfPost");

            }
            return Page();
        }
    }

}
