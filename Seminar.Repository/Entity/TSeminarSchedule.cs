using System;
using System.Collections.Generic;

namespace Seminar.Repository.Entity
{
    public partial class TSeminarSchedule
    {
        public int TssId { get; set; }
        public DateTime TssCreateDatetime { get; set; }
        public int TssCreateMsuId { get; set; }
        public DateTime TssUpdateDatetime { get; set; }
        public int TssUpdateMsuId { get; set; }
        public DateTime? TssDeleteDatetime { get; set; }
        public int TssTshId { get; set; }
        public DateTime TssScheduleDatetime { get; set; }
        public string TssCcdCodeVacancy { get; set; }
    }
}
