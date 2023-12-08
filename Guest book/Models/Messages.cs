using System.ComponentModel.DataAnnotations;

namespace Guest_book.Models
{
    public class Messages
    {
        [Key]
        public int MessageId { get; set; }
        
        public string Message { get; set; }

        public string MessageDate { get; set; }

        public int? UserId { get; set; }
        
        public User? Login { get; set; }

    }
}