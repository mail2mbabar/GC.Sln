using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Services.Entities
{
    public class GoalEntity
    {
        [Key]
        [JsonProperty("GoalId")]
        public long GoalId { get; set; }

        [Required]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ProjectId")]
        public Guid ProjectId { get; set; }

    }
}
