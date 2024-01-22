using System;
using System.Collections.Generic;

namespace UnicatLearning.Models;

public partial class LessonDetail
{
    public int LessonDetailsId { get; set; }

    public int LessonId { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public string? Video { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;
}
