namespace DBmodels.Models
{
    public class Threshold : BaseEntity
    {
        public long ThresholdId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid GroupId { get; set; }
        public string Type { get; set; }
        public long CriterionId { get; set; }
        public double Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public Project Project { get; set; }
        public virtual Group Group { get; set; }
        public virtual Criterion Criterion { get; set; }

    }
}
