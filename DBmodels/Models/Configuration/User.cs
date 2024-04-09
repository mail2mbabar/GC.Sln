namespace DBmodels.Models
{
    using System.ComponentModel.DataAnnotations;
    public class User : BaseEntity
    {
        [Key]
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }

        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Group> Members { get; set; }

    }

}

