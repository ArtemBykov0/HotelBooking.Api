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
        return await context.Bookings.ToListAsync();
    }

    public async Task<Booking?> GetByIdAsync(int id)
    {
        return await context.Bookings.FirstOrDefaultAsync(b => b.Id == id);
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
}