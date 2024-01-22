using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.Json;
using UnicatLearning.Models;

namespace UnicatLearning.Pages.Blog
{
    public class IndexModel : PageModel
    {
        private readonly UnicatOnlineLearningContext _db = new UnicatOnlineLearningContext();
        public Models.Blog Blog { get; set; }
        public string MonthString { get; set; }
        public List<Category> Categories { get; set; }
        public User user { get; set; }

        public void OnGet(int id)
        {
            CultureInfo cultureInfo = new CultureInfo("en-US"); // Đặt culture tùy ý
            Categories = _db.Categories.ToList();
            string json = HttpContext.Session.GetString("user");
            if (json != null)
                user = JsonSerializer.Deserialize<User>(json);
            if (id > 0 && id <= _db.Blogs.OrderByDescending(u => u.BlogId).First().BlogId
                && _db.Blogs.Where(u => u.BlogId == id).FirstOrDefault() != null)
            {
                Blog = _db.Blogs.Include(u => u.User).Where(u => u.BlogId == id).FirstOrDefault();
            }
            else
                Blog = _db.Blogs.Include(u => u.User).First();
            MonthString = cultureInfo.DateTimeFormat.GetMonthName(Blog.PostDate.Month);
        }
    }
}
