using System.ComponentModel.DataAnnotations;

namespace MemeChat.Models
{
    public class Message
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string URL { get; set; }
        [Required]
        public User SendBy { get; set; }
        public DateTime SendAt { get; set; } = DateTime.UtcNow;

        public Message Clone()
        {
            return new Message()
            {
                URL = URL,
                SendBy = SendBy,
                SendAt = SendAt
            };
        }
    }
}
