using System;
using System.Collections.Generic;

namespace UnicatLearning.Models;

public partial class CourseEnroll
{
    public int CourseEnrollId { get; set; }

    public int UserId { get; set; }

    public int CourseId { get; set; }

    public DateTime EnrollDate { get; set; }

    public int LessonCurrent { get; set; }

    public int CourseStatus { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
