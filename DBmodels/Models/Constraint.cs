using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBmodels.Models
{
    public class Constraint
    {
        public int ConstraintId { get; set; }
        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        public int OptionId { get; set; }
        public int CriterionId { get; set; }
        public double Value { get; set; }

        public Project Project { get; set; }
        public Member Member { get; set; }
        public Option Option { get; set; }
        public Criterion Criterion { get; set; }
    }
}
