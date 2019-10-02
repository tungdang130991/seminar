using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Seminar.Web.Extensions;
using Seminar.Repository.Entity;
using Serilog;

namespace Seminar.Web.Attributes
{
    public class SessionTimeOutAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.HttpContext.Session.IsExistObject<MSystemUser>("LogedinUser"))
            {
                context.Result = new RedirectResult("/Home/Index");
                Log.Logger.Warning("Session timeout.");
                return;
            }
            base.OnActionExecuting(context);    
        }
    }
}
