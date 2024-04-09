using Newtonsoft.Json;

namespace Services.Entities
{
    public class GroupEntity
    {
        [JsonProperty("MemberId")]
        public Guid MemberId { get; set; }

        [JsonProperty("MemberName")]
        public string MemberName { get; set; }

        [JsonProperty("CreatedBy")]
        public Guid CreatedBy { get; set; }

        [JsonProperty("UpdatedBy")]
        public Guid UpdatedBy { get; set; }
    }
}
