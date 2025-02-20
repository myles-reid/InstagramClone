using InstagramClone.BLL;
using InstagramClone.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Controllers {
	public class MessagesController : Controller {
		private readonly DirectMessageService DirectMessageService;

		// Get all the users messages and display them
		public IActionResult Index(int id) {
			List<DirectMessage> messages = DirectMessageService.GetUserMessages(id);
			return View(messages);
		}

		// Messages between two specific users
		public IActionResult MessageThread(int userIDone, int userIDtwo) {
			List<DirectMessage> messages = DirectMessageService.GetConnectedMessages(userIDtwo, userIDone);
			return View(messages);
		}
	}
}
