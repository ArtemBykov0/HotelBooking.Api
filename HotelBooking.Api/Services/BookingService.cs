using HotelBooking.Api.Models;
using HotelBooking.Api.Repositories;

namespace HotelBooking.Api.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository repository;

    public BookingService(IBookingRepository repository)
    {
        this.repository = repository;
    }
    
    public async Task<bool> CreateBooking(Booking booking)
    {
        var isBooked = await repository.IsRoomBookedAsync(
            booking.RoomId,
            booking.CheckIn,
            booking.CheckOut);

        if (isBooked)
            return false;

        await repository.AddAsync(booking);

        return true;
    }

    public async Task<Booking?> GetBookingById(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<List<Booking>> GetBookings()
    {
        return await repository.GetAllAsync();
    }

    public async Task<bool> DeleteBooking(int id)
    {
        var booking = await repository.GetByIdAsync(id);

        if (booking == null)
            return false;

        await repository.DeleteAsync(booking);

        return true;
    }
}