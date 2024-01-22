using System;
using System.Collections.Generic;

namespace UnicatLearning.Models;

public partial class Quiz
{
    public int QuizId { get; set; }

    public int LessonId { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
