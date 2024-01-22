using System;
using System.Collections.Generic;

namespace UnicatLearning.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string Content { get; set; } = null!;

    public int CorrectAnswer { get; set; }

    public int QuizId { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Quiz Quiz { get; set; } = null!;
}
