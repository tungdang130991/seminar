using System;
using System.Collections.Generic;

namespace Seminar.Repository.Entity
{
    public partial class MSystemUser
    {
        public int MsuId { get; set; }
        public DateTime MsuCreateDatetime { get; set; }
        public int MsuCreateMsuId { get; set; }
        public DateTime MsuUpdateDatetime { get; set; }
        public int MsuUpdateMsuId { get; set; }
        public DateTime? MsuDeleteDatetime { get; set; }
        public string MsuName { get; set; }
        public string MsuCcdCodeAccountType { get; set; }
        public string MsuMsCd { get; set; }
        public string MsuLoginId { get; set; }
        public string MsuLoginPasswd { get; set; }
    }
}
