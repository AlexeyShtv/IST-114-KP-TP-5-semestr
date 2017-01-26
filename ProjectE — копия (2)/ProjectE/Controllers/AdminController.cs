
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
        
        public ActionResult Index(List<User> list)
        {
            if (list == null)
            {
                return View(new DAO<User>().Select());
            }
            else
            {
                return View(list);
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult SetRole(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (webpages_Roles role in new DAO<webpages_Roles>().Select())
            {
                list.Add(new SelectListItem() { Text = role.RoleName, Value = role.RoleId.ToString() });
            }
            ViewBag.RouteList = list;
            return View(new webpages_UsersInRoles() { UserId = id });
        }

    }
}
