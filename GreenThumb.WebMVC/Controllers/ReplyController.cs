using GreenThumb.Models;
using GreenThumb.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace GreenThumb.WebMVC.Controllers
{
    public class ReplyController : Controller
    {
        // GET: Reply

        public ActionResult UserMessagesListReply(Guid Id)
        {
            var ReplyMBSvc = new ReplyService(Id);
            var MessageSvc = new MessageBoardService(Id);
            var model = new ReplyMBmulti();
            model.RecentReply = (System.Collections.Generic.IEnumerable<ReplyMBList>)ReplyMBSvc.RecentReply();
            model.GetCurrentMessage = (System.Collections.Generic.IEnumerable<MessageBoardDetail>)MessageSvc.GetCurrentMessage();

            return View(model);
        }
        //public ReplyDetail Replys()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());


        //}
        [Authorize]
        public ActionResult CreateReply()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                return RedirectToAction("Index");
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