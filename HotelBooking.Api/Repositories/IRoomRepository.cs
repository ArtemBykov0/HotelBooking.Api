using HotelBooking.Api.Models;

namespace HotelBooking.Api.Repositories;

public interface IRoomRepository
{
    Task<List<Room>> GetAllAsync();

    Task<Room?> GetByIdAsync(int id);

    Task AddAsync(Room room);

    Task UpdateAsync();

    Task DeleteAsync(Room room);
    
    Task<List<Room>> GetAvailableRoomsAsync(
        DateTime checkIn,
        DateTime checkOut);
}