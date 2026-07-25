namespace HotelBooking.Api.DTOs;

public class BookingResponseDto
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }
    
    public int RoomNumber { get; set; }

    public string RoomClass { get; set; } = string.Empty;
}