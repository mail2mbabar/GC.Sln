﻿namespace DBmodels.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        public string Stage { get; set; }
        public string Text { get; set; }

        public virtual Project Project { get; set; }
        public virtual Member Member { get; set; }
    }

}

