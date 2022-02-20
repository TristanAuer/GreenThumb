using GreenThumb.Models;
using GreenThumb.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenThumb.WebMVC.Controllers
{
    public class GardenController : Controller
    {
        // GET: Garden
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new GardenService(userId);
                var model = service.GetGarden();
                return View(model);
            }
            else
            {
                var model = new GardenList[0];
                return View(model);
            }
        }

        //get Garden

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GardenCreate model)
        {

            {

                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var service = CreateGardenidentitylogic();

                if (service.CreateGarden(model))
                {
                    TempData["SaveResult"] = "Your Message Board was created.";
                    return RedirectToAction("Index");
                };
                ModelState.AddModelError("", "Message Board could not be created.");
                return View(model);

            }
        }
        private GardenService CreateGardenidentitylogic()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GardenService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGardenidentitylogic();
            var detail= service.GetByGardenId(id);
            var model = new GardenEdit
            {
                GardenName = detail.GardenName,
                PlantType = detail.PlantType,
                PlantCount = detail.PlantCount,
                //PlantPhoto = detail.PlantPhoto  
                ModifiedUtc = detail.ModifiedUtc
            };
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int GardenId, GardenEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GardenId != GardenId)
            {

                ModelState.AddModelError("", "Id Missmatch");
                return View(model);
            }
            var service = CreateGardenidentitylogic();

            if (service.UpdateGarden(model))
            {
                TempData["SaveResult"] = "Your Message Board was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Message Board could not be created.");
            return View(model);
        }


        [ActionName("Delete")]
        public ActionResult Delete(int Id)
        {
            var svc = CreateGardenidentitylogic();
            var model = svc.GetByGardenId(Id);

            return View(model);
        }


        //delete post

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int Id)
        {
            var service = CreateGardenidentitylogic();
            service.DeleteGarden(Id);
            TempData["SaveResult"] = "Your Message Board was Deleted";
            return RedirectToAction("Index");
        }
    }
    
}