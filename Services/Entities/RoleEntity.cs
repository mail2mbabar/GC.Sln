namespace Services.Entities
{
    using Newtonsoft.Json;
    public class RoleEntity
    {
        [JsonProperty("RoleID")]
        public long RoleId { get; set; }

        [JsonProperty("RoleName")]
        public string RoleName { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}
