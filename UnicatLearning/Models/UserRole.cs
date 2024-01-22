using System;
using System.Collections.Generic;

namespace UnicatLearning.Models;

public partial class UserRole
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
