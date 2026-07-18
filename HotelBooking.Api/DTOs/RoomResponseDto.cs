namespace HotelBooking.Api.DTOs;

public class RoomResponseDto
{
    public int Id { get; set; }

    public int Number { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public string RoomClass { get; set; } = string.Empty;
}