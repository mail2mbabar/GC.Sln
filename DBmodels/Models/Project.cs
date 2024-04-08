using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBmodels.Models;

namespace DBmodels.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        // Navigation property for the one-to-many relationship
        public ICollection<Criterion> Criterias { get; set; }
        public ICollection<Option> Options { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public ICollection<GcAttribute> GcAttributes { get; set; }
    }
}
