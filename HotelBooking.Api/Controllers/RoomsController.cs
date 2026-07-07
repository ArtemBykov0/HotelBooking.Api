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
    public List<Room> GetRooms()
    {
        return roomService.GetRooms();
    }

    [HttpGet("{id}")]
    public IActionResult GetRoom(int id)
    {
        var room = roomService.GetRoomById(id);
        if (room != null)
            return Ok(room);
        return NotFound();
    }

    [HttpPost]
    public ActionResult CreateRoom(Room room)
    {
        if (!roomService.AddRoom(room))
            return BadRequest();

        return Ok();
    }
}