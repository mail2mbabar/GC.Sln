using Newtonsoft.Json;

namespace Services.Entities
{
    public class GoalEntity 
    {
        [JsonProperty("GoalId")]
        public long GoalId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

    }
}
