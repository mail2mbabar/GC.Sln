
using System.ComponentModel.DataAnnotations;

namespace DBmodels.Models
{
    public class Goal
    {
        [Key]
        public int GoalId { get; set; }

        [Required]
        public string Name { get; set; }

        // Foreign key property
        public int ProjectId { get; set; }

        // Navigation property
        public Project Project { get; set; }
    }
}
