using InstagramClone.BLL;
using InstagramClone.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Controllers {
	public class MessagesController : Controller {
		private readonly DirectMessageService DirectMessageService;

		public MessagesController(DirectMessageService directMessageService) {
			DirectMessageService = directMessageService;
		}

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

        // create new message
        [HttpGet]
        public IActionResult NewDirectMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewDirectMessage(DirectMessage newDirectMessage)
        {
            if (ModelState.IsValid)
            {
                DirectMessageService.NewMessage(newDirectMessage);
                return RedirectToAction("Messages/Index");
            }
            return View(newDirectMessage);
        }

        //delete message
        public IActionResult DeleteDirectMessage(DirectMessage newDirectMessage)
        {
            DirectMessageService.DeleteComment(newDirectMessage);
            return RedirectToAction("Messages/Index");
        }
    }
}
