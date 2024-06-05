namespace Snackistwo.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int SubCategoryId { get; set; }
        public DateTime PostedOn { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; }
    }
}
