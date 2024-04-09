using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBmodels.Models
{
    public class Evaluation : BaseEntity
    {
        public long EvaluationId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid MemberId { get; set; }
        public long OptionId { get; set; }
        public long CriterionId { get; set; }
        public double Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public Project Project { get; set; }
        public Group Member { get; set; }
        public Option Option { get; set; }
        public Criterion Criterion { get; set; }
    }
}
