using System.Web.Mvc;

namespace Membership.Site.Controller
{
    public class RolesController : System.Web.Mvc.Controller
    {
        public ActionResult Create()
        {
            return View("Index");
        }

        public ActionResult Edit(string id)
        {
            return View("Index");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View("Index");
        }
    }
}