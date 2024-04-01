using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBmodels.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        [ForeignKey("Group")]
        public int GroupID { get; set; }
        public Group Group { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
    }
}
