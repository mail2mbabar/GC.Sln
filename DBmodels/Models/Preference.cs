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
        public Guid ProjectId { get; set; }
        public Guid GroupId { get; set; }
        public long CriterionId1 { get; set; }
        public long CriterionId2 { get; set; }
        public double Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Project Project { get; set; }
        public virtual Group Member { get; set; }
        public virtual Criterion Criterion1 { get; set; }
        public virtual Criterion Criterion2 { get; set; }
    }
}
