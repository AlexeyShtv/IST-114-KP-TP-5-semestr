using ProjectE.DAO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectE.Controllers
{
    public class ManagerController : Controller
    {
        //
        // GET: /Manager/
        [Authorize(Roles = "Manager")]
        public ActionResult Index(String filter)
        {
            int status;
            if (filter != null)
            {
                try
                {
                    status = new DAO<StatusChanges>().Single(x => x.Name.ToLower() == filter.ToLower()).Id;
                }
                catch
                {
                    return View(new DAO<Changes>().Select());
                }
            }
            else
            {
                return View(new DAO<Changes>().Select());
            }
            return View(new DAO<Changes>().Select(x => x.StatusID == status));
        }

        //
        // GET: /Manager/Details/5
        [Authorize(Roles = "Manager")]
        public ActionResult Accept(int id)
        {
            return View(new DAO<Changes>().Single(x => x.Id == id));
        }

        [HttpPost]
        public ActionResult Accept(Changes obj)
        {
            DAO<Changes> db = new DAO<Changes>();
            Changes edit = db.Single(x => x.Id == obj.Id);
            edit.StatusID = new DAO<StatusChanges>().Single(x => x.Name.ToLower() == "подтвержден").Id;
            db.Submit();
            return RedirectToAction("index");
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Decline(int id)
        {
            return View(new DAO<Changes>().Single(x => x.Id == id));
        }

        [HttpPost]
        public ActionResult Decline(Changes obj)
        {
            DAO<Changes> db = new DAO<Changes>();
            Changes edit = db.Single(x => x.Id == obj.Id);
            edit.StatusID = new DAO<StatusChanges>().Single(x => x.Name.ToLower() == "отклонен").Id;
            db.Submit();
            return RedirectToAction("index");
        }
        [Authorize(Roles = "Manager")]
        public ActionResult Delete(int id)
        {
            return View(new DAO<Changes>().Single(x => x.Id == id));
        }

        [HttpPost]
        public ActionResult Delete(Changes obj)
        {
            DAO<Changes> db = new DAO<Changes>();
            Changes edit = db.Single(x => x.Id == obj.Id);
            edit.StatusID = new DAO<StatusChanges>().Single(x => x.Name.ToLower() == "удален").Id;
            db.Submit();
            return RedirectToAction("index");
        }
    }
}
