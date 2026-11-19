using System.ComponentModel.DataAnnotations;

namespace kaucjarz_api.DTO;

public record CreateUserDto(
    [Required(ErrorMessage = "User name is required")]
    [MaxLength(50)]
    string Name,

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Wrong email format.")]
    string Email,

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password is required to be at least 6 characters long.")]
    string Password
);

public record LoginDto(
    [Required(ErrorMessage = "Enter login or email.")]
    string Login,

    [Required(ErrorMessage = "Password is required")]
    string Password
);

public record UserResponseDto(
    int Id,
    string Name,
    string Email
);