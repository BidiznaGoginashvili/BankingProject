using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingSystem.Filters
{
    public class PermissionProvider : ActionFilterAttribute
    {
        //ToRefactor
        public string RoleName { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!string.IsNullOrWhiteSpace(RoleName))
            {
                var roles = RoleName.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                bool inRole = false;
                for (int iterator = 0; iterator < roles.Length; iterator++)
                {
                    if (HttpContext.Current.User.IsInRole(roles[iterator]))
                    {
                        inRole = true;
                    }
                }

                if (!inRole)
                    filterContext.Result = new RedirectResult("User/Login");

                base.OnActionExecuting(filterContext);
            }
        }
    }
}