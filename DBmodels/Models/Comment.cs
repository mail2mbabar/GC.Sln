using DBmodels.Models;

namespace DBmodels.Models
{
    public class Comment : BaseEntity
    {
        public Guid CommentId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid GroupId { get; set; }
        public long StageId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Group Group { get; set; }
        public virtual Stage Stage { get; set; }
        public Guid UserId { get; set; }
    }

}

