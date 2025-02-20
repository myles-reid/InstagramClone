using InstagramClone.Models;

namespace InstagramClone.DAL {
	public class CommentRepository {
		private readonly InsDataContext _context;

		public CommentRepository(InsDataContext context) {
			_context = context;
		}

		public List<Comment> GetComments(int postId) {
			return _context.Comments.Where(c => c.PostId == postId).ToList();
		}

		public void AddComment(Comment comment) {
			_context.Comments.Add(comment);
			_context.SaveChanges();
		}

		public void DeleteComment(Comment comment) {
			_context.Comments.Remove(comment);
			_context.SaveChanges();
		}

		public void UpdateComment(Comment comment) {
			_context.Comments.Update(comment);
			_context.SaveChanges();
		}
	}
}
