using Newtonsoft.Json;

namespace Services.Entities
{
    public class GroupEntity
    {
        [JsonProperty("GroupId")]
        public Guid GroupId { get; set; }

        [JsonProperty("GroupName")]
        public string GroupName { get; set; }

        [JsonProperty("ProjectId")]
        public Guid ProjectId { get; set; }

        [JsonProperty("UserId")]
        public Guid UserId { get; set; }

        [JsonProperty("RoleId")]
        public long RoleId { get; set; }

        [JsonProperty("CreatedBy")]
        public Guid CreatedBy { get; set; }

        [JsonProperty("UpdatedBy")]
        public Guid UpdatedBy { get; set; }

    }
}
