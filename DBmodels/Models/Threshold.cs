namespace DBmodels.Models
{
    public class Threshold
    {
        public int ThresholdId { get; set; }
        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        public string Type { get; set; }
        public int CriterionId { get; set; }
        public int Value { get; set; }

        public Project Project { get; set; }
        public Member Member { get; set; }
        public Criterion Criterion { get; set; }

    }
}
