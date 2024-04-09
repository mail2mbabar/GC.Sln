using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBmodels.Models
{
    public class Group : BaseEntity
    {
        [Key]
        public Guid MemberId { get; set; }
        public string MemberName { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public long RoleId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatededDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public Project Project { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
