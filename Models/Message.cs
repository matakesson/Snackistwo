namespace Snackistwo.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string SenderName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SentOn { get; set; } = DateTime.Now;
        public string RecipientId { get; set; }
        public string RecipientName { get; set; }

    }
}
