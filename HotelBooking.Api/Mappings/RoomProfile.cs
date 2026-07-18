using AutoMapper;
using HotelBooking.Api.DTOs;
using HotelBooking.Api.Models;

namespace HotelBooking.Api.Mappings;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<CreateRoomDto, Room>();
    }
}