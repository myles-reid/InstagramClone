using InstagramClone.DAL;
using InstagramClone.Models;

namespace InstagramClone.BLL {
	class CommentService {
		private readonly CommentRepository commentRepo;

		public CommentService(InsDataContext context) {
			commentRepo = new CommentRepository(context);
		}

		public List<Comment> GetPostComments(int postId) {
			return commentRepo.GetComments(postId);
		}

		public void AddComment(Comment comment) {
			// add sanitization here
			commentRepo.AddComment(comment);
		}
		public void DeleteComment(Comment comment) {
			commentRepo.DeleteComment(comment);
		}

		public void EditComment(Comment comment) {
			// Add sanitization here
			commentRepo.UpdateComment(comment);
		}

	}
}
