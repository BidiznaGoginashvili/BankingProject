using System.Web.Mvc;
using BankingSystem.Service;

namespace BankingSystem.Controllers
{
    [Authorize]
    public class LoanController : Controller
    {
        public static ExecutorServiceClient client;
        public LoanController()
        {
            client = new ExecutorServiceClient();
        }

        public ActionResult CreateLoan(int id)
        {
            var model = new CreateLoanCommand()
            {
                UserId = id
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateLoan(CreateLoanCommand command)
        {
            client.CreateLoan(command);
            return View();
        }
    }
}