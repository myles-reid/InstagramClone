using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstagramClone.Models;

public partial class Post {
	[Key]
	public int PostId { get; set; }

	public int UserId { get; set; }

	public string? Caption { get; set; }

	public string ImageUrl { get; set; } = null!;

	[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
	public DateTime? CreatedAt { get; set; }

	public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

	public virtual User User { get; set; } = null!;

	public virtual ICollection<UserInteraction> UserInteractions { get; set; } = new List<UserInteraction>();
}
