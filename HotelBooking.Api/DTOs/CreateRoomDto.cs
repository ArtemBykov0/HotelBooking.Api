using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Api.DTOs;

public class CreateRoomDto
{
    [Range(1, int.MaxValue)]
    public int Number { get; set; }

    [Range(1, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string RoomClass { get; set; } = string.Empty;
}