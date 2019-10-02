using System;
using System.Collections.Generic;

namespace Seminar.Repository.Entity
{
    public partial class MMeasurementTag
    {
        public int MmtId { get; set; }
        public DateTime MmtCreateDatetime { get; set; }
        public int MmtCreateMsuId { get; set; }
        public DateTime MmtUpdateDatetime { get; set; }
        public int MmtUpdateMsuId { get; set; }
        public DateTime? MmtDeleteDatetime { get; set; }
        public string MmtCcdCodeTypeSysfunction { get; set; }
        public string MmtHeadArea { get; set; }
        public string MmtBodyTop { get; set; }
        public string MmtBodyBottom { get; set; }
    }
}
