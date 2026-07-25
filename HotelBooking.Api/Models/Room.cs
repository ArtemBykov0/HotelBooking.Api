namespace HotelBooking.Api.Models;

public class Room
{
    public int Id { get; set; }
    public int Number { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string RoomClass { get; set; }
    public List<Booking> Bookings { get; set; } = [];
}