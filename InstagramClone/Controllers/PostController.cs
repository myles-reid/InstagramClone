using InstagramClone.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Controllers {
	public class PostController : Controller {
		public IActionResult Index() {
			return View();
		}

		[HttpGet]
		public IActionResult NewPost() {
			return View();
		}

		[HttpPost]
		public IActionResult NewPost(PostViewModel newPost, int userID) {
			if (ModelState.IsValid) {
				newPost.Images = AddImages(newPost);
				//newPost.TaggedUsers = AddTags(newPost);
				return RedirectToAction("Home/Index");
			}
			return View(newPost);
		}

		// Will need to link this to the database via Entity Framework
		[HttpGet]
		public IActionResult EditPost(int postId) {
			//Post post = posts.Find(p => p.PostId == postId);
			return View(/*post*/);
		}

		[HttpPost]
		public IActionResult EditPost(PostViewModel post) {
			if (ModelState.IsValid) {
				//Post oldPost = posts.Find(p => p.PostId == post.PostId);
				//oldPost.Images = AddImages(post);
				//oldPost.Timestamp = DateTime.Now;
				//oldPost.TaggedUsers = AddTags(post);
				return RedirectToAction("Home/Index");
			}
			return View(post);
		}
		private List<string> AddImages(PostViewModel post) {
			List<string> images = new List<string>();
			if (post.ImageInput == null) {
				post.ImageInput = "";
			} else {
				string[] split = post.ImageInput.Split(", ");
				foreach (string s in split) {
					images.Add(s);
				}
			}
			return images;
		}

		// This needs to be updated to get UserID instead of Username
		private List<string> AddTags(PostViewModel post) {
			List<string> tags = new List<string>();
			if (post.TaggedUsersInput == null) {
				post.TaggedUsersInput = "";
			} else {
				string[] split = post.ImageInput.Split(", ");
				foreach (string s in split) {
					tags.Add(s);
				}
			}
			return tags;
		}
	}
}
