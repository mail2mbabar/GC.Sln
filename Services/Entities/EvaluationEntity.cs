using Newtonsoft.Json;

namespace Services.Entities
{ 
    public class EvaluationEntity 
    {
        [JsonProperty("EvaluationId")]
        public long EvaluationId { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }

    }
}
