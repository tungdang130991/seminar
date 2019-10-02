using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Seminar.Common;
using Seminar.Repository;
using Seminar.Repository.Entity;
using Seminar.Web.Attributes;

namespace Seminar.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionTimeOut]
    [Authorities(Authorities.SchoolManager|Authorities.SeminarManager)]
    public class SeminarController : CommonController
    {
        public ISeminarRepository SeminarRepository { get; set; }

        public SeminarController(ISeminarRepository repository, IStringLocalizer<Resources> localizer):base(localizer)
        {
            SeminarRepository = repository;
        }

        public IActionResult GetData()
        {
            var model = new MSystemUser() {
                MsuName = StringLocalizer["Sample"].Value
            };
            
            return View(model);
        }
    }
}