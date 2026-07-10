using HotelBooking.Api.DTOs;
using HotelBooking.Api.Models;
using HotelBooking.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomsController(IRoomService roomService) : ControllerBase
{
    private readonly IRoomService roomService = roomService;

    [HttpGet]
    public async Task<List<Room>> GetRooms()
    {
        return await roomService.GetRooms();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoom(int id)
    {
        var room = await roomService.GetRoomById(id);
        if (room != null)
            return Ok(room);
        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> CreateRoom(CreateRoomDto dto)
    {
        var room = new Room()
        {
            Number = dto.Number,
            Price = dto.Price,
            Description = dto.Description,
            RoomClass =  dto.RoomClass
        };
        
        await roomService.AddRoom(room);

        return Ok();
    }
}