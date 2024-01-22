using System;
using System.Collections.Generic;

namespace UnicatLearning.Models;

public partial class Lesson
{
    public int LessonId { get; set; }

    public int CourseId { get; set; }

    public string? Name { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<LessonDetail> LessonDetails { get; set; } = new List<LessonDetail>();

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
