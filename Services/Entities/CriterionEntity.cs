using Newtonsoft.Json;

namespace Services.Entities
{
    public class CriterionEntity
    {
        [JsonProperty("CriterionId")]
        public long CriterionId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }

        [JsonProperty("ProjectId")]
        public Guid ProjectId { get; set; }
    }
}
