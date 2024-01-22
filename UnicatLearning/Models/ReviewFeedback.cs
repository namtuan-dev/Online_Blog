using System;
using System.Collections.Generic;

namespace UnicatLearning.Models;

public partial class ReviewFeedback
{
    public int ReviewFeedbackId { get; set; }

    public int ReviewId { get; set; }

    public string ReviewFeedbackContent { get; set; } = null!;

    public DateTime ReviewFeedbackDate { get; set; }

    public virtual Review Review { get; set; } = null!;

    public virtual ICollection<ReviewComment> ReviewComments { get; set; } = new List<ReviewComment>();
}
