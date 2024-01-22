using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using UnicatLearning.Models;

namespace UnicatLearning.Pages.Register
{
    public class IndexModel : PageModel
    {
        private readonly UnicatOnlineLearningContext _db = new UnicatOnlineLearningContext();

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string FullName { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public DateTime Dob { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public string RepeatPassword { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Models.User newUser = new Models.User();
            if (_db.Users.Where(u => u.UserName == UserName).FirstOrDefault() != null)
                ModelState.AddModelError("UserName", "UserName has been used");
            if (Dob.Year < 1900 || Dob.Year > DateTime.Now.Year)
                ModelState.AddModelError("Dob", "Invalid Date of Birth");
            if (Password != RepeatPassword)
                ModelState.AddModelError("RepeatPassword", "Repeat password must be the same with password");
            if (!Phone.IsNullOrEmpty() && Phone.Length != 10)
                ModelState.AddModelError("Phone", "Invalid Phone number (Ex: 0911017958)");

            if (!UserName.IsNullOrEmpty() && !FullName.IsNullOrEmpty() && !Email.IsNullOrEmpty()
                 && !Password.IsNullOrEmpty() && !Phone.IsNullOrEmpty() && !Address.IsNullOrEmpty()
                 && _db.Users.Where(u => u.UserName == UserName).FirstOrDefault() == null
                 && (Dob.Year >= 1900 && Dob.Year <= DateTime.Now.Year)
                 && (Password == RepeatPassword)
                 && Phone.Length == 10)
            {
                newUser.UserName = UserName;
                newUser.FullName = FullName;
                newUser.Email = Email;
                newUser.Phone = Phone;
                newUser.Dob = Dob;
                newUser.Address = Address;
                newUser.PassWord = Password;
                newUser.RoleId = 3;
                newUser.Status = 1;
                _db.Users.Add(newUser);
                _db.SaveChanges();
                return RedirectToPage("/Login/index");
            }
            else
            {
                return Page();
            }

        }
    }
}
