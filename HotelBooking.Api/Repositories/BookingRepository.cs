using HotelBooking.Api.Data;
using HotelBooking.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Api.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly HotelDbContext context;

    public BookingRepository(HotelDbContext context)
    {
        this.context = context;
    }

    public async Task<List<Booking>> GetAllAsync()
    {
        return await context.Bookings
            .Include(b => b.Room)
            .ToListAsync();
    }

    public async Task<Booking?> GetByIdAsync(int id)
    {
        return await context.Bookings
            .Include(b => b.Room)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task AddAsync(Booking booking)
    {
        context.Bookings.Add(booking);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Booking booking)
    {
        context.Bookings.Remove(booking);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task<bool> IsRoomBookedAsync(int roomId, DateTime checkIn, DateTime checkOut, int? excludeBookingId = null)
    {
        return await context.Bookings.AnyAsync(b =>
            b.RoomId == roomId &&
            b.Id != excludeBookingId &&
            checkIn < b.CheckOut &&
            checkOut > b.CheckIn);
    }

    public async Task<List<Booking>> GetRoomBookingsAsync(int roomId)
    {
        return await context.Bookings
            .Where(b => b.RoomId == roomId)
            .ToListAsync();
    }
}