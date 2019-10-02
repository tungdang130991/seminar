using System;
using System.Collections.Generic;

namespace Seminar.Repository.Entity
{
    public partial class MProduct
    {
        public string MpCd { get; set; }
        public DateTime MpCreateDatetime { get; set; }
        public DateTime MpUpdateDatetime { get; set; }
        public DateTime? MpDeleteDatetime { get; set; }
        public DateTime MpAcceptDatetime { get; set; }
        public string MpMcsCd { get; set; }
        public string MpCcdCodeAttendCourse { get; set; }
        public string MpName { get; set; }
        public short MpLectureCount { get; set; }
        public decimal MpLectureTime { get; set; }
        public short MpLectureTotalTime { get; set; }
        public decimal MpMonayEntry { get; set; }
        public decimal MpMonayEntryTax { get; set; }
        public decimal MpMonayLecture { get; set; }
        public decimal MpMonayLectureTax { get; set; }
        public string MpCcdCodeStatusBenefit { get; set; }
        public string MpCcdCodeStatusSupport { get; set; }
        public string MpCcdCodeStatusOrderPc { get; set; }
        public string MpCcdStatusOrderMb { get; set; }
        public string MpCcdCodeStatusProdut { get; set; }
        public string MpCcdStatusSale { get; set; }
    }
}
