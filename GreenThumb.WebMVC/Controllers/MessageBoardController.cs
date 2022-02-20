using GreenThumb.Models;
using GreenThumb.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenThumb.WebMVC.Controllers
{

    public class MessageBoardController : Controller
    {

        public ActionResult Index()
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
        // GET: MessageBoard
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageBoardCreate model)
        {
            
            {

                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var service = CreateMessageBoardService();

                if (service.CreateMessageBoard(model))
                {
                    TempData["SaveResult"] = "Your Message Board was created.";
                    return RedirectToAction("Index");
                };
                ModelState.AddModelError("", "Message Board could not be created.");
                return View(model);

            }
        }

        //Details

        public ActionResult Details(int Id)
        {
            var svc = CreateMessageBoardService();
            var model = svc.GetByThreadId(Id);

            return View(model);
        }

        //Edit
        public ActionResult Edit(int id)
        {
            var service = CreateMessageBoardService();
            var detail = service.GetByThreadId(id);
            var model = new MessageBoardEdit
            {
                ThreadId = detail.ThreadId,
                ThreadTitle = detail.ThreadTitle,
                ThreadContent = detail.ThreadContent,
                ThreadPhoto = detail.ThreadPhoto,
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ThreadId, MessageBoardEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ThreadId != ThreadId)
            {

                ModelState.AddModelError("", "Id Missmatch");
                return View(model);
            }
            var service = CreateMessageBoardService();

            if (service.UpdateMessageBoard(model))
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
            var svc = CreateMessageBoardService();
            var model = svc.GetByThreadId(Id);

            return View(model);
        }


        //delete post

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int Id)
        {
            var service = CreateMessageBoardService();
            service.DeleteMessageBoard(Id);
            TempData["SaveResult"] = "Your Message Board was Deleted";
            return RedirectToAction("Index");
        }
        //[Route("Create")]



        //[HttpPost]
        //public ActionResult Create(MessageBoardCreate model)
        //{
        //    HttpPostedFileBase file = Request.Files["ImageData"];
        //    Mess Service = new ContentRepository();
        //    int i = service.UploadImageInDataBase(file, model);
        //    if (i == 1)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}

        private MessageBoardService CreateMessageBoardService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageBoardService(userId);
            return service;
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(MessageBoardEdit model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    var imageService = CreateImageService();
        //    if (model.ImageID == -1)
        //    {
        //        model.Image = imageService.GetLatestImageForUser();

        //        if (model.Image is null)
        //        {
        //            // Invalid, get a default image
        //            model.Image = imageService.CreateAndReturnRandomImage(false);
        //        }
        //    }
        //    else
        //    {
        //        model.Image = imageService.GetImageByID(model.ImageID);
        //    }

        //    var service = CreatePersonService();
        //    if (service.UpdatePerson(model))
        //    {
        //        TempData["SaveResult"] = "Your person was updated.";
        //        return RedirectToAction("Index", "Home");
        //    }

        //    ModelState.AddModelError("", "Your person could not be updated.");
        //    model.Birthdate = (model.Birthdate is null) ? DateTime.Now : model.Birthdate;
        //    return View(model);
        //}

        private ImageService CreateImageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ImageService(userId);
            return service;
        }

        private byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            using (var reader = new BinaryReader(image.InputStream))
            {
                return reader.ReadBytes(image.ContentLength);
            }
        }

    }
}
