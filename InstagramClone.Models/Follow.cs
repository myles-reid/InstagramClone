﻿using System;
using System.Collections.Generic;

namespace InstagramClone.Models;

public partial class Follow
{
    public int FollowId { get; set; }

    public int FollowerId { get; set; }

    public int FollowedId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User Followed { get; set; } = null!;

    public virtual User Follower { get; set; } = null!;
}
