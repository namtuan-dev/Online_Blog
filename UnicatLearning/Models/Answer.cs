using System;
using System.Collections.Generic;

namespace UnicatLearning.Models;

public partial class Answer
{
    public int AnswerId { get; set; }

    public int QuestionId { get; set; }

    public string Answer1 { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
