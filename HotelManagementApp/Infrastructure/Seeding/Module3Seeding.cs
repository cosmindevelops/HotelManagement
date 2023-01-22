using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeding
{
    public static class Module3Seeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
            new Room
            {
                Id = 1,
                RoomNumber = 101,
                RoomTypeId = 1
            },
            new Room
            {
                Id = 2,
                RoomNumber = 102,
                RoomTypeId = 1
            },
            new Room
            {
                Id = 3,
                RoomNumber = 103,
                RoomTypeId = 2
            },
            new Room
            {
                Id = 4,
                RoomNumber = 104,
                RoomTypeId = 3
            },
            new Room
            {
                Id = 5,
                RoomNumber = 105,
                RoomTypeId = 4
            }, new Room
            {
                Id = 6,
                RoomNumber = 201,
                RoomTypeId = 1
            },
            new Room
            {
                Id = 7,
                RoomNumber = 202,
                RoomTypeId = 1
            },
            new Room
            {
                Id = 8,
                RoomNumber = 203,
                RoomTypeId = 2
            },
            new Room
            {
                Id = 9,
                RoomNumber = 204,
                RoomTypeId = 3
            },
            new Room
            {
                Id = 10,
                RoomNumber = 205,
                RoomTypeId = 4
            }
        );

            modelBuilder.Entity<RoomType>().HasData(
            new RoomType
            {
                Id = 1,
                Title = "Single Room",
                Description = "Experience the comfort and convenience of our single room booking. Enjoy a comfortable night's sleep in our cozy and well-appointed room, equipped with all the modern amenities you need for a relaxing stay.",
                Price = 149.99m
            },
            new RoomType
            {
                Id = 2,
                Title = "Double Room",
                Description = "Upgrade your stay with our spacious double bed room booking. Perfect for couples or friends traveling together, this room features two comfortable double beds and all the amenities you need for a comfortable and enjoyable stay.",
                Price = 249.99m
            },
            new RoomType
            {
                Id = 3,
                Title = "Queen Size Room",
                Description = "Indulge in ultimate luxury with our king size bed room booking. This elegantly appointed room features a spacious king size bed and all the amenities you need for a comfortable and memorable stay.",
                Price = 325.99m
            },
            new RoomType
            {
                Id = 4,
                Title = "King Size Room",
                Description = "Relax in comfort with our queen size bed room booking. This spacious room features a comfortable queen size bed and all the amenities you need for a relaxing and enjoyable stay.",
                Price = 399.99m
            }
        );

            modelBuilder.Entity<Guest>().HasData(
            new Guest
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe"
            },
            new Guest
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe"
            },
            new Guest
            {
                Id = 3,
                FirstName = "Bob",
                LastName = "Smith"
            },
            new Guest
            {
                Id = 4,
                FirstName = "Alice",
                LastName = "Smith"
            },
            new Guest
            {
                Id = 5,
                FirstName = "Tom",
                LastName = "Johnson"
            }
        );

            modelBuilder.Entity<Booking>().HasData(
            new Booking
            {
                Id = 1,
                RoomId = 1,
                GuestId = 1,
                StartDate = new DateTime(2022, 1, 1),
                EndDate = new DateTime(2022, 1, 3),
                CheckedIn = true,
                TotalCost = 299.97m
            },
            new Booking
            {
                Id = 2,
                RoomId = 2,
                GuestId = 2,
                StartDate = new DateTime(2022, 2, 1),
                EndDate = new DateTime(2022, 2, 3),
                CheckedIn = true,
                TotalCost = 299.97m
            },
            new Booking
            {
                Id = 3,
                RoomId = 3,
                GuestId = 3,
                StartDate = new DateTime(2022, 3, 1),
                EndDate = new DateTime(2022, 3, 3),
                CheckedIn = true,
                TotalCost = 449.95m
            },
            new Booking
            {
                Id = 4,
                RoomId = 4,
                GuestId = 4,
                StartDate = new DateTime(2022, 4, 1),
                EndDate = new DateTime(2022, 4, 3),
                CheckedIn = true,
                TotalCost = 449.95m
            },
            new Booking
            {
                Id = 5,
                RoomId = 5,
                GuestId = 5,
                StartDate = new DateTime(2022, 5, 1),
                EndDate = new DateTime(2022, 5, 3),
                CheckedIn = false,
                TotalCost = 599.93m
            }
        );
        }
    }
}