using System;
using System.Collections.Generic;

namespace InstagramClone.Models;

public partial class StoryView
{
    public int ViewId { get; set; }

    public int UserId { get; set; }

    public int StoryId { get; set; }

    public DateTime? ViewedAt { get; set; }

    public virtual Story Story { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
