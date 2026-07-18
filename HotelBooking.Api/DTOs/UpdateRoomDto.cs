using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Api.DTOs;

public class UpdateRoomDto
{
    [Range(1, int.MaxValue)]
    public int Number { get; set; }

    [Range(1, int.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string RoomClass { get; set; } = string.Empty;
}