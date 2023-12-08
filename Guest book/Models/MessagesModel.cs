using System.ComponentModel.DataAnnotations;

namespace Guest_book.Models
{
    public class MessagesModel
    {

        [Required]
        public User? Name { get; set; }

        public ICollection<Messages>? Messages { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string MessageDate { get; set; }

        [Required]
        public int? UserId { get; set; }


    }
}
