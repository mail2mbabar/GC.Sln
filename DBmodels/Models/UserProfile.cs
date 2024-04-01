using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBmodels.Models
{
    public class UserProfile
    {
        [Key]
        public int UserProfileID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}
