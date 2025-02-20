using InstagramClone.Models;

namespace InstagramClone.DAL {
	public class DirectMessageRepository {
		private readonly InsDataContext _context;

		public DirectMessageRepository(InsDataContext context) {
			_context = context;
		}

		public List<DirectMessage> GetUserMessages(int userID) {
			return _context.DirectMessages.Where(c => c.SenderId == userID || c.ReceiverId == userID).ToList();
		}

		public List<DirectMessage> GetConnectedMessages(int userId, int connection) {
			return _context.DirectMessages.Where(c => (c.SenderId == userId && c.ReceiverId == connection) || (c.SenderId == connection && c.ReceiverId == userId)).ToList();
		}

		public void NewMessage(DirectMessage message) {
			_context.DirectMessages.Add(message);
			_context.SaveChanges();
		}

		public void DeleteComment(DirectMessage message) {
			_context.DirectMessages.Remove(message);
			_context.SaveChanges();
		}

		public void UpdateComment(DirectMessage message) {
			_context.DirectMessages.Update(message);
			_context.SaveChanges();
		}
	}
}
