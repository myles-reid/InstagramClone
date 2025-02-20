using InstagramClone.Models;

namespace InstagramClone.DAL {
	public class UserRepository {
		private readonly InsDataContext _context;

		public UserRepository(InsDataContext context) {
			_context = context;
		}

		public List<User> GetUsers() {
			return _context.Users.ToList();
		}

		public User GetUserInfo(int id) {
			return (User)_context.Users.Where(u => u.UserId == id);
		}

		public void NewUser(User user) {
			_context.Users.Add(user);
			_context.SaveChanges();
		}

		public void DeleteUser(User user) {
			_context.Users.Remove(user);
			_context.SaveChanges();
		}

		public void UpdateUser(User user) {
			_context.Users.Update(user);
			_context.SaveChanges();
		}
	}
}
