using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Seminar.Repository.Entity
{
    [ModelMetadataType(typeof(ISchoolMetadata))]
    public partial class MSchool : ISchoolMetadata
    {
        public void UpdateCreatingInfo(MSystemUser user)
        {
            MsCreateMsuId = user.MsuId;
            MsCreateDatetime = DateTime.Now;
            UpdateEditingInfo(user);

        }
        public void CopySchoolInfo(MSchool source)
        {
            MsCd = source.MsCd;
            MsName = source.MsName;
            MsNameEng = source.MsNameEng;
        }
        public void UpdateEditingInfo(MSystemUser user)
        {
            MsUpdateMsuId = user.MsuId;
            MsUpdateDatetime = DateTime.Now;
        }
    }
    public interface ISchoolMetadata
    {
        [Required(ErrorMessage = "E.HSP-0000.0005")]
        [MaxLength(6, ErrorMessage = "E.HSP-M102.0002")]
        [DisplayName("拠点コード")]
        string MsCd { get; set; }

        [Required(ErrorMessage = "E.HSP-0000.0005")]
        [MaxLength(50, ErrorMessage = "E.HSP-M102.0002")]
        [DisplayName("拠点名称")]
        string MsName { get; set; }

        [Required(ErrorMessage = "E.HSP-0000.0005")]
        [MaxLength(50, ErrorMessage = "E.HSP-M102.0002")]
        [DisplayName("拠点英語名称")]
        string MsNameEng { get; set; }
    }

}
