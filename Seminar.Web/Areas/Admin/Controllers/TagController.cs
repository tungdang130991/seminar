using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Seminar.Common;
using Seminar.Common.Extensions;
using Seminar.Repository;
using Seminar.Repository.Entity;
using Seminar.Web.Attributes;
using Seminar.Web.Extensions;
using Serilog;
using System;

namespace Seminar.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorities(Authorities.SeminarManager)]
    public class TagController : CommonController
    {
        public ITagRepository TagRepository { get; set; }
        public AppSettings AppSettings { get; set; }
        public TagController(ITagRepository repository, IOptions<AppSettings> settings, 
            IStringLocalizer<Resources> localizer) : base(localizer)
        {
            TagRepository = repository;
            AppSettings = settings.Value;
        }

        public IActionResult Index(string tagType)
        {
            if (tagType.Equals(AppSettings.SeminarTagCodeType))
                ViewBag.Title = StringLocalizer["SeminarTagTittle"];
            else if (tagType.Equals(AppSettings.ProductTagCodeType))
                ViewBag.Title = StringLocalizer["ProductTagTittle"];
            else
                throw new ENovateException(ErrorCodes.PageNotExist);
            ViewBag.MaxlengthTag = AppSettings.MaxlengthTag;

            var tagInfo = TagRepository.GetMeasurementTag(tagType);
            if (tagInfo == null)
            {
                tagInfo = new MMeasurementTag
                {
                    MmtCcdCodeTypeSysfunction = tagType
                };
            }
            TempData.Put("TagInfo", tagInfo);
            return View(tagInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Save(MMeasurementTag newTagInfo)
        {
            ErrorCodes result;
            try
            {
                var tagInfo = TempData.Get<MMeasurementTag>("TagInfo");
                if(tagInfo == null)
                {
                    return Json(new { status = Result.Failure, message = StringLocalizer["I.HSP-M102.0004"].Value });
                }
                tagInfo.CopyTagInfo(newTagInfo);
                result = (tagInfo.MmtId != 0) ? TagRepository.Update(ref tagInfo, GetLogedinUser()) 
                                              : TagRepository.Insert(ref tagInfo, GetLogedinUser());
                TempData.Put("TagInfo", tagInfo);
            }
            catch (ENovateException eex)
            {
                Log.Logger.Error(eex, "Failed to save the measurement tag: " + newTagInfo.MmtCcdCodeTypeSysfunction);
                result = eex.ErrorCode;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Failed to save the measurement tag.");
                result = ErrorCodes.SaveFailure;
            }
            string msg = (result == ErrorCodes.None) ? StringLocalizer["I.HSP-M102.0003"].Value  
                                                     : StringLocalizer[result.GetResourceKey()].Value;
            return Json(new { status = (result == ErrorCodes.None) ? Result.Success : Result.Failure, message =  msg});
        }
    }
}