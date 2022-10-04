using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MemeChat.Models
{
    public class Message
    {
        [Key]
        public long Id { get; set; }
        [MaybeNull]
        public string? URL { get; set; }
        [MaybeNull]
        public string? Base64String { get; set; }
        public DateTime SendAt { get; set; } = DateTime.UtcNow;
    }
}
