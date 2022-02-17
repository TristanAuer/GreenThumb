using GreenThumb.Models.ReplyMB;
using GreenThumb.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenThumb.WebMVC.Controllers
{
    public class ReplyController : Controller
    {
        // GET: Reply
        [Authorize]
        public ActionResult CreateReply()
        {
            return View();
        }


        public ActionResult CreateReply(ReplyMBCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateReplyService();
            if (service.CreateReply(model))
            {
                TempData["SaveResult"] = "Your Reply was Created.";
                return RedirectToAction("Index Reply");
            }
            ModelState.AddModelError("", "your reply cannot be added to Message Board.");
            return View(model);
        }
        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReplyService(userId);
            return service;
        }
    }
}