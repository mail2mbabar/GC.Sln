namespace DBmodels.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Group : BaseEntity
    {
        [Key]
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public long RoleId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatededDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
 
    }
}
