using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBmodels.Models
{
    public class Preference
    {
        public int PreferenceId { get; set; }
        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        public int CriterionId1 { get; set; }
        public int CriterionId2 { get; set; }
        public int Value { get; set; }

        public Project Project { get; set; }
        public Member Member { get; set; }
        public Criterion Criterion1 { get; set; }
        public Criterion Criterion2 { get; set; }
    }
}
