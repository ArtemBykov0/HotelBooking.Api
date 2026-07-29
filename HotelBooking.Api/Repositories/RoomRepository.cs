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

    public async Task<List<Room>> GetAllAsync(
        int page,
        int pageSize,
        string? sortBy,
        string? roomClass,
        int? number,
        CancellationToken cancellationToken)
    {
        var query = context.Rooms.AsQueryable();

        // Фильтрация
        if (!string.IsNullOrWhiteSpace(roomClass))
        {
            query = query.Where(r => r.RoomClass == roomClass);
        }
        
        if (number.HasValue)
        {
            query = query.Where(r => r.Number == number.Value);
        }

        // Сортировка
        if (sortBy == "price")
        {
            query = query.OrderBy(r => r.Price);
        }
        else if (sortBy == "price_desc")
        {
            query = query.OrderByDescending(r => r.Price);
        }
        else if (sortBy == "number")
        {
            query = query.OrderBy(r => r.Number);
        }

        // Пагинация
        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync()
    {
        return await context.Rooms.CountAsync();
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
    
    public async Task<List<Room>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        return await context.Rooms
            .ToListAsync(cancellationToken);
    }
}