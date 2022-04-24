using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.Dtos;

public class LoginDto {
    [Required(ErrorMessage = "Email is required")]
    public string? email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}
