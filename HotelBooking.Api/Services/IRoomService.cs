using HotelBooking.Api.DTOs;
using HotelBooking.Api.Models;

namespace HotelBooking.Api.Services;

public interface IRoomService
{ 
    Task<bool> AddRoom(Room room);
    Task<Room> GetRoomById(int id);
    Task<PagedResponse<RoomResponseDto>> GetRooms(
        int page,
        int pageSize,
        CancellationToken cancellationToken);    Task<bool> UpdateRoomPrice(int id, decimal newPrice);
    Task<bool> DeleteRoom(int id);
    Task<bool> UpdateRoom(int id, UpdateRoomDto dto);
    Task<List<Room>> GetAvailableRooms(DateTime checkIn, DateTime checkOut);
    Task<List<Room>> GetRoomsWithMinPrice(decimal minPrice, CancellationToken cancellationToken);
    Task<PagedResponse<RoomResponseDto>> GetRooms(
        int page,
        int pageSize,
        string? sortBy,
        string? roomClass,
        CancellationToken cancellationToken);
}