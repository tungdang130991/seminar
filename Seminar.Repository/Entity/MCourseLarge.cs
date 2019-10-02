using System;
using System.Collections.Generic;

namespace Seminar.Repository.Entity
{
    public partial class MCourseLarge
    {
        public string MclCd { get; set; }
        public DateTime MclCreateDatetime { get; set; }
        public int MclCreateMsuId { get; set; }
        public DateTime MclUpdateDatetime { get; set; }
        public int MclUpdateMsuId { get; set; }
        public DateTime? MclDeleteDatetime { get; set; }
        public string MclName { get; set; }
        public int MclSort { get; set; }
    }
}
