﻿using System.ComponentModel.DataAnnotations;

namespace API;

public class RegisterDto
{
    // can add [MaxLength(100)] for username lenght
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    [StringLength(8, MinimumLength = 4)]
    public string Password { get; set; } = string.Empty;
}
