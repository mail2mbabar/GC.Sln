

using System.ComponentModel.DataAnnotations;

namespace DBmodels.Models
{
    public class GcAttribute
    {
        public int AttributeId { get; set; }
        [Required]
        public string Name { get; set; }

        // Foreign key property
        public int ProjectId { get; set; }
        public int CriterionId { get; set; }

        // Navigation property
        public Project Project { get; set; }
        public Criterion Criterion { get; set; }

    }
}
