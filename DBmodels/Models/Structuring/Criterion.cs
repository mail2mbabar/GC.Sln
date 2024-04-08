
using System.ComponentModel.DataAnnotations;

namespace DBmodels.Models
{
    public class Criterion
    {
        [Key]
        public int CriterionId { get; set; }

        [Required]
        public string Name { get; set; }

        // Foreign key property
        public int ProjectId { get; set; }

        // Navigation property
        public Project Project { get; set; }
        public ICollection<GcAttribute> GcAttributes { get; set; }
    }
}
