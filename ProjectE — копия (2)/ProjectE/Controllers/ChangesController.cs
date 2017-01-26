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

       

     

        

    }
}
