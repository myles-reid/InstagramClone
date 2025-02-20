using InstagramClone.DAL;
using InstagramClone.Models;

namespace InstagramClone.BLL {
	class CommentService {
		private readonly CommentRepository commentRepo;

		public CommentService(InsDataContext context) {
			commentRepo = new CommentRepository(context);
		}
	}
}
