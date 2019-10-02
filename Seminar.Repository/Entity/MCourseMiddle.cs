using System;
using System.Collections.Generic;

namespace Seminar.Repository.Entity
{
    public partial class MCourseMiddle
    {
        public string McmCd { get; set; }
        public DateTime McmCreateDatetime { get; set; }
        public int McmCreateMsuId { get; set; }
        public DateTime McmUpdateDatetime { get; set; }
        public int McmUpdateMsuId { get; set; }
        public DateTime? McmDeleteDatetime { get; set; }
        public string McmMclCd { get; set; }
        public string McmName { get; set; }
        public int McmSort { get; set; }
    }
}
