using Application.RoomTypes.Commands.Create;
using Application.RoomTypes.Commands.Delete;
using Application.RoomTypes.Commands.Update;
using Application.RoomTypes.DTO;
using Application.RoomTypes.Queries.GetRoomTypeById;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class RoomTypeProfile : Profile
    {
        public RoomTypeProfile()
        {
            CreateMap<RoomType, RoomTypeGetDTO>();
            CreateMap<RoomTypeGetDTO, RoomType>();
            CreateMap<CreateRoomTypeCommand, RoomType>();
            CreateMap<RoomType, CreateRoomTypeCommand>();
            CreateMap<RoomType, RoomTypePostDTO>();
            CreateMap<RoomTypePostDTO, RoomType>();
            CreateMap<UpdateRoomTypeCommand, RoomType>();
            CreateMap<RoomType, UpdateRoomTypeCommand>();
            CreateMap<RoomType, RoomTypePutDTO>();
            CreateMap<RoomTypePutDTO, RoomType>();
            CreateMap<DeleteRoomTypeCommand, RoomType>();
            CreateMap<GetRoomTypeByIdQuery, RoomType>();
        }
    }
}
