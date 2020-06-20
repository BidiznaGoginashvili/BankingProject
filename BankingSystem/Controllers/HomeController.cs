using System.Web.Mvc;

namespace BankingSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Main()
        {
            return View();
        }
    }
}