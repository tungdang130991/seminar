using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Novate.Web.Models;
using Seminar.Common;
using Seminar.Repository;
using Seminar.Repository.Entity;
using Seminar.Web.Attributes;
using Seminar.Web.Extensions;
using Seminar.Web.Utility;
using Serilog;
using System.Threading.Tasks;

namespace Seminar.Web.Controllers
{
    public class HomeController : Controller
    {
        public IUserRepository UserRepository { get; set; }
        public IViewRenderService ViewRenderService { get; set; }
        public IStringLocalizer<Resources> StringLocalizer { get; set; }
        public AppSettings AppSettings { get; set; }

        public HomeController(IUserRepository userRepository, IOptions<AppSettings> settings, IViewRenderService renderService, IStringLocalizer<Resources> localizer)
        {
            UserRepository = userRepository;
            ViewRenderService = renderService;
            StringLocalizer = localizer;
            AppSettings = settings.Value;
        }

        public IActionResult Login()
        {
            UserRepository.GetAll();
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Testing()
        {
            //Add below line to form
            // @Html.AntiForgeryToken

            //Below code for testing ExceptionHandler middleware in asp.net core
            //throw new ArgumentNullException("Example");
            return View();
        }

        public async Task<IActionResult> Index()
        //public IActionResult Index()
        {
            // Below code just for example to use ViewRenderService only
            var user = new MSystemUser()
            {
                MsuName = "Sample Name",
                Authorities = Authorities.SystemManager
            };

            //Fake user
            HttpContext.Session.SetObject("LogedinUser", user);

            //var result = await ViewRenderService.RenderViewToStringAsync("Home/About", user);  or
            ViewData["sample"] = "Sample Data";
            var result = await ViewRenderService.RenderViewToStringAsync("Home/About", user);
            return Content(result);
            //return View();
        }

        [SessionTimeOut]
        public IActionResult Contact()
        {
            return View();
        }

        /// <summary>
        /// Handle all unhandled exceptions
        /// </summary>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public IActionResult Error(string msgId)
        {
            var ex = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (ex != null)
            {
                Log.Logger.Error(ex.Error, ex.Path);
            }

            var errorInfo = new ErrorViewModel() {
                Message = StringLocalizer[string.IsNullOrEmpty(msgId) ? "DefaultErrorMsg" : msgId].Value,
                PreviousUrl = (ex != null) ? ex.Path : ""
            };
            return View("SeminarErrorPage", errorInfo);
        }
    }
}
