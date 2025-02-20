using InstagramClone.BLL;
using InstagramClone.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Controllers {
	public class StoryController : Controller {
		private readonly StoryService _storyService;
		public IActionResult Index() {
			return View();
		}

		public IActionResult AddView(int storyId, int userId) {
			_storyService.AddView(storyId, userId);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult NewStory() {
			return View();
		}

		[HttpPost]
		public IActionResult NewStory(Story newStory) {
			if (ModelState.IsValid) {
				_storyService.NewStory(newStory);
				return RedirectToAction("Index");
			}
			return View(newStory);
		}
	}
}
