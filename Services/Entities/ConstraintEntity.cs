using Newtonsoft.Json;

namespace Services.Entities
{
    public class ConstraintEntity 
    {
        [JsonProperty("ConstraintId")]
        public long ConstraintId { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }
    }
}
