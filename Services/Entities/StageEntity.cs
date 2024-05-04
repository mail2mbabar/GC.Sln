using Newtonsoft.Json;
using System;

namespace Services.Entities
{
    public class StageEntity 
    {
        [JsonProperty("StageId")]
        public long StageId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

    }
}
