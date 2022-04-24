using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.Dtos;

public class RegisterDto {

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }

}
