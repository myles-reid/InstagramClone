using InstagramClone.BLL;
using InstagramClone.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Controllers {
	public class MessagesController : Controller {
		private readonly DirectMessageService DirectMessageService;
		public IActionResult Index() {
			return View();
		}

		// all messages for the SINGLE user
		public IActionResult UserMessages(int userID) {
			List<DirectMessage> messages = DirectMessageService.GetUserMessages(userID);
			return View(messages);
		}

		// Messages between two specific users
		public IActionResult MessageThread(int userIDone, int userIDtwo) {
			List<DirectMessage> messages = DirectMessageService.GetConnectedMessages(userIDtwo, userIDone);
			return View(messages);
		}
	}
}
