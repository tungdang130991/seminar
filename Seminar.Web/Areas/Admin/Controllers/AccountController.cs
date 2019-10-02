using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Novate.Web.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Authenticate()
        {
            return View();
        }
    }
}