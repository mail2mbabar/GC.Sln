
using System.ComponentModel.DataAnnotations;

namespace DBmodels.Models
{
    public class Criterion : BaseEntity
    {
        [Key]
        public long CriterionId { get; set; }

        [Required]
        public string Name { get; set; }
        public double Value { get; set; }

        // Foreign key property
        public Guid ProjectId { get; set; }

        // Navigation property
        public Project Project { get; set; }
        public ICollection<GcAttribute> GcAttributes { get; set; }
    }
}
