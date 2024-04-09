using Newtonsoft.Json;

namespace Services.Entities
{
    public class CommentEntity 
    {
        [JsonProperty("CommentId")]
        public Guid CommentId { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }
    }
}
