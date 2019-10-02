using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Seminar.Common;
using Seminar.Repository.Entity;
using Seminar.Web.Extensions;
using Serilog;

namespace Seminar.Web.Attributes
{
    public class AuthoritiesAttribute: ActionFilterAttribute
    {
        public Authorities  AllowedAuthorities { get; set; }

        public AuthoritiesAttribute(Authorities allowedAuthorities)
        {
            AllowedAuthorities = allowedAuthorities;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Check session timeout
            MSystemUser user = context.HttpContext.Session.GetObject<MSystemUser>("LogedinUser");
            if (user == null)
            {
                context.Result = new RedirectResult("/Home/Index");
                Log.Logger.Warning("Session timeout.");
                return;
            }

            // Check Authorities
            if((user.Authorities & AllowedAuthorities) == 0)
            {
                context.Result = new RedirectResult("/Home/Index");
                Log.Logger.Warning("The user dont have authority to access page: " + context.HttpContext.Request.Path);
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}
