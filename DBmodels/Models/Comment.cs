using DBmodels.Models;

namespace DBmodels.Models
{
    public class Comment : BaseEntity
    {
        public Guid CommentId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid MemberId { get; set; }
        public long StageId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public Project Project { get; set; }
        public Group Member { get; set; }
        public Stage Stage { get; set; }
        public Guid UserId { get; set; }
    }

}

