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
    public class Project : BaseEntity
    {
        [Key]
        public Guid ProjectId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatededDate { get; set; }
        public Guid UpdatedBy { get; set; }

        // Navigation property for the one-to-many relationship
        public ICollection<Criterion> Criterions { get; set; }
        public ICollection<Option> Options { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public ICollection<GcAttribute> GcAttributes { get; set; }
        public ICollection<Member> Members { get; set; }
    }
}
