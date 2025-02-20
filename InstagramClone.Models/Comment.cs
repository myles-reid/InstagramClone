namespace InstagramClone.Models;

public partial class Comment {
	public int CommentId { get; set; }

	public int PostId { get; set; }

	public int UserId { get; set; }

	public string Text { get; set; } = null!;

	public DateTime? CreatedAt { get; set; }

	public virtual Post Post { get; set; } = null!;

	public virtual User User { get; set; } = null!;
}
