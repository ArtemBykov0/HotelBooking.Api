using AutoMapper;
using HotelBooking.Api.DTOs;

namespace HotelBooking.Api.Mappings;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<Booking, BookingResponseDto>();
        CreateMap<CreateBookingDto, Booking>();
    }
}