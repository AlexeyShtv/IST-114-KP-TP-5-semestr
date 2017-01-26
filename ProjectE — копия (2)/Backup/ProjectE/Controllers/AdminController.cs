
using ProjectE.DAO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectE.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(new DAO<Objects>().Select(x => x.User == null));
        }
        [Authorize(Roles = "Admin")]
        public ActionResult SetUserToObjects(int id)
        {
            List<SelectListItem> slist = new List<SelectListItem>();
            foreach (User obj in new DAO<User>().Select())
            {
                slist.Add(new SelectListItem() { Value = obj.UserId.ToString(), Text = obj.UserName });
            }
            ViewBag.UserList = slist;
            return View(new DAO<Objects>().Single(x => x.Id == id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult SetUserToObjects(Objects obj)
        {
            DAO<Objects> db = new DAO<Objects>();
            Objects edited = db.Single(x => x.Id == obj.Id);
            edited.OwnerID = obj.OwnerID;
            db.Submit();
            return RedirectToAction("index");
        }
    }
}
