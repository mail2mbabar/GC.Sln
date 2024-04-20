using Newtonsoft.Json;
using System;

namespace Services.Entities
{
    public class OptionEntity
    {
        [JsonProperty("OptionId")]
        public int OptionId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }

        [JsonProperty("ProjectId")]
        public Guid ProjectId { get; set; }
    }
}
