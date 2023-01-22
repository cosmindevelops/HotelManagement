using Application.Rooms.Commands.Create;
using Application.Rooms.Commands.Update;
using Application.Rooms.DTO;
using Application.Rooms.Queries.GetAllRooms;
using Application.Rooms.Queries.GetRoomById;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<CreateRoomCommand, RoomPostDTO>();
            CreateMap<UpdateRoomCommand, RoomPutDTO>();
            //CreateMap<Room, RoomGetDTO>()
            //    .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType));
        }
    }
}
