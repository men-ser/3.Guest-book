namespace Guest_book.Models
{
    public class User
    {
            public int Id { get; set; }

            public string? Login { get; set; }

            public string? Password { get; set; }

            public ICollection<Message>? Messages { get; set; }

    }
}
