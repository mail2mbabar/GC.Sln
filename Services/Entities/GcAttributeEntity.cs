using Newtonsoft.Json;
using System;

namespace Services.Entities
{
    public class GcAttributeEntity
    {
        [JsonProperty("GcAttributeId")]
        public long GcAttributeId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }

        [JsonProperty("ProjectId")]
        public Guid ProjectId { get; set; }

        [JsonProperty("CriterionId")]
        public long CriterionId { get; set; }
    }
}
