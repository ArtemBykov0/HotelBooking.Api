using HotelBooking.Api.Models;
using HotelBooking.Api.Repositories;

namespace HotelBooking.Api.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository repository;    
    public RoomService(IRoomRepository repository)
    {
        this.repository = repository;
    }

    public async Task<bool> AddRoom(Room room)
    {
        if (room.Price <= 0)
            return false;

        await repository.AddAsync(room);
        return true;
    }

    public async Task<Room?> GetRoomById(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<List<Room>> GetRooms()
    {
        return await repository.GetAllAsync();
    }

    public async Task<bool> UpdateRoomPrice(int id, decimal newPrice)
    {
        var room = await repository.GetByIdAsync(id);

        if (room == null)
            return false;

        room.Price = newPrice;

        await repository.UpdateAsync();

        return true;
    }

    public async Task<bool> DeleteRoom(int id)
    {
        var room = await repository.GetByIdAsync(id);

        if (room == null)
            return false;

        await repository.DeleteAsync(room);

        return true;
    }

    public async Task<List<Room>> GetRoomsWithMinPrice(decimal minPrice)
    {
        var rooms = await repository.GetAllAsync();
        return rooms
            .Where(r => r.Price >= minPrice)
            .ToList();
    }
}