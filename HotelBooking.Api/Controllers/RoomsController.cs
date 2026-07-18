using AutoMapper;
using HotelBooking.Api.DTOs;
using HotelBooking.Api.Models;
using HotelBooking.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomsController(
    IRoomService roomService,
    IMapper mapper) : ControllerBase
{
    private readonly IRoomService roomService = roomService;
    private readonly IMapper mapper = mapper;

    [HttpGet]
    public async Task<ActionResult<List<RoomResponseDto>>> GetRooms()
    {
        var rooms = await roomService.GetRooms();
        var dto =  mapper.Map<List<RoomResponseDto>>(rooms);
        return Ok(dto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoom(int id)
    {
        var room = await roomService.GetRoomById(id);

        if (room == null)
            return NotFound();

        var dto = mapper.Map<RoomResponseDto>(room);

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult> CreateRoom(CreateRoomDto dto)
    {
        var room = mapper.Map<Room>(dto);

        await roomService.AddRoom(room);

        return CreatedAtAction(
            nameof(GetRoom),
            new { id = room.Id },
            mapper.Map<RoomResponseDto>(room)
            );
    }
}