using System.Web.Mvc;
using Example.Models;

namespace Example.Controllers
{
    public class HomeController : Controller
    {
        IRepository repo;

        public HomeController(IRepository repoImpl)
        {
            repo = repoImpl;
        }
        public ActionResult Index()
        {
            return View(repo.Products);
        }
	}
}