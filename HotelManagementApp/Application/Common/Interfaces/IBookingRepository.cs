﻿using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> GetBookingByIdAsync(int id);

        Task<IEnumerable<Booking>> GetAllBookingsAsync();

        Task AddBookingAsync(Booking booking);

        Task UpdateBookingAsync(Booking booking);

        Task DeleteBookingAsync(int id);
    }
}