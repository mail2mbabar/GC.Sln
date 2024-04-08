using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBmodels.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public Project Project { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
