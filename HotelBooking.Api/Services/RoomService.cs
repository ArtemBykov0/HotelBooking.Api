using HotelBooking.Api.Data;
using HotelBooking.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Api.Services;

public class RoomService : IRoomService
{
    private readonly HotelDbContext context;
    
    public RoomService(HotelDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> AddRoom(Room room)
    {
        if (room.Price <= 0)
            return false;

        context.Rooms.Add(room);

        await context.SaveChangesAsync();

        return true;
    }

    public Task<Room> GetRoomById(int id)
    {
        return context.Rooms.FirstOrDefaultAsync(room => room.Id == id);
    }

    public async Task<List<Room>> GetRooms()
    {
        return await context.Rooms.ToListAsync();
    }

    public async Task<bool> UpdateRoomPrice(int id, decimal newPrice)
    {
        var room = await GetRoomById(id);

        if (room == null)
            return false;

        room.Price = newPrice;

        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteRoom(int id)
    {
        var room = await GetRoomById(id);

        if (room == null)
            return false;

        context.Rooms.Remove(room);

        await context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Room>> GetRoomsWithMinPrice(decimal minPrice)
    {
        return await context.Rooms.Where(r => r.Price >= minPrice).ToListAsync();
    }
}