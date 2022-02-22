using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenThumb.Data;
using GreenThumb.Models;

namespace GreenThumb.WebMVC.Controllers
{
    public class BashboardController : Controller
    {
        // GET: Bashboard
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<MessageBoard> ListMessage = db.MessageBoard.ToList();
            db.Dispose();
            return View(ListMessage);
        }

    }
}