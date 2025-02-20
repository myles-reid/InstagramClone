using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Controllers {
	public class UserController : Controller {
		public IActionResult Index() {
			return View();
		}

		public IActionResult Profile() {
			return View();
		}
	}
}
