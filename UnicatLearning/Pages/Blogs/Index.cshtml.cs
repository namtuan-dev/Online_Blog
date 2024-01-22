using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UnicatLearning.Models;

namespace UnicatLearning.Pages.Blogs
{
    public class IndexModel : PageModel
    {
        private readonly UnicatOnlineLearningContext _db = new UnicatOnlineLearningContext();

        public List<Models.Blog>? Blogs { get; set; }
		public int TotalBlogs { get; set; }
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public int TotalPages { get; set; }

		public void OnGet(int pageno)
        {
			TotalBlogs = _db.Blogs.ToList().Count;
            PageSize = 6;
            TotalPages = (int)Math.Ceiling(TotalBlogs / (double)PageSize);

			if (pageno != 0)
				CurrentPage = pageno;
			else if (pageno <= 0)
				CurrentPage = 1;
			else if (pageno > TotalPages)
				CurrentPage = TotalPages;

			Blogs = _db.Blogs.Include(x => x.User).OrderByDescending(p => p.BlogId).Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();


		}
	}
}
