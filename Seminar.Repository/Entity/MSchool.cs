using System;
using System.Collections.Generic;

namespace Seminar.Repository.Entity
{
    public partial class MSchool
    {
        public string MsCd { get; set; }
        public DateTime? MsCreateDatetime { get; set; }
        public int? MsCreateMsuId { get; set; }
        public DateTime? MsUpdateDatetime { get; set; }
        public int? MsUpdateMsuId { get; set; }
        public DateTime? MsDeleteDatetime { get; set; }
        public string MsName { get; set; }
        public string MsNameEng { get; set; }
    }
}
