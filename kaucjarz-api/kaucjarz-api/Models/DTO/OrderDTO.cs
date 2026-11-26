using System.ComponentModel.DataAnnotations;

namespace kaucjarz_api.Models.DTO;

public record CreateOrderDto(
    [Required(ErrorMessage = "UserId is required")]
    [Range(1, int.MaxValue, ErrorMessage = "UserId must be greater than 0")]
    int? UserId,

    [Required(ErrorMessage = "City is required")]
    [MaxLength(50)]
    string City,

    [Required(ErrorMessage = "Street address is required")]
    [MaxLength(255)]
    string StreetAddress,

    [MaxLength(20)]
    string? FlatNr,

    [Required(ErrorMessage = "Estimated bottles count is required")]
    [Range(1, 10000, ErrorMessage = "Estimated bottles must be between 1 and 10000")]
    int? EstimatedBottles,

    [Required(ErrorMessage = "Pickup date is required")]
    DateOnly? PickupDate,

    [Required(ErrorMessage = "Pickup time slot is required")]
    [MaxLength(20)]
    string PickupTimeSlot,

    string? Details
);