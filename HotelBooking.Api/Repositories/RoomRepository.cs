using HotelBooking.Api.Data;
using HotelBooking.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Api.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly HotelDbContext context;

    public RoomRepository(HotelDbContext context)
    {
        this.context = context;
    }

    public async Task<List<Room>> GetAllAsync()
    {
        return await context.Rooms.ToListAsync();
    }

    public async Task<Room?> GetByIdAsync(int id)
    {
        return await context.Rooms.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task AddAsync(Room room)
    {
        context.Rooms.Add(room);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Room room)
    {
        context.Rooms.Remove(room);
        await context.SaveChangesAsync();
    }

    public async Task<List<Room>> GetAvailableRoomsAsync(
        DateTime checkIn,
        DateTime checkOut)
    {
        return await context.Rooms
            .Include(r => r.Bookings)
            .Where(room => !room.Bookings.Any(booking =>
                checkIn < booking.CheckOut &&
                checkOut > booking.CheckIn))
            .ToListAsync();
    }
}