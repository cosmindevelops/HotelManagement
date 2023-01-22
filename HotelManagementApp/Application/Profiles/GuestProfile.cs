using Application.Guests.Commands.Create;
using Application.Guests.Commands.Delete;
using Application.Guests.Commands.Update;
using Application.Guests.DTO;
using Application.Guests.Queries.GetAllGuests;
using Application.Guests.Queries.GetGuestById;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }
    }
}
