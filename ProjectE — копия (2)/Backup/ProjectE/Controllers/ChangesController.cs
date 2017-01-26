using ProjectE.DAO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace ProjectE.Controllers
{
    public class ChangesController : Controller
    {
        //
        // GET: /Changes/

        public ActionResult Index()
        {
            return View(new DAO<Changes>().Select(x => x.SenderID == WebSecurity.CurrentUserId));
        }

        //
        // GET: /Changes/Create

        //
        // GET: /Changes/Edit/5

        public ActionResult Edit(int id)
        {
            return View(new DAO<Changes>().Select(x => x.Id == id));
        }

        //
        // POST: /Changes/Edit/5

        [HttpPost]
        public ActionResult Edit(Changes obj)
        {
            DAO<Changes> db = new DAO<Changes>();
            Changes edited = db.Single(x => x.Id == obj.Id);
            edited.Info = obj.Info;
            db.Submit();
            return RedirectToAction("index");
        }

    }
}
