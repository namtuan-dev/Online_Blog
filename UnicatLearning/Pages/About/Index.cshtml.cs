using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnicatLearning.Pages.About
{
    public class IndexModel : PageModel
    {

        public string? pageActive { get; set; }

        public void OnGet()
        {
            pageActive = "About";
        }
    }
}
