using InstagramClone.Models;

namespace InstagramClone.DAL {
	public class PostRepository {
		private readonly InsDataContext _context;

		public PostRepository(InsDataContext context) {
			_context = context;
		}

		public List<Post> GetAllPosts() {
			return _context.Posts.ToList();
		}

		public List<Post> GetUserPosts(int userId) {
			return _context.Posts.Where(c => c.UserId == userId).ToList();
		}

		public void NewPost(Post post) {
			_context.Posts.Add(post);
			_context.SaveChanges();
		}

		public void DeletePost(Post post) {
			_context.Posts.Remove(post);
			_context.SaveChanges();
		}

		public void EditPost(Post post) {
			_context.Posts.Update(post);
			_context.SaveChanges();
		}
	}
}
