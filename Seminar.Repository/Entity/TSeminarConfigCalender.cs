using System;
using System.Collections.Generic;

namespace Seminar.Repository.Entity
{
    public partial class TSeminarConfigCalender
    {
        public int TsccId { get; set; }
        public DateTime TsccCreateDatetime { get; set; }
        public int TsccCreateMsuId { get; set; }
        public DateTime TsccUpdateDatetime { get; set; }
        public int TsccUpdateMsuId { get; set; }
        public DateTime? TsccDeleteDatetime { get; set; }
        public int TsccTsId { get; set; }
        public TimeSpan? TsccSetTimeStart { get; set; }
        public TimeSpan? TsccSetTimeEnd { get; set; }
        public string TsccSetTimeInterval { get; set; }
    }
}
