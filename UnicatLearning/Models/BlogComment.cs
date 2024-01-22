using System;
using System.Collections.Generic;

namespace UnicatLearning.Models;

public partial class BlogComment
{
    public int BlogCommentId { get; set; }

    public int BlogFeedbackId { get; set; }

    public int UserId { get; set; }

    public string BlogCommentContent { get; set; } = null!;

    public DateTime BlogCommentDate { get; set; }

    public virtual BlogFeedback BlogFeedback { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
