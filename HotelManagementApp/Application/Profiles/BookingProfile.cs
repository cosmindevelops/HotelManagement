using Application.Bookings.Commands.Create;
using Application.Bookings.Commands.Delete;
using Application.Bookings.Commands.Update;
using Application.Bookings.DTO;
using Application.Bookings.Queries.GetBookingById;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingGetDTO>();
            CreateMap<BookingGetDTO, Booking>();
            CreateMap<Booking, BookingPutDTO>();
            CreateMap<BookingPutDTO, Booking>();
            CreateMap<BookingPostDTO, Booking>();
            CreateMap<Booking, BookingPostDTO>();
            CreateMap<Booking, CreateBookingCommand>();
            CreateMap<CreateBookingCommand, Booking>();
            CreateMap<Booking, UpdateBookingCommand>();
            CreateMap<UpdateBookingCommand, Booking>();
            CreateMap<Booking, DeleteBookingCommand>();
            CreateMap<DeleteBookingCommand, Booking>();
            CreateMap<Booking, GetBookingByIdQuery>();
            CreateMap<GetBookingByIdQuery, Booking>();
        }
    }

}