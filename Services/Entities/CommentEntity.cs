using DBmodels.Models;
using Newtonsoft.Json;

namespace Services.Entities
{
    public class CommentEntity 
        {
            [JsonProperty("CommentId")]
            public Guid CommentId { get; set; }

            [JsonProperty("ProjectId")]
            public Guid ProjectId { get; set; }

            [JsonProperty("GroupId")]
            public Guid GroupId { get; set; }

            [JsonProperty("StageId")]
            public long StageId { get; set; }

            [JsonProperty("Text")]
            public string Text { get; set; }

            [JsonProperty("CreatedDate")]
            public DateTime CreatedDate { get; set; }

            [JsonProperty("UserId")]
            public Guid UserId { get; set; }
        
    }
}
