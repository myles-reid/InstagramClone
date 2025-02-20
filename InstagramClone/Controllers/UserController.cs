using InstagramClone.BLL;
using InstagramClone.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Controllers {
	public class UserController : Controller {
		private readonly UserService _userService;
		public IActionResult Index() {
			return View();
		}

		public IActionResult Profile(int id) {
			User user = _userService.GetUserInfo(id);
			return View(user);
		}
	}
}
