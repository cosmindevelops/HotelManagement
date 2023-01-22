﻿namespace Application.Common.Exceptions
{
    public class RoomNotFoundException : Exception
    {
        public RoomNotFoundException()
        : base("Room not found.")
        {
        }

        public RoomNotFoundException(int id)
            : base($"Room with id {id} not found.")
        {
        }
    }
}