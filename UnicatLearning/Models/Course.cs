using System;
using System.Collections.Generic;

namespace UnicatLearning.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Image { get; set; } = null!;

    public int UserId { get; set; }

    public string CourseInfo { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int PublishStatus { get; set; }

    public string Request { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual User User { get; set; } = null!;
}
