using System;

namespace DataAccessLayer.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Text { get; set; }

        public virtual Task Task { get; set; }
        public int TaskId { get; set; }
        public virtual User Author { get; set; }
        public int AuthorId { get; set; }
        public virtual Attachment Attachments { get; set; }
    }
}
