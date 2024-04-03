﻿using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBmodels.Models
{
    public class Evaluation
    {
        public int EvaluationId { get; set; }
        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        public int OptionId { get; set; }
        public int CriterionId { get; set; }
        public int Value { get; set; }

        public virtual Project Project { get; set; }
        public virtual Member Member { get; set; }
        public virtual Option Option { get; set; }
        public virtual Criterion Criterion { get; set; }
    }
}
