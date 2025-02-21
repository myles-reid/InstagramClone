using System.Diagnostics;
using InstagramClone.BLL;
using InstagramClone.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Controllers;

public class HomeController : Controller {
	private readonly ILogger<HomeController> _logger;
	private readonly PostService _postService;
	private readonly UserService _userService;

	public HomeController(ILogger<HomeController> logger, PostService pService, UserService uSerivce) {
		_logger = logger;
		_postService = pService;
		_userService = uSerivce;
	}

	public IActionResult Index() {
		List<Post> posts = _postService.GetAllPosts();
		ViewBag.Users = _userService.GetUsers();
		TempData["ActiveUser"] = _userService.GetUserInfo(1);
		return View(posts);
	}

	public IActionResult Privacy() {
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error() {
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
