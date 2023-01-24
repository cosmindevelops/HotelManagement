using Application.Guests.Commands.Create;
using Application.Guests.Commands.Delete;
using Application.Guests.Commands.Update;
using Application.Guests.DTO;
using Application.Guests.Queries.GetGuestById;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class GuestProfile : Profile
    {
        public GuestProfile()
        {
            CreateMap<Guest, GuestGetDTO>();
            CreateMap<GuestGetDTO, Guest>();
            CreateMap<CreateGuestCommand, Guest>();
            CreateMap<Guest, CreateGuestCommand>();
            CreateMap<GuestPostDTO, Guest>();
            CreateMap<Guest, GuestPostDTO>();
            CreateMap<UpdateGuestCommand, Guest>();
            CreateMap<Guest, UpdateGuestCommand>();
            CreateMap<GuestPutDTO, Guest>();
            CreateMap<Guest, GuestPutDTO>();
            CreateMap<DeleteGuestCommand, Guest>();
            CreateMap<GetGuestByIdQuery, Guest>();
            CreateMap<GuestAndBookingDTO, Guest>();
            CreateMap<Guest, GuestAndBookingDTO>();
        }
    }
}