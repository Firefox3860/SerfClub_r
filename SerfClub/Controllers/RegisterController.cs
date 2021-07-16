using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerfClub.DAL;
using SerfClub.Helpers;
using SerfClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerfClub.Controllers
{
    public class RegisterController : Controller
    {
        // GET: RegisterController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegisterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegisterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserViewModel model, IFormFile imageData)
        {
            if (model.Nickname == null || model.Password == null || model.Email == null)
            {
                ModelState.AddModelError("", "Заполнены не все обязательные поля");
                return View("Index", model);
            }

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var context = new DataContext();
            if (context.Users.Where(u => u.Nickname == model.Nickname).Any())
            {
                ModelState.AddModelError("Nickname", "err");
                //
                return View("Index", model);
            }
            User user = new User();
            user.Nickname = model.Nickname;
            user.Email = model.Email;
            user.Password = model.Password;
            user.LastName = model.LastName;
            user.FirstName = model.FirstName;
            user.Photo = model.Photo;
            user.Password = model.Password;
            user.Contacts = model.Contacts;
            user.AboutMe = model.AboutMe;
            user.Achievements = model.Achievements;

            var helper = new ImageHelper();
            user.Photo = await helper.UploadImage(imageData);
            context.Users.Add(user);
            context.SaveChanges();

            await AuthenticateHelper.Authenticate(model.Nickname, false, HttpContext); // аутентификация
            if (user.Photo.HasValue && Guid.Empty != user.Photo.Value)
            {
                HttpContext.Session.SetString("Photo", user.Photo.Value.ToString());
            }
            HttpContext.Session.SetString("AuthorId", user.Id.ToString());
            return RedirectToAction("Index", "Home");
        }

        // GET: RegisterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegisterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegisterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
