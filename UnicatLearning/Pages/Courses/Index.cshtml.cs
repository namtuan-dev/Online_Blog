using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UnicatLearning.Models;

namespace UnicatLearning.Pages.Courses
{
	public class IndexModel : PageModel
	{
		private readonly UnicatOnlineLearningContext _db = new UnicatOnlineLearningContext();
		public List<Models.Course> Courses { get; set; }
		public List<Models.Category> Categories { get; set; }
		public List<Models.Course> Latest3Courses { get; set; }
		public int TotalCourses { get; set; }
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public int TotalPages { get; set; }
		public int CategorySearch { get; set; }
		public string NameSearch { get; set; }

		public void OnGet(int pageno, string name, int cateid)
		{
			//Don't change
			Categories = _db.Categories.ToList();
			Latest3Courses = _db.Courses.OrderByDescending(u => u.CourseId).Take(3).ToList();

			//--------------- Search ------------------------
			CategorySearch = 0;
			NameSearch = "";
			TotalCourses = _db.Courses.ToList().Count;

			if (!name.IsNullOrEmpty())
				NameSearch = name;

			//Category Search and Name Search
			if (cateid >= 0 && cateid <= Categories.Count)
			{
				CategorySearch = cateid;
				if (cateid == 0)
					Courses = _db.Courses.Where(u => u.Name.Contains(NameSearch)).ToList();
				else
					Courses = _db.Courses.Where(u => u.CategoryId == cateid && u.Name.Contains(NameSearch)).ToList();
				TotalCourses = Courses.Count;
			}

			//------------------------- Pagination -----------------------
			PageSize = 4;
			TotalPages = (int)Math.Ceiling(TotalCourses / (double)PageSize);
			if (pageno != 0)
				CurrentPage = pageno;
			else if (pageno <= 0)
				CurrentPage = 1;
			else if (pageno > TotalPages)
				CurrentPage = TotalPages;

			if (cateid >= 0 && cateid <= Categories.Count)
			{
				if (cateid == 0)
					Courses = _db.Courses.Where(u => u.Name.Contains(NameSearch)).Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
				else
					Courses = _db.Courses.Where(u => u.CategoryId == cateid && u.Name.Contains(NameSearch)).Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
			}
			else
				Courses = _db.Courses.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

		}

	}
}
