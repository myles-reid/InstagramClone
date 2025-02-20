using InstagramClone.Models;

namespace InstagramClone.DAL {
	public class StoryRepository {
		private readonly InsDataContext _context;

		public StoryRepository(InsDataContext context) {
			_context = context;
		}

		public List<Story> GetAllStories() {
			return _context.Stories.ToList();
		}

		public List<Story> GetUserStories(int id) {
			return _context.Stories.Where(s => s.UserId == id).ToList();
		}

		public Story GetUniqueStory(int id) {
			return (Story)_context.Stories.Where(s => s.StoryId == id);
		}

		public void AddView(int storyId, int userId) {
			_context.StoryViews.Add(new StoryView {
				StoryId = storyId,
				UserId = userId
			});
		}

		public void NewStory(Story story) {
			_context.Stories.Add(story);
			_context.SaveChanges();
		}

		public void DeleteStory(int id) {
			Story story = (Story)_context.Stories.Where(s => s.StoryId == id);
			_context.Stories.Remove(story);
			_context.SaveChanges();
		}

	}
}
