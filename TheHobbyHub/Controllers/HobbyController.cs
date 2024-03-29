﻿using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Data;

namespace TheHobbyHub.UI.Controllers
{
    public class HobbyController : Controller
    {
        private readonly DbContextOptions<HobbyHubEntities> options;

        public HobbyController(DbContextOptions<HobbyHubEntities> options)
        {
            this.options = options;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "List of Hobbies";
            return View(new HobbyManager(options).Load());
        }
        public IActionResult Details(Guid id)
        {
            var item = new HobbyManager(options).LoadById(id);
            ViewBag.Title = "Details";
            return View(item);
        }
        public IActionResult Create()
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                ViewBag.Title = "Create";
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Create(Hobby hobby)
        {
            try
            {
                int result = new HobbyManager(options).Insert(hobby);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult Edit(Guid id)
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                var item = new HobbyManager(options).LoadById(id);
                ViewBag.Title = "Edit";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }

        }
        [HttpPost]
        public IActionResult Edit(Guid id, Hobby hobby, bool rollback = false)
        {
            try
            {
                int result = new HobbyManager(options).Insert(hobby, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View();
            }
        }
        public IActionResult Delete(Guid id)
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                var item = new HobbyManager(options).LoadById(id);
                ViewBag.Title = "Delete";
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Delete(Guid id, Hobby hobby, bool rollback = false)
        {
            try
            {
                int result = new HobbyManager(options).Delete(id, rollback);
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
