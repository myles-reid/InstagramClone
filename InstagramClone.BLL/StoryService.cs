using InstagramClone.DAL;
using InstagramClone.Models;

namespace InstagramClone.BLL {
	public class StoryService {
		private readonly StoryRepository storyRepo;

		public StoryService(InsDataContext context) {
			storyRepo = new StoryRepository(context);
		}

		public List<Story> GetAllStories() {
			return storyRepo.GetAllStories();
		}

		public List<Story> GetUserStories(int id) {
			return storyRepo.GetUserStories(id);
		}

		public Story GetUniqueStory(int id) {
			return storyRepo.GetUniqueStory(id);
		}

		public void NewStory(Story story) {
			storyRepo.NewStory(story);
		}

		public void AddView(int storyId, int userId) {
			storyRepo.AddView(storyId, userId);
		}
	}
}
