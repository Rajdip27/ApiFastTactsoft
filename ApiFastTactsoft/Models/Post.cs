namespace ApiFastTactsoft.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Decripation { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
