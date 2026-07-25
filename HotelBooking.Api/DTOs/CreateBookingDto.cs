using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Api.DTOs;

public class CreateBookingDto
{
    [Required]
    public int RoomId { get; set; }

    [Required]
    public DateTime CheckIn { get; set; }

    [Required]
    public DateTime CheckOut { get; set; }

    [Required] 
    [MaxLength(100)]
    public string GuestName { get; set; } = "";
}