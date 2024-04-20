

using System.ComponentModel.DataAnnotations;

namespace DBmodels.Models
{
    public class GcAttribute : BaseEntity
    {
        public long GcAttributeId { get; set; }
        [Required]
        public string Name { get; set; }
        public double Value { get; set; }

        // Foreign key property
        public Guid ProjectId { get; set; }
        public long CriterionId { get; set; }

        // Navigation property
        public virtual Project Project { get; set; }
        public virtual Criterion Criterion { get; set; }

    }
}
