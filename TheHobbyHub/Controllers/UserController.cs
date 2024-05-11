using TheHobbyHub.BL;
using TheHobbyHub.BL.Models;
//using TheHobbyHub.UI.Extensions;
using TheHobbyHub.UI.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Data;
using TheHobbyHub.UI.Controllers;

namespace TheHobbyHub.Controllers
{
    public class UserController : Controller
    {
        private readonly DbContextOptions<HobbyHubEntities> options;

        public UserController(DbContextOptions<HobbyHubEntities> options)
        {
            this.options = options;
        }

        // Generalized class name
        string className = "User";


        // User only operations

        private void SetUser(User user)
        {

            HttpContext.Session.SetObject("user", user);
            if (user != null)
            {
                HttpContext.Session.SetObject("fullname", user.FullName);
                HttpContext.Session.SetObject("userId", user.Id);
                HttpContext.Session.SetObject("userImage", user.Image);
            }
            else
            {
                HttpContext.Session.SetObject("fullname", string.Empty);
            }
        }
        public IActionResult Logout()
        {
            ViewBag.Title = "Logout";
            SetUser(null);
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            ViewBag.Title = "Login";
            return View();
        }


        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                bool result = new UserManager(options).Login(user);
                SetUser(user);

                if (TempData["returnUrl"] != null)
                {
                    return Redirect(TempData["returnUrl"]?.ToString());
                }

                return RedirectToAction(nameof(Index), "Hobby"); // ALWAYS Change default re-derict page 
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Login";
                ViewBag.Error = ex.Message;
                throw;
            }
        }





        // Regular CRUD operations 
        public IActionResult Index()
        {
            ViewBag.Title = $"List of {className}";
            return View(new UserManager(options).Load());
        }
        public IActionResult Details(Guid id)
        {
            var item = new UserManager(options).LoadById(id);
            ViewBag.Title = $"{className} details";
            return View(item);
        }

        // Regular Create
        public IActionResult Create()
        {
            ViewBag.Title = $"Create new {className}";
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                int result = new UserManager(options).Insert(user);
                SetUser(user); // LogIn with new user 
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = $"Create new {className}";
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }


        // View Model
/*        public IActionResult Create()
        {
            ViewBag.Title = $"Create new {className}";

            var userVM = new UserVM(options);
            userVM.Hobbys = new HobbyManager(options).Load();
            userVM.Events = new EventManager(options).Load();

            return View(userVM);
        }
        [HttpPost]
        public IActionResult Create(UserVM userVM)
        {
            try
            {

*//*                // Process the image
                if (userVM.File != null) // Error doing populate of image. Its always null
                {
                    userVM.User.Image = userVM.File.FileName;
                    string path = 
                    using (var stream = System.IO.File.Create(path + userVM.File.FileName)) // You are going to process the characters enconded in the image
                    {
                        userVM.File.CopyTo(stream);
                        ViewBag.Message = "File Uploaded Successfully...";
                    }
                }*//*


                // Adds the user
                int result = new UserManager(options).Insert(userVM.User);

                // Adds the new Hobbies to the movie
                IEnumerable<Guid> newGenreIds = new List<Guid>();
                if (userVM.HobbyIds != null)
                    newGenreIds = userVM.HobbyIds;
                newGenreIds.ToList().ForEach(a => new UserHobbyManager(options).Insert(userVM.User.Id, a));


                //newGenreIds.ToList().ForEach(a => new UserHobbyManager.Insert(userVM.User.Id, a)); // userId , hobbyId

                SetUser(userVM.User); // LogIn with new user

                return RedirectToAction(nameof(Index));

                // ---- old - No ViewModel --- //

*//*                int result = new UserManager(options).Insert(user.User);
                SetUser(user); // LogIn with new user 
                return RedirectToAction(nameof(Index));*//*
            }
            catch (Exception ex)
            {
                ViewBag.Title = $"Create new {className}";
                ViewBag.Error = ex.Message;
                return View(userVM.User);
            }
        }*/


        public IActionResult Edit(Guid id)
        {

            var item = new UserManager(options).LoadById(id);
            ViewBag.Title = "Edit";

            if (Authentication.IsAuthenticated(HttpContext))
            {
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }

        }
        [HttpPost]
        public IActionResult Edit(Guid id, User user, bool rollback = false)
        {
            try
            {
                int result = new UserManager(options).Update(user, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Edit";
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        public IActionResult Delete(Guid id)
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                var item = new UserManager(options).LoadById(id);
                ViewBag.Title = $"Delete {className}";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Delete(Guid id, User user, bool rollback = false)
        {
            try
            {
                int result = new UserManager(options).Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}