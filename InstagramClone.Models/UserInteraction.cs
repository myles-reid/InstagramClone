namespace InstagramClone.Models;

public partial class UserInteraction {
	public int InteractionId { get; set; }

	public int UserId { get; set; }

	public int? PostId { get; set; }

	public int? StoryId { get; set; }

	public string? InteractionType { get; set; }

	public DateTime? CreatedAt { get; set; }

	public virtual Post? Post { get; set; }

	public virtual Story? Story { get; set; }

	public virtual User User { get; set; } = null!;
}
