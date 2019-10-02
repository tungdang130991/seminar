using System;
using System.Collections.Generic;

namespace Seminar.Repository.Entity
{
    public partial class MLecture
    {
        public string MlCd { get; set; }
        public DateTime? MlCreateDatetime { get; set; }
        public DateTime? MlUpdateDatetime { get; set; }
        public DateTime? MlDeleteDatetime { get; set; }
        public string MlMpCd { get; set; }
        public string MlKbnKouzaKaiji { get; set; }
        public string MlKouzaName { get; set; }
        public string MlMsCd { get; set; }
        public string MlSchoolName { get; set; }
        public string MlClassCd { get; set; }
        public string MlClassName { get; set; }
        public string MlCategoryCd { get; set; }
        public string MlCategoryName { get; set; }
        public string MlKouzaDivisionCd { get; set; }
        public string MlKouzaDivisionName { get; set; }
        public string MlKbnSetProduct { get; set; }
        public string MlCcdCodeStatus { get; set; }
        public DateTime? MlScheduleDateStart { get; set; }
        public DateTime? MlScheduleDateEnd { get; set; }
        public TimeSpan? MlScheduleTimeStart { get; set; }
        public TimeSpan? MlScheduleTimeEnd { get; set; }
        public int? MlCapacity { get; set; }
        public int? MlLectureMonth { get; set; }
        public string MlKbnEntryZuiji { get; set; }
        public int? MlSort { get; set; }
        public string MlUrlKouza { get; set; }
        public string MlUrlSchool { get; set; }
        public string MlNote01 { get; set; }
        public string MlNote02 { get; set; }
        public int? MlDateUpdateMwbp { get; set; }
        public int? MlTimeUpdateMwbp { get; set; }
    }
}
