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
    public async Task<ActionResult> CreateRoom(Room room)
    {
        if (! await roomService.AddRoom(room))
            return BadRequest();

        return Ok();
    }
}