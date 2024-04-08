﻿

using System.ComponentModel.DataAnnotations;

namespace DBmodels.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        [Required]
        public string Name { get; set; }
        public double Value { get; set; }

        // Foreign key property
        public int ProjectId { get; set; }

        // Navigation property
        public Project Project { get; set; }

    }
}
