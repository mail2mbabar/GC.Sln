using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBmodels.Models
{
    public class Call
    {
        [Key]
        public int CallID { get; set; }

        public int CallerID { get; set; }
        public User Caller { get; set; }

        public int ReceiverID { get; set; }
        public User Receiver { get; set; }

        public bool IsVideoCall { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
