using ProjectE.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace ProjectE.Controllers
{
    public class ObjectsController : Controller
    {
        //
        // GET: /Objects/
       
       [Authorize]
        public ActionResult Index()
        {
            List<Objects> list = new DAO<Objects>().Select(x => x.User == null).ToList();
            return View(list);
        }

       
        [Authorize]
        public ActionResult Details(int id)
        {
            return View(new DAO<Objects>().Single(x => x.Id == id));
        }

        //
     
        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            List<TypeObject> list = new DAO<TypeObject>().Select().ToList();
            List<SelectListItem> slist = new List<SelectListItem>();
            foreach (TypeObject type in list)
            {
                slist.Add(new SelectListItem() { Text = type.Name, Value = type.Id.ToString() });
            }
            ViewBag.TypesList = slist;
            
            return View(new Objects());
            
            
        }

        //
        // POST: /Objects/Create
        // Добавление объекта POST-метод
        [HttpPost]
        public ActionResult Create(Objects obj)
        {
            new DAO<Objects>().Insert(obj);
            return RedirectToAction("index");
        }
        [Authorize]
        public ActionResult Take(int id)
        {
            DAO<Objects> db = new DAO<Objects>();
            Objects obj = db.Single(x => x.Id == id);
            obj.OwnerID = WebSecurity.CurrentUserId;
            db.Submit();
            return RedirectToAction("FreeObjects");
        }
        [Authorize]
        public ActionResult FreeObjects()
        {
            List<Objects> list = new DAO<Objects>().Select(x=> x.User == null).ToList();
            return View(list);
        }
       
    }
}
