using System.Web.Mvc;

namespace ProjetoHortFrut.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}