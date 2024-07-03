using System.ComponentModel.DataAnnotations;

namespace HahnCargoSimBack.Models;

public class UserAuthenticate
{
    [Required]
    [MinLength(1)]
    public string Username { get; set; }

    [Required]
    [MinLength(1)]
    public string Password { get; set; }
}