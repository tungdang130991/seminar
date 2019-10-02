using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Localization;
using Seminar.Common;
using Seminar.Common.Extensions;
using Seminar.Repository;
using Seminar.Repository.Entity;
using Seminar.Web.Attributes;
using Seminar.Web.Extensions;
using Seminar.Web.Utility;
using Serilog;

namespace Seminar.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorities(Authorities.SystemManager)]
    public class SchoolController : CommonController
    {
        public ISchoolRepository SchoolRepository { get; set; }
        public IViewRenderService ViewRenderService { get; set; }
        public SchoolController(ISchoolRepository schoolRepository, IViewRenderService renderService,
            IStringLocalizer<Resources> stringLocalizer) : base(stringLocalizer)
        {
            SchoolRepository = schoolRepository;
            ViewRenderService = renderService;
        }

        public IActionResult Index()
        {
            List<MSchool> schools;
            try
            {
                schools = SchoolRepository.GetAll();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Get all schools from database");
                schools = new List<MSchool>();
            }
            TempData.Put("AllSchools", schools);
            return View(schools);
        }
        public async Task<JsonResult> LoadTable()
        {
            List<MSchool> schools = SchoolRepository.GetAll();
            string htmlform = await ViewRenderService.RenderViewToStringAsync("~/Areas/Admin/Views/School/_List.cshtml", schools);
            return Json(new { status = 0, htmlform });
        }
        public async Task<JsonResult> New()
        {
            string html = await ViewRenderService.RenderViewToStringAsync("~/Areas/Admin/Views/School/_New.cshtml", new MSchool());
            return Json(new { status = 0, html });
        }

        public JsonResult IsDeletable(string code)
        {
            var result = SchoolRepository.IsChangeable(code);
            return Json(new { status = result });
        }

        public async Task<JsonResult> Edit(string code)
        {
            var schools = TempData.Get<List<MSchool>>("AllSchools");
            if (SchoolRepository.checkCondition(code) == true)
            {
                ViewData["IsCodeEditable"] = true;
            }
            else
            {
                ViewData["IsCodeEditable"] = null;
            }
            MSchool schoolitem = new MSchool();
            schoolitem= schools.Where(school => school.MsCd.Equals(code)).FirstOrDefault();
            TempData.Put("schoolitem", schoolitem);
            ViewData.Model = schoolitem;
            string html = await ViewRenderService.RenderViewToStringAsync("~/Areas/Admin/Views/School/_Edit.cshtml", ViewData, TempData);
            TempData.Keep();
            return Json(new { status = 0, schoolCode = code, html });
        }

        public async Task<JsonResult> Delete(string ids)
        {
            ErrorCodes result;
            string html = "";         
            try
            {                
                result=SchoolRepository.Delete(ids, GetLogedinUser());
            }
            catch (ENovateException eex)
            {
                Log.Logger.Error(eex, "Failed to delete the school.");
                result = eex.ErrorCode;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Failed to delete the shool.");
                result = ErrorCodes.SaveFailure;
            }
            if(result==ErrorCodes.None)
            {
                List<MSchool> schools = SchoolRepository.GetAll();
                html = await ViewRenderService.RenderViewToStringAsync("~/Areas/Admin/Views/School/_List.cshtml", schools);
            }
            string msg = (result == ErrorCodes.None) ? StringLocalizer["I.HSP-M002.0005"].Value
                                                     : StringLocalizer[result.GetResourceKey()].Value;
            return Json(new { status = (result == ErrorCodes.None) ? Result.Success : Result.Failure, message = msg,html });
        }

        public async Task<JsonResult> Update(MSchool school, string id)
        {
            ErrorCodes result;
            string html = "";
            var schoolinfo = TempData.Get<MSchool>("schoolitem");
            schoolinfo.CopySchoolInfo(school);
            try
            {
                result = SchoolRepository.Update(ref schoolinfo, GetLogedinUser(), id);
                
            }
            catch (ENovateException eex)
            {
                Log.Logger.Error(eex, "Failed to update the school name: " + school.MsName);
                result = eex.ErrorCode;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Failed to update the shool.");
                result = ErrorCodes.SaveFailure;
            }
            if (result == ErrorCodes.None)
            {
                List<MSchool> schools = SchoolRepository.GetAll();
                html = await ViewRenderService.RenderViewToStringAsync("~/Areas/Admin/Views/School/_List.cshtml", schools);
                TempData.Put("AllSchools", schools);
            }
            string msg = (result == ErrorCodes.None) ? StringLocalizer["I.HSP-M002.0017"].Value
                                                     : StringLocalizer[result.GetResourceKey()].Value;
            return Json(new { status = (result == ErrorCodes.None) ? Result.Success : Result.Failure, message = msg, html });
        }
        [HttpPost]
        public async Task<JsonResult> Insert(MSchool school)
        {
            ErrorCodes result;
            string html = "";
            try
            {         
                result = SchoolRepository.Insert(ref school, GetLogedinUser());
            }
            catch (ENovateException eex)
            {
                Log.Logger.Error(eex, "Failed to insert the school name: " + school.MsName);
                result = eex.ErrorCode;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Failed to insert the shool.");
                result = ErrorCodes.SaveFailure;
            }
            if (result == ErrorCodes.None)
            {
                List<MSchool> schools = SchoolRepository.GetAll();
                html = await ViewRenderService.RenderViewToStringAsync("~/Areas/Admin/Views/School/_List.cshtml", schools);
                TempData.Put("AllSchools", schools);
            }
            string msg = (result == ErrorCodes.None) ? StringLocalizer["I.HSP-M002.0002"].Value
                                                     : StringLocalizer[result.GetResourceKey()].Value;
            return Json(new { status = (result == ErrorCodes.None) ? Result.Success : Result.Failure, message = msg, html });
        }
    }
}