using HotelBooking.Api.Models;

namespace HotelBooking.Api.Services;

public interface IRoomService
{ 
    Task<bool> AddRoom(Room room);
    Task<Room> GetRoomById(int id);
    Task<List<Room>> GetRooms();
    Task<bool> UpdateRoomPrice(int id, decimal newPrice);
    Task<bool> DeleteRoom(int id);
}