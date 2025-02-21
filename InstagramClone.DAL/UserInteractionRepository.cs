using InstagramClone.Models;

namespace InstagramClone.DAL {
	public class UserInteractionRepository {
		private readonly InsDataContext _context;

		public UserInteractionRepository(InsDataContext context) {
			_context = context;
		}

		public List<UserInteraction> GetAllUserInteractions() {
			return _context.UserInteractions.ToList();
		}

		public List<UserInteraction> GetUserInteractions(int id) {
			return _context.UserInteractions.Where(i => i.UserId == id).ToList();
		}

		public List<UserInteraction> GetPostInteractions(int id) {
			return _context.UserInteractions.Where(i => i.PostId == id).ToList();
		}

		public void AddInteraction(UserInteraction interaction) {
			_context.UserInteractions.Add(interaction);
			_context.SaveChanges();
		}

		public void EditInteraction(UserInteraction interaction) {
			_context.UserInteractions.Update(interaction);
			_context.SaveChanges();
		}
	}
}
