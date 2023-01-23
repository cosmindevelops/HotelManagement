using Application.Rooms.Commands.Create;
using Application.Rooms.Commands.Delete;
using Application.Rooms.Commands.Update;
using Application.Rooms.DTO;
using Application.Rooms.Queries.GetRoomById;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {

            CreateMap<Room, RoomGetDTO>();
            CreateMap<RoomGetDTO, Room>();
            CreateMap<RoomPostDTO, Room>();
            CreateMap<Room, RoomPostDTO>();
            CreateMap<Room, RoomPutDTO>();
            CreateMap<RoomPutDTO, Room>();
            CreateMap<Room, CreateRoomCommand>();
            CreateMap<CreateRoomCommand, Room>();
            CreateMap<Room, UpdateRoomCommand>();
            CreateMap<UpdateRoomCommand, Room>();
            CreateMap<Room, DeleteRoomCommand>();
            CreateMap<DeleteRoomCommand, Room>();
            CreateMap<Room, GetRoomByIdQuery>();
            CreateMap<GetRoomByIdQuery, Room>();

        }
    }
}