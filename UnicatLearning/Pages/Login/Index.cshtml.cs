using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using UnicatLearning.Models;

namespace UnicatLearning.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly UnicatOnlineLearningContext _db = new UnicatOnlineLearningContext();

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                HttpContext.Session.Remove("user");
            }
        }

        public IActionResult OnPost()
        {
            Models.User user = new Models.User();
            user = _db.Users.Where(u => u.UserName == UserName && u.PassWord == Password).FirstOrDefault();
            if (user != null)
            {
                string jsonString = JsonSerializer.Serialize(user);
                HttpContext.Session.SetString("user", jsonString);
                return RedirectToPage("/index");
            }
            else
            {
                ModelState.AddModelError("Password", "User is not founded");
                return Page();
            }
        }
    }
}
