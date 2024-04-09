using Newtonsoft.Json;
using System;

namespace Services.Entities
{
    public class PreferenceEntity 
    {
        [JsonProperty("PreferenceId")]
        public long PreferenceId { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }
    }
}
