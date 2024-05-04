using DBmodels.Models;
using Newtonsoft.Json;

namespace Services.Entities
{
    public class ConstraintEntity 
    {
            [JsonProperty("ConstraintId")]
            public long ConstraintId { get; set; }

            [JsonProperty("ProjectId")]
            public Guid ProjectId { get; set; }

            [JsonProperty("GroupId")]
            public Guid GroupId { get; set; }

            [JsonProperty("OptionId")]
            public long OptionId { get; set; }

            [JsonProperty("CriterionId")]
            public long CriterionId { get; set; }

            [JsonProperty("Value")]
            public double Value { get; set; }
        }
}

