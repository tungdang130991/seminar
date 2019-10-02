using System;
using System.Collections.Generic;

namespace Seminar.Repository.Entity
{
    public partial class MSchoolScheduleClosed
    {
        public int MsscId { get; set; }
        public DateTime MsscCreateDatetime { get; set; }
        public int MsscCreateMsuId { get; set; }
        public DateTime MsscUpdateDatetime { get; set; }
        public int MsscUpdateMsuId { get; set; }
        public DateTime? MsscDeleteDatetime { get; set; }
        public DateTime MsscClosedDate { get; set; }
    }
}
