using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBmodels.Models;

namespace DBmodels.Models
{
    public class Group
    {
        [Key]
        public int GroupID { get; set; }

        [Required]
        public string GroupName { get; set; }

        public ICollection<Member> Members { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Call> Calls { get; set; }
    }

}

