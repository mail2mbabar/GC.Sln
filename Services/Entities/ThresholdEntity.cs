using DBmodels.Models;
using Newtonsoft.Json;

namespace Services.Entities
{
    public class ThresholdEntity 
    
        {
            [JsonProperty("ThresholdId")]
            public long ThresholdId { get; set; }

            [JsonProperty("ProjectId")]
            public Guid ProjectId { get; set; }

            [JsonProperty("GroupId")]
            public Guid GroupId { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }

            [JsonProperty("CriterionId")]
            public long CriterionId { get; set; }

            [JsonProperty("Value")]
            public double Value { get; set; }

        
        }
}

