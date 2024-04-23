using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Entities
{
    public class OptionEntity
    {
        [JsonProperty("OptionId")]
        public int OptionId { get; set; }

        [Required]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }

        [JsonProperty("ProjectId")]
        public Guid ProjectId { get; set; }

    }
}
