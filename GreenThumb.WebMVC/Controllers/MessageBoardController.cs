using GreenThumb.Models.MessageBoard;
using GreenThumb.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenThumb.WebMVC.Controllers
{
    
    public class MessageBoardController : Controller
    {
        
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageBoardService(userId);
            var model = service.GetMessages();


            return View(model);
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
            if (ModelState.IsValid)
            {
                return View(model);
            }
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageBoardService(userId);

            service.CreateMessageBoard(model);

            return RedirectToAction("Index");

        }
    }

}
