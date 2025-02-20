namespace InstagramClone.Models;

public partial class User {
	public int UserId { get; set; }

	public string Username { get; set; } = null!;

	public string PasswordHash { get; set; } = null!;

	public string Email { get; set; } = null!;

	public string? Bio { get; set; }

	public string? ProfilePicture { get; set; }

	public int? NumFollower { get; set; }

	public int? NumFollowing { get; set; }

	public DateTime? CreatedAt { get; set; }

	public DateTime? UpdatedAt { get; set; }

	public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

	public virtual ICollection<DirectMessage> DirectMessageReceivers { get; set; } = new List<DirectMessage>();

	public virtual ICollection<DirectMessage> DirectMessageSenders { get; set; } = new List<DirectMessage>();

	public virtual ICollection<Follow> FollowFolloweds { get; set; } = new List<Follow>();

	public virtual ICollection<Follow> FollowFollowers { get; set; } = new List<Follow>();

	public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

	public virtual ICollection<Story> Stories { get; set; } = new List<Story>();

	public virtual ICollection<StoryView> StoryViews { get; set; } = new List<StoryView>();

	public virtual ICollection<UserInteraction> UserInteractions { get; set; } = new List<UserInteraction>();
}
