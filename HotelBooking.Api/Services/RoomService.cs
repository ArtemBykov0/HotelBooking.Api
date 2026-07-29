using HotelBooking.Api.DTOs;
using HotelBooking.Api.Models;
using HotelBooking.Api.Repositories;

namespace HotelBooking.Api.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository repository;    
    private readonly ILogger<RoomService> logger;
    
    public RoomService(
        IRoomRepository repository,
        ILogger<RoomService> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<bool> AddRoom(Room room)
    {
        if (room.Price <= 0)
        {
            logger.LogWarning(
                "Attempt to create room with invalid price: {Price}",
                room.Price);
            
            return false;
        }

        await repository.AddAsync(room);
        
        logger.LogInformation(
            "Room {RoomNumber} created successfully",
            room.Number);
        
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

    public async Task<bool> UpdateRoom(int id, UpdateRoomDto dto)
    {
        var room = await repository.GetByIdAsync(id);

        if (room == null)
            return false;

        room.Number = dto.Number;
        room.Price = dto.Price;
        room.Description = dto.Description;
        room.RoomClass = dto.RoomClass;

        await repository.UpdateAsync();

        return true;
    }

    public async Task<List<Room>> GetAvailableRooms(
        DateTime checkIn,
        DateTime checkOut)
    {
        return await repository.GetAvailableRoomsAsync(
            checkIn,
            checkOut);
    }

    public async Task<List<Room>> GetRoomsWithMinPrice(decimal minPrice)
    {
        var rooms = await repository.GetAllAsync();
        return rooms
            .Where(r => r.Price >= minPrice)
            .ToList();
    }
}