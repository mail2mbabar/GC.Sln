using Newtonsoft.Json;


namespace Services.Entities
{
    public class ProjectEntity 
    {
        [JsonProperty("ProjectId")]
        public Guid ProjectId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}
