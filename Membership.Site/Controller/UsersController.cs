using System.Web.Mvc;

namespace Membership.Site.Controller
{
    public class UsersController : System.Web.Mvc.Controller
    {
        public ActionResult Create()
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

        public ActionResult Update()
        {
            return View("Index");
        }
    }
}