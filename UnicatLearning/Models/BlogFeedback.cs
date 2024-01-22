using System;
using System.Collections.Generic;

namespace UnicatLearning.Models;

public partial class BlogFeedback
{
    public int BlogFeedbackId { get; set; }

    public int BlogId { get; set; }

    public int UserId { get; set; }

    public string BlogFeedbackContent { get; set; } = null!;

    public DateTime BlogFeedbackDate { get; set; }

    public virtual Blog Blog { get; set; } = null!;

    public virtual ICollection<BlogComment> BlogComments { get; set; } = new List<BlogComment>();

    public virtual User User { get; set; } = null!;
}
