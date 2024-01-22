using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using UnicatLearning.Models;

namespace UnicatLearning.Pages.Blog
{
    public class CreateModel : PageModel
    {
        private readonly UnicatOnlineLearningContext _db = new UnicatOnlineLearningContext();

        [BindProperty]
        public string Titler { get; set; }
        [BindProperty]
        public string Image { get; set; }
        [BindProperty]
        public string Description { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("user") == null)
                return RedirectToPage("/index");
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            Models.Blog blog = new Models.Blog();
            if (!Titler.IsNullOrEmpty() && !Image.IsNullOrEmpty() && !Description.IsNullOrEmpty())
            {
                User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
                blog.BlogTitler = Titler;
                blog.BlogImage = Image;
                blog.BlogDescription = Description;
                blog.PostDate = DateTime.Now;
                blog.UserId = user.UserId;
                _db.Blogs.Add(blog);
                _db.SaveChanges();
                return RedirectToPage("/Blogs/index");
            }
            return Page();
        }
    }
}
