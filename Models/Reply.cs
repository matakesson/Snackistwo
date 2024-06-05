namespace Snackistwo.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int TopicId { get; set; }
        public DateTime PostedOn { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsReported { get; set; }
        public string? ReportMessage { get; set; }
        //public SnackistwoUser User { get; set; }

    }
}
