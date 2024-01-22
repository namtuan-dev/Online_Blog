using System;
using System.Collections.Generic;

namespace UnicatLearning.Models;

public partial class ReviewComment
{
    public int ReviewCommentId { get; set; }

    public int ReviewFeedbackId { get; set; }

    public int ReviewId { get; set; }

    public string ReviewCommentContent { get; set; } = null!;

    public DateTime ReviewCommentDate { get; set; }

    public virtual Review Review { get; set; } = null!;

    public virtual ReviewFeedback ReviewFeedback { get; set; } = null!;
}
