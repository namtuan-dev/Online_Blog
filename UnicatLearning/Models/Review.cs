using System;
using System.Collections.Generic;

namespace UnicatLearning.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int UserId { get; set; }

    public int CourseId { get; set; }

    public double Vote { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<ReviewComment> ReviewComments { get; set; } = new List<ReviewComment>();

    public virtual ICollection<ReviewFeedback> ReviewFeedbacks { get; set; } = new List<ReviewFeedback>();

    public virtual User User { get; set; } = null!;
}
