using GreenThumb.Models;
using GreenThumb.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace GreenThumb.WebMVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        public ActionResult ProfileIndex()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new MessageBoardService(userId);
                var model = service.GetMessages();
                return View(model);
            }
            else
            {
                var model = new MessageBoardList[0];
                return View(model);
            }
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfileCreate model)
        {

            {

                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var service = CreateProfileService();

                if (service.CreateProfile(model))
                {
                    TempData["SaveResult"] = "Your Message Board was created.";
                    return RedirectToAction("Index");
                };
                ModelState.AddModelError("", "Message Board could not be created.");
                return View(model);

            }
        }


        private ProfileMBService CreateProfileService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProfileMBService(userId);
            return service;
        }

        public ActionResult Details(int Id)
        {
            var svc = CreateProfileService();
            var model = svc.GetByProfileId(Id);

            return View(model);
        }
    }

        // GET: Profile
        //public ActionResult Create()
        //{
        //    return View();
        //}

    
}