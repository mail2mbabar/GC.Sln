using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBmodels.Models
{
    public class Preference : BaseEntity
    {
        public long PreferenceId { get; set; }
        public long ProjectId { get; set; }
        public Guid MemberId { get; set; }
        public long CriterionId1 { get; set; }
        public long CriterionId2 { get; set; }
        public double Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public Project Project { get; set; }
        public Member Member { get; set; }
        public Criterion Criterion1 { get; set; }
        public Criterion Criterion2 { get; set; }
    }
}
