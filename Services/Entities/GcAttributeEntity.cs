using Newtonsoft.Json;

namespace Services.Models
{
    public class GcAttributeEntity 
    {
        [JsonProperty("GcAttributeId")]
        public long GcAttributeId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }
    }
}
