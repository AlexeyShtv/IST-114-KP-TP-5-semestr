using ProjectE.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace ProjectE.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(new DAO<Objects>().Select(x => x.OwnerID == WebSecurity.CurrentUserId));
        }


        public ActionResult Create(int id)
        {
            int status = new DAO<StatusChanges>().Single(x => x.Name.ToLower() == "Ожидает".ToLower()).Id;
            return View(new Changes() { SenderID = WebSecurity.CurrentUserId, ObjectID = id, StatusID = status });
        }

        [HttpPost]
        public ActionResult Create(Changes obj)
        {
            new DAO<Changes>().Insert(obj);
            return RedirectToAction("index");
        }

    }
}
