using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using UnicatLearning.Models;

namespace UnicatLearning.Pages.Blog
{
    public class EditModel : PageModel
    {
        private readonly UnicatOnlineLearningContext _db = new UnicatOnlineLearningContext();
        public Models.Blog Blog { get; set; }

        public void OnGet(int id)
        {
            Blog = _db.Blogs.Where(u => u.BlogId == id).FirstOrDefault();
        }

        public IActionResult OnPost(int Blogid, string Blogdescription, string Blogtitler, string Blogimage)
        {
            Blog = _db.Blogs.Where(u => u.BlogId == Blogid).FirstOrDefault();

            if (!Blog.BlogTitler.IsNullOrEmpty() && !Blog.BlogDescription.IsNullOrEmpty()
                && !Blog.BlogImage.IsNullOrEmpty())
            {
                Blog.BlogTitler = Blogtitler;
                Blog.BlogDescription = Blogdescription;
                Blog.BlogImage = Blogimage;
                Blog.PostDate = DateTime.Now;
                Blog.UserId = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user")).UserId;
                _db.Blogs.Update(Blog);
                _db.SaveChanges();
                return RedirectToPage("/Blogs/index");
            }
            else
                return Page();
        }
    }
}
