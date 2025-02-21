using InstagramClone.DAL;
using InstagramClone.Models;

namespace InstagramClone.BLL {
	public class UserInteractionService {
		private readonly UserInteractionRepository UserInteractionRepo;

		public UserInteractionService(InsDataContext context) {
			UserInteractionRepo = new UserInteractionRepository(context);
		}

		public List<UserInteraction> GetAllUserInteractions() {
			return UserInteractionRepo.GetAllUserInteractions();
		}

		public List<UserInteraction> GetUserInteractions(int id) {
			return UserInteractionRepo.GetUserInteractions(id);
		}

		public List<UserInteraction> GetPostInteractions(int id) {
			return UserInteractionRepo.GetPostInteractions(id);
		}

		public void AddInteraction(UserInteraction interaction) {
			// add sanitization here
			UserInteractionRepo.AddInteraction(interaction);
		}
		public void EditInteraction(UserInteraction interaction) {
			// Add sanitization here
			UserInteractionRepo.EditInteraction(interaction);
		}
	}
}
