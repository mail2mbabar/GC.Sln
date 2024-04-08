using DBmodels.Models;

namespace DBmodels.Models
{
    public class Comment : BaseEntity
    {
        public int CommentId { get; set; }
        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        public int StageId { get; set; }
        public string Text { get; set; }
        public Project Project { get; set; }
        public Member Member { get; set; }
        public Stage Stage { get; set; }
    }

}

