using System;
using System.Collections.Generic;

namespace Seminar.Repository.Entity
{
    public partial class MCourseSmall
    {
        public string McsCd { get; set; }
        public DateTime McsCreateDatetime { get; set; }
        public int McsCreateMsuId { get; set; }
        public DateTime McsUpdateDatetime { get; set; }
        public int McsUpdateMsuId { get; set; }
        public DateTime? McsDeleteDatetime { get; set; }
        public string McsMcmCd { get; set; }
        public string McsName { get; set; }
        public int McsSort { get; set; }
    }
}
