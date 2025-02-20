namespace InstagramClone.Models;

public partial class DirectMessage {
	public int MessageId { get; set; }

	public int SenderId { get; set; }

	public int ReceiverId { get; set; }

	public string MessageText { get; set; } = null!;

	public DateTime? CreatedAt { get; set; }

	public bool? IsRead { get; set; }

	public virtual User Receiver { get; set; } = null!;

	public virtual User Sender { get; set; } = null!;
}
