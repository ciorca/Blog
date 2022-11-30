using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Pages.Admin.Blogs
{
    public class ListOfPostModel : PageModel
    {
        private readonly BlogDbContext blogDbContext;
        public List<BlogPost> BlogPosts { get; set; }

        public ListOfPostModel(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }
        public async Task OnGet()
        {
         BlogPosts = await blogDbContext.BlogPosts.ToListAsync();
        }
    }
}
