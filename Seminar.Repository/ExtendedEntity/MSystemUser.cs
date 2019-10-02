using Seminar.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seminar.Repository.Entity
{
    public partial class MSystemUser 
    {
        [NotMapped]
        public Authorities Authorities { get; set; }
        [NotMapped]
        public List<string> LsuaCcdCodeAuthorities { get; set; }
    }
}
