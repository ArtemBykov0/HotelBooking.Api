using HotelBooking.Api.Models;

namespace HotelBooking.Api.Repositories;

public interface IBookingRepository
{
    Task<List<Booking>> GetAllAsync();

    Task<Booking?> GetByIdAsync(int id);

    Task AddAsync(Booking booking);

    Task DeleteAsync(Booking booking);

    Task UpdateAsync();
    
    Task<bool> IsRoomBookedAsync(int roomId, DateTime checkIn, DateTime checkOut);
}