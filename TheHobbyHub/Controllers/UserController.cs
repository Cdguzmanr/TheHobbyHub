using TheHobbyHub.BL;
using TheHobbyHub.BL.Models;
//using TheHobbyHub.UI.Extensions;
using TheHobbyHub.UI.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Data;
using TheHobbyHub.UI.Controllers;
using TheHobbyHub.UI.ViewModels;
using Humanizer.Localisation;

namespace TheHobbyHub.Controllers
{
    public class UserController : Controller
    {
        private readonly DbContextOptions<HobbyHubEntities> options;
        private readonly IWebHostEnvironment _host;

        public UserController(DbContextOptions<HobbyHubEntities> options, IWebHostEnvironment host)
        {
            this.options = options;
            _host = host;
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

            var item = new UserVM(id, options);
            
            ViewBag.Title = "Edit";

            if (Authentication.IsAuthenticated(HttpContext))
            {
                HttpContext.Session.SetObject("userVM", item);
                ViewBag.Title = "Edit " + item.User.FullName;
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
                if (new UserVM(options).File != null)
                {
                    new UserVM(options).User.Image = new UserVM(options).File.FileName;

                    string path = _host.WebRootPath + "\\images\\";

                    using (var stream = System.IO.File.Create(path + new UserVM(options).File.FileName))
                    {
                        new UserVM(options).File.CopyTo(stream);
                        ViewBag.Info = "File updated successfully...";
                    }
                }

                if (new UserVM(options).HobbyIds != null)
                {
                    new UserVM(options).User.Hobbys = new List<Hobby>();
                    foreach (Guid hobbyId in new UserVM(options).HobbyIds)
                    {
                        Hobby hobby = new HobbyManager(options).LoadById(hobbyId);
                        new UserVM(options).User.Hobbys.Add(hobby);
                    }
                }
                else
                {
                    Hobby hobby = new HobbyManager(options).LoadById(id);
                    new UserVM(options).User.Hobbys.Add(hobby);
                }

                // Deal with the movie image file if it has changed
                UserVM originalUserVM = HttpContext.Session.GetObject<UserVM>("userVM");

                if (originalUserVM.User.Image != new UserVM(options).User.Image)
                {
                    RemoveUnusedUserImageFile(new UserVM(options).User.Id, originalUserVM.User.Image);
                }


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

        private void RemoveUnusedUserImageFile(Guid userId, string image)
        {
            bool inuse = false;

            // Check if image is also used by another movie
            List<User> users = new UserManager(options).Load();
            inuse = users.Any(u => u.Image == image && u.Id != userId);

            // If image is not used my other movie, delete it.
            if (!inuse)
            {
                string path = _host.WebRootPath + "\\images\\" + image;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }

        }
    }
}