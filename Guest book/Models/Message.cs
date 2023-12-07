namespace Guest_book.Models
{
    public class Message
    {

        public int Id { get; set; }
        
        public string? Messages { get; set; }

        public string? MessageDate { get; set; }

        public int Id_User { get; set; }

        public User? User { get; set; }
    }
}
