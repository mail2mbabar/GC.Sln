using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBmodels.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        // User authentication fields
        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Email { get; set; }
        public ICollection<Member> Groups { get; set; }
        public ICollection<Message> SentMessages { get; set; }
    }
}
