using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // need to connect the two users, whoever is viewing and the user selected from view
        public IActionResult MessageThread(int userIDone, int userIDtwo) {
            return View();
        }
    }
}
