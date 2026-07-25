using HotelBooking.Api.Models;

public class Booking
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public Room Room { get; set; } = null!;

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }
}