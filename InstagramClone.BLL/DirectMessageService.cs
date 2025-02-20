using InstagramClone.DAL;
using InstagramClone.Models;

namespace InstagramClone.BLL {
	public class DirectMessageService {
		private readonly DirectMessageRepository messageRepo;

		public DirectMessageService(InsDataContext context) {
			messageRepo = new DirectMessageRepository(context);
		}

		public List<DirectMessage> GetUserMessages(int userId) {
			return messageRepo.GetUserMessages(userId);
		}

		public List<DirectMessage> GetConnectedMessages(int userId, int connection) {
			return messageRepo.GetConnectedMessages(userId, connection);
		}

		public void NewMessage(DirectMessage message) {
			// add sanitization here
			messageRepo.NewMessage(message);
		}
		public void DeleteComment(DirectMessage message) {
			messageRepo.DeleteComment(message);
		}

		public void EditComment(DirectMessage message) {
			// Add sanitization here
			messageRepo.UpdateComment(message);
		}
	}
}
