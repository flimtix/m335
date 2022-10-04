using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MemeChat.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Nickname { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [StringLength(maximumLength: 50, MinimumLength = 4)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 100, MinimumLength = 12)]
        public string Password { get; set; } = string.Empty;
        [MaybeNull]
        [DataType(DataType.ImageUrl)]
        public string? Avatar { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string About { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        internal DateTime CreatedAd { get; set; } = DateTime.UtcNow;
    }
}
