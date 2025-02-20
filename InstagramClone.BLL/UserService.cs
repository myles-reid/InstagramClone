using InstagramClone.DAL;
using InstagramClone.Models;

namespace InstagramClone.BLL {
	public class UserService {
		private readonly UserRepository userRepo;

		public UserService(InsDataContext context) {
			userRepo = new UserRepository(context);
		}

		public List<User> GetUsers() {
			return userRepo.GetUsers();
		}

		public User GetUserInfo(int id) {
			return userRepo.GetUserInfo(id);
		}

		public void NewUser(User user) {
			// add sanitization here
			userRepo.NewUser(user);
		}
		public void DeleteUser(User user) {
			// add a validation to ensure user wants to delete their account
			userRepo.DeleteUser(user);
		}

		public void EditUser(User user) {
			// Add sanitization here
			userRepo.UpdateUser(user);
		}
	}
}
