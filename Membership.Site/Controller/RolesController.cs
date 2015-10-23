using System.Web.Mvc;

namespace Membership.Site.Controller
{
    public class RolesController : System.Web.Mvc.Controller
    {
        public ActionResult Create()
        {
            return View("Index");
        }
    }
}