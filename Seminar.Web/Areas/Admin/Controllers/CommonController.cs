using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Seminar.Repository.Entity;
using Seminar.Web.Extensions;

namespace Seminar.Web.Areas.Admin.Controllers
{
    public class CommonController : Controller
    {
        /// <summary>
        /// Object to get resources from Resources file
        /// </summary>
        public IStringLocalizer<Resources> StringLocalizer { get; set; }

        public CommonController(IStringLocalizer<Resources> stringLocalizer)
        {
            StringLocalizer = stringLocalizer;
        }

        public MSystemUser GetLogedinUser()
        {
            return HttpContext.Session.GetObject<MSystemUser>("LogedinUser");
        }
    }

    public class CommonController<T> : CommonController
    {
        public CommonController(IStringLocalizer<Resources> stringLocalizer):base(stringLocalizer)
        {

        }
        public T SeminarRepository { get; set; }
    }
}