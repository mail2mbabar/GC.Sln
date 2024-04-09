namespace DBmodels.Models
{
    public class Threshold : BaseEntity
    {
        public long ThresholdId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid MemberId { get; set; }
        public string Type { get; set; }
        public long CriterionId { get; set; }
        public double Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public Project Project { get; set; }
        public Group Member { get; set; }
        public Criterion Criterion { get; set; }

    }
}
