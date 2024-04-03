using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBmodels.Models
{
    public class Threshold
    {
        public int ThresholdId { get; set; }
        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        public string Type { get; set; }
        public int CriterionId { get; set; }
        public int Value { get; set; }

        public virtual Project Project { get; set; }
        public virtual Member Member { get; set; }
        public virtual Criterion Criterion { get; set; }

    }
}
