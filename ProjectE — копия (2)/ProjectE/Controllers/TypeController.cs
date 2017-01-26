
            using ProjectE.DAO;
            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Web;
            using System.Web.Mvc;
            using WebMatrix.WebData;

namespace ProjectE.Controllers
    {
        public class TypeController : Controller
        {
        //
        // GET: /Objects/
       
        [Authorize(Roles = "Admin")]
        public ActionResult Index(List<TypeObject> list)
            {
                if (list == null)
                {
                    return View(new DAO<TypeObject>().Select());
                }
                else
                {
                    return View(list);
                }
            }

            //
            // GET: /Objects/Details/5
           
            [Authorize]
            public ActionResult Details(int id)
            {
                return View(new DAO<Objects>().Single(x => x.Id == id));
            }

            //
            // GET: /Objects/Create
            // Добавление объекта (запрос формы ввода) GET запрос
            [Authorize(Roles = "Admin")]
            public ActionResult Create()
            {
              

                return View(new TypeObject());


            }

            //
            // POST: /Objects/Create
            // Добавление объекта POST-метод
            [HttpPost]
        public ActionResult Create(TypeObject obj)
        {
            new DAO<TypeObject>().Insert(obj);
            return RedirectToAction("index");
        }


      

    }
    }

      
