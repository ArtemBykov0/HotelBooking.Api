using HotelBooking.Api.Models;

namespace HotelBooking.Api.Services;

public interface IBookingService
{
    Task<bool> CreateBooking(Booking booking);

    Task<Booking?> GetBookingById(int id);

    Task<List<Booking>> GetBookings();

    Task<bool> DeleteBooking(int id);
    
    Task<List<Booking>> GetRoomBookings(int roomId);
}