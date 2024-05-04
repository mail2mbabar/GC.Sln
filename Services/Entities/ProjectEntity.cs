using DBmodels.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Services.Entities
{
    public class ProjectEntity 
    {
            [JsonProperty("ProjectId")]
            [Key]
            public Guid ProjectId { get; set; }

            [JsonProperty("Name")]
            [Required]
            public string Name { get; set; }

            [JsonProperty("Description")]
            public string Description { get; set; }

            [JsonProperty("CreatedDate")]
            public DateTime CreatedDate { get; set; }

            [JsonProperty("CreatedBy")]
            public Guid CreatedBy { get; set; }

            [JsonProperty("UpdatedDate")]
            public DateTime UpdatedDate { get; set; }

            [JsonProperty("UpdatedBy")]
            public Guid UpdatedBy { get; set; }
        
    }
}
