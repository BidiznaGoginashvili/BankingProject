using System.Web.Mvc;
using BankingSystem.Service;

namespace BankingSystem.Controllers
{
    [Authorize]
    public class DepositController : Controller
    {
        public static ExecutorServiceClient client;
        public DepositController()
        {
            client = new ExecutorServiceClient();
        }

        public ActionResult CreateDeposit(int id)
        {
            var model = new CreateDepositCommand()
            {
                UserId = id
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateDeposit(CreateDepositCommand command)
        {
            client.CreateDeposit(command);
            return View();
        }
    }
}