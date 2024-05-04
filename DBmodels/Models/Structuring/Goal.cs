
using System.ComponentModel.DataAnnotations;

namespace DBmodels.Models
{
    public class Goal : BaseEntity
    {
        [Key]
        public long GoalId { get; set; }

        [Required]
        public string Name { get; set; }

        // Foreign key property
        public Guid ProjectId { get; set; }

        // Navigation property
        public virtual Project Project { get; set; }
    }
}
