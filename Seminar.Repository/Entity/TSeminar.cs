using System;
using System.Collections.Generic;

namespace Seminar.Repository.Entity
{
    public partial class TSeminar
    {
        public int TsId { get; set; }
        public DateTime TsCreateDatetime { get; set; }
        public int TsCreateMsuId { get; set; }
        public DateTime TsUpdateDatetime { get; set; }
        public int TsUpdateMsuId { get; set; }
        public DateTime? TsDeleteDatetime { get; set; }
        public string TsMsCd { get; set; }
        public string TsMclCd { get; set; }
        public string TsMcmCd { get; set; }
        public string TsMcsCd { get; set; }
        public string TsCcdCodePublish { get; set; }
        public DateTime TsPublishDatetimeStart { get; set; }
        public DateTime TsPublishDatetimeEnd { get; set; }
        public string TsName { get; set; }
        public string TsContents { get; set; }
        public string TsThumbnailUrl { get; set; }
        public string TsCcdCodeScheduleCtl { get; set; }
        public string TsCcdCodeInputtypeDate { get; set; }
    }
}
