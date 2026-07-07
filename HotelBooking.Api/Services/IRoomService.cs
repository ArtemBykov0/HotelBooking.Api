using HotelBooking.Api.Models;

namespace HotelBooking.Api.Services;

public interface IRoomService
{ 
    bool AddRoom(Room room);
    Room GetRoomById(int id);
    List<Room> GetRooms();
}