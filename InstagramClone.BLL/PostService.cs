using InstagramClone.DAL;
using InstagramClone.Models;

namespace InstagramClone.BLL {
	public class PostService {
		private readonly PostRepository postRepo;

		public PostService(InsDataContext context) {
			postRepo = new PostRepository(context);
		}

		public List<Post> GetAllPosts() {
			return postRepo.GetAllPosts();
		}

		public List<Post> GetUserPosts(int userId) {
			return postRepo.GetUserPosts(userId);
		}

		public void AddPost(Post post) {
			// add sanitization here
			postRepo.NewPost(post);
		}
		public void DeletePost(Post post) {
			// add a validation to ensure user wants to delete post
			postRepo.DeletePost(post);
		}

		public void EditPost(Post post) {
			// Add sanitization here
			postRepo.EditPost(post);
		}
	}
}
