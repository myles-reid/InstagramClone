namespace InstagramClone.Models;

public partial class Post {
	public int PostId { get; set; }

	public int UserId { get; set; }

	public string? Caption { get; set; }

	public string ImageUrl { get; set; } = null!;

	public DateTime? CreatedAt { get; set; }

	public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

	public virtual User User { get; set; } = null!;

	public virtual ICollection<UserInteraction> UserInteractions { get; set; } = new List<UserInteraction>();
}
