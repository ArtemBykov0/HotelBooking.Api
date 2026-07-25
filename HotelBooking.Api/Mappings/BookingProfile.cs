using AutoMapper;
using HotelBooking.Api.DTOs;
using HotelBooking.Api.Models;

namespace HotelBooking.Api.Mappings;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<UpdateBookingDto, Booking>();
        
        CreateMap<CreateBookingDto, Booking>();

        CreateMap<Booking, BookingResponseDto>()
            .ForMember(dest => dest.RoomNumber,
                opt => opt.MapFrom(src => src.Room.Number))
            .ForMember(dest => dest.RoomClass,
                opt => opt.MapFrom(src => src.Room.RoomClass));
    }
}