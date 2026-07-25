using AutoMapper;
using HotelBooking.Api.DTOs;
using HotelBooking.Api.Models;
using HotelBooking.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController(
    IBookingService bookingService,
    IMapper mapper) : ControllerBase
{
    private readonly IBookingService bookingService = bookingService;
    private readonly IMapper mapper = mapper;

    [HttpGet]
    public async Task<ActionResult<List<Booking>>> GetBookings()
    {
        var bookings = await bookingService.GetBookings();
        return Ok(bookings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Booking>> GetBooking(int id)
    {
        var booking = await bookingService.GetBookingById(id);

        if (booking == null)
            return NotFound();

        var dtos = mapper.Map<List<BookingResponseDto>>(booking);

        return Ok(dtos);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        var result = await bookingService.DeleteBooking(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateBooking(Booking booking)
    {
        var result = await bookingService.CreateBooking(booking);

        if (!result)
            return BadRequest("Комната уже занята.");

        return Created();
    }
    
    [HttpGet("room/{roomId}")]
    public async Task<ActionResult<List<Booking>>> GetRoomBookings(int roomId)
    {
        var bookings = await bookingService.GetRoomBookings(roomId);
        var dto = mapper.Map<BookingResponseDto>(bookings);

        return Ok(dto);
    }
}