﻿namespace Application.Common.Exceptions
{
    public class RoomNotFoundException : Exception
    {
        public RoomNotFoundException()
        : base()
        {
        }

        public RoomNotFoundException(string message)
            : base(message)
        {
        }

        public RoomNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}