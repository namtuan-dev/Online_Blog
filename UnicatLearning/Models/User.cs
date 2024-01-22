using System;
using System.Collections.Generic;

namespace UnicatLearning.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? PassWord { get; set; }

    public string? FullName { get; set; }

    public string? Image { get; set; }

    public string? Email { get; set; }

    public DateTime Dob { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? FacebookId { get; set; }

    public string? GmailId { get; set; }

    public int RoleId { get; set; }

    public int Status { get; set; }

    public virtual ICollection<BlogComment> BlogComments { get; set; } = new List<BlogComment>();

    public virtual ICollection<BlogFeedback> BlogFeedbacks { get; set; } = new List<BlogFeedback>();

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual UserRole Role { get; set; } = null!;
}
