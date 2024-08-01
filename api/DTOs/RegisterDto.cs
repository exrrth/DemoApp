using System.ComponentModel.DataAnnotations;

namespace API;

public class RegisterDto
{
    // can add [MaxLength(100)] for username lenght
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Password { get; set; }
}
