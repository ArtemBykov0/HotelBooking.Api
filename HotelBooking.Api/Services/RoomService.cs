using HotelBooking.Api.Data;
using HotelBooking.Api.Models;

namespace HotelBooking.Api.Services;

public class RoomService : IRoomService
{
    private readonly HotelDbContext context;
    
    public RoomService(HotelDbContext context)
    {
        this.context = context;
    }

    public bool AddRoom(Room room)
    {
        if (room.Price <= 0)
            return false;

        context.Rooms.Add(room);
        context.SaveChanges();

        return true;
    }

    public Room GetRoomById(int id)
    {
        return context.Rooms.FirstOrDefault(room => room.Id == id);
    }

    public List<Room> GetRooms()
    {
        return context.Rooms.ToList();
    }
}