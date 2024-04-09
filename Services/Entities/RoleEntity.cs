using Newtonsoft.Json;

namespace Services.Entities
{
    public class RoleEntity 
    {
        [JsonProperty("RoleId")]
        public long RoleId { get; set; }

        [JsonProperty("RoleName")]
        public string RoleName { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}
