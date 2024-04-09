using Newtonsoft.Json;

namespace Services.Entities
{
    public class ThresholdEntity 
    {
        [JsonProperty("ThresholdId")]
        public long ThresholdId { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }

    }
}
