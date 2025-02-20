using System;
using System.Collections.Generic;

namespace InstagramClone.Models;

public partial class Story
{
    public int StoryId { get; set; }

    public int UserId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public virtual ICollection<StoryView> StoryViews { get; set; } = new List<StoryView>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserInteraction> UserInteractions { get; set; } = new List<UserInteraction>();
}
