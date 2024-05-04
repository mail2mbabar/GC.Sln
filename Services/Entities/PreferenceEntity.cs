using DBmodels.Models;
using Newtonsoft.Json;
using System;

namespace Services.Entities
{
    public class PreferenceEntity 
    {
        [JsonProperty("PreferenceId")]
        public long PreferenceId { get; set; }

        [JsonProperty("ProjectId")]
        public long ProjectId { get; set; }

        [JsonProperty("GroupId")]
        public Guid GroupId { get; set; }

        [JsonProperty("CriterionId1")]
        public long CriterionId1 { get; set; }

        [JsonProperty("CriterionId2")]
        public long CriterionId2 { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }

    }
}
