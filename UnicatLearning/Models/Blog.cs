using System;
using System.Collections.Generic;

namespace UnicatLearning.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public int UserId { get; set; }

    public string BlogTitler { get; set; } = null!;

    public string? BlogImage { get; set; }

    public string? BlogDescription { get; set; }

    public DateTime PostDate { get; set; }

    public virtual ICollection<BlogFeedback> BlogFeedbacks { get; set; } = new List<BlogFeedback>();

    public virtual User User { get; set; } = null!;
}
