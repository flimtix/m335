using System.ComponentModel.DataAnnotations;

namespace MemeChat.Database.Interfaces
{
    public interface ILoginCredentials
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        string Nickname { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 100, MinimumLength = 12)]
        string Password { get; set; }
    }
}
