using System;
using System.Collections.Generic;

namespace MyPlanner.Models;

public partial class Todo
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? Label { get; set; }

    public bool? IsDone { get; set; }
}
