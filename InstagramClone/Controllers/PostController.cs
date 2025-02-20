using InstagramClone.BLL;
using InstagramClone.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Controllers {
	public class PostController : Controller {
		private readonly PostService _postService;

		public IActionResult Index() {
			return View();
		}

		[HttpGet]
		public IActionResult NewPost() {
			return View();
		}

		[HttpPost]
		public IActionResult NewPost(Post newPost) {
			if (ModelState.IsValid) {
				_postService.AddPost(newPost);
				return RedirectToAction("Home/Index");
			}
			return View(newPost);
		}

		// Will need to link this to the database via Entity Framework
		[HttpGet]
		public IActionResult EditPost(int id, int userId) {
			Post post = (Post)_postService.GetUserPosts(id).Where(p => p.UserId == userId);
			return View(post);
		}

		[HttpPost]
		public IActionResult EditPost(Post post, int id) {
			if (ModelState.IsValid) {
				Post oldPost = (Post)_postService.GetUserPosts(id).Where(p => p.UserId == id && p.PostId == post.PostId);
				_postService.EditPost(oldPost);
				return RedirectToAction("Home/Index");
			}
			return View(post);
		}

		// Use for multiple images and user tags
		//private List<string> AddImages(Post post) {
		//	List<string> images = new List<string>();
		//	if (post.ImageUrl == null) {
		//		post.ImageInput = "";
		//	} else {
		//		string[] split = post.ImageInput.Split(", ");
		//		foreach (string s in split) {
		//			images.Add(s);
		//		}
		//	}
		//	return images;
		//}

		//// This needs to be updated to get UserID instead of Username
		//private List<string> AddTags(PostViewModel post) {
		//	List<string> tags = new List<string>();
		//	if (post.TaggedUsersInput == null) {
		//		post.TaggedUsersInput = "";
		//	} else {
		//		string[] split = post.ImageInput.Split(", ");
		//		foreach (string s in split) {
		//			tags.Add(s);
		//		}
		//	}
		//	return tags;
		//}
	}
}
