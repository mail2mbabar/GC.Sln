using Newtonsoft.Json;
using System;

namespace Services.Entities
{
    public class UserEntity
    {
        [JsonProperty("UserId")]
        public Guid UserId { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("CreatedBy")]
        public Guid CreatedBy { get; set; }

        [JsonProperty("UpdatedBy")]
        public Guid UpdatedBy { get; set; }
    }
}
