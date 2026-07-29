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
    public async Task<ActionResult<PagedResponse<RoomResponseDto>>> GetRooms(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? sortBy = null,
        CancellationToken cancellationToken = default)
    {
        var result = await roomService.GetRooms(
            page,
            pageSize,
            sortBy,
            cancellationToken);

        return Ok(result);
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
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoom(int id, UpdateRoomDto dto)
    {
        var success = await roomService.UpdateRoom(id, dto);

        if (!success)
            return NotFound();

        return NoContent();
    }
    
    [HttpGet("available")]
    public async Task<ActionResult<List<RoomResponseDto>>> GetAvailableRooms(
        DateTime checkIn,
        DateTime checkOut)
    {
        var rooms = await roomService.GetAvailableRooms(
            checkIn,
            checkOut);

        var dto = mapper.Map<List<RoomResponseDto>>(rooms);

        return Ok(dto);
    }
}