using BankingSystem.Extensions;
using BankingSystem.Filters;
using BankingSystem.Service;
using PagedList;
using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace BankingSystem.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public static ExecutorServiceClient client;
        public UserController()
        {
            client = new ExecutorServiceClient();
        }


        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginUserCommand();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginUserCommand command)
        {
            var client = new ExecutorServiceClient();
            var result = client.LoginUser(command);

            if (result != null)
            {
                var role = client.GetRoleName(result.Id);
                var ticket = new FormsAuthenticationTicket(1,result.Email,DateTime.Now, DateTime.Now.AddSeconds(525600), true, role);
                var encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = DateTime.Now.AddMinutes(525600);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);

                return RedirectToAction("Listing");
            }

            Session["CurrentUser"] = result;

            return RedirectToAction("Login");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            var model = new RegisterUserCommand();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterUserCommand command)
        {
            var result = client.CreateUser(command);

            return RedirectToAction("UserDetails", new UserDetailsQuery { Id = result.EntityId });
        }

        [PermissionProvider(RoleName = "Operator")]
        public ActionResult Update(int id)
        {
            var client = new ExecutorServiceClient();
            var user = client.QueryUserDetails(new UserDetailsQuery
            {
                Id = id
            });

            var model = user.MapToCommand();

            return View(model);
        }

        [HttpPost]
        [PermissionProvider(RoleName = "Operator")]
        public ActionResult Update(UpdateUserCommand command)
        {
            var result = client.UpdateUser(command);

            return RedirectToAction("UserDetails", new UserDetailsQuery { Id = result.EntityId });
        }

        [HttpPost]
        [PermissionProvider(RoleName = "Operator")]
        public ActionResult Delete(DeleteUserCommand command)
        {
            var result = client.DeleteUser(command);

            return RedirectToAction("UserDetails");
        }

        public ActionResult Details(UserDetailsQuery query)
        {
            var result = client.QueryUserDetails(query);
            var model = result.MapToModel();

            return View(model);
        }

        [PermissionProvider(RoleName = "Owner")]
        public ActionResult Listing(string firstName, string email, int? page)
        {
            var query = new UserListQuery()
            {
                FirstName = firstName,
                Email = email
            };
            var result = client.QueryUsers(query);
            var model = result.MapToModel().ToList().ToPagedList(page ?? 1, 3);

            return View(model);
        }
    }
}