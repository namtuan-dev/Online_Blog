using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnicatLearning.Models;

namespace UnicatLearning.Pages.Blog
{
    public class DeleteModel : PageModel
    {

        private readonly UnicatOnlineLearningContext _db = new UnicatOnlineLearningContext();

        public IActionResult OnPost(int id)
        {
            Models.Blog blog = new Models.Blog();
            blog = _db.Blogs.Where(u => u.BlogId == id).FirstOrDefault();
            if (blog != null)
            {
                _db.Blogs.Remove(blog);
                _db.SaveChanges();
                return RedirectToPage("/Blogs/index");
            } else
            {
                return RedirectToPage("/indedx");
            }
        }
    }
}
