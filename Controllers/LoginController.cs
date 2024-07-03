// LoginController.cs
using Blogger.DTOs;
using Blogger.EF; // Replace with your actual EF namespace
using System.Linq;
using System.Web.Mvc;

namespace Blogger.Controllers
{
    public class LoginController : Controller
    {
        private bishakhMIDEntities db = new bishakhMIDEntities(); 

        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginDTO l)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.users
                            where u.username.Equals(l.username)
                            select u).SingleOrDefault();

                if (user != null && user.password.Equals(l.password))
                {
                    Session["user"] = user; // Store user in session
                    TempData["Msg"] = "Login successful.";

                    if (user.utype.Equals("Admin"))
                    {
                        return RedirectToAction("Index", "Admin"); // Redirect to Admin dashboard
                    }
                    // Replace "Order" with your desired controller for regular users
                    return RedirectToAction("Index", "Order"); // Redirect to Order dashboard
                }

                TempData["Msg"] = "Username or password incorrect.";
                return RedirectToAction("Index");
            }

            return View(l);
        }

    }
}
