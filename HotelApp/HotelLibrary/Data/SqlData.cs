using HotelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Data
{
	public class SqlData
	{
		private readonly ISqlDataAccess _db;
		private const string connectionStringName = "SqlDB";
		public SqlData(ISqlDataAccess db)
		{
			_db = db;
		}
		public List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
		{
			return _db.LoadData<RoomTypeModel, dynamic>("dbo.spRoomTypes_GetAvailableTypes",
											   new { startDate, endDate },
											   connectionStringName,
											   true);
		}
		public void BookGuest(DateTime startDate, DateTime endDate, int roomTypeId, string firstName, string lastName) 
		{
			// We use 'LoadData' instead of 'SaveData' because we first check if the user is already in the db, if not we insert him
			// and we need the guestId to make the reservation
			GuestModel guest = _db.LoadData<GuestModel, dynamic>("spGuests_Insert",
														new { firstName, lastName },
														connectionStringName,
														true).First();
			// To calculate the price we need to know what room type was selected
			RoomTypeModel roomType = _db.LoadData<RoomTypeModel, dynamic>("select * from dbo.RoomTypes where Id = @Id",
																 new { Id = roomTypeId },
																 connectionStringName,
																 false).First();

			TimeSpan timeStaying = endDate.Date.Subtract(startDate.Date);
			// timeStaying.TotalDays; -> returneaza fractii 
			// timeStaying.Days; -> returneaza un numar intreg


			List<RoomModel> availableRooms = _db.LoadData<RoomModel, dynamic>("spRooms_GetAvailableRooms",
																	 new { startDate, endDate, roomTypeId },
																	 connectionStringName,
																	 true);

			_db.SaveData("spBookings_Insert",
				new 
				{ 
					roomId = availableRooms.First().Id,
					guestId = guest.Id,
					startDate = startDate,
					endDate = endDate,
					totalCost = timeStaying.Days * roomType.Price
				},
				connectionStringName,
				true);
		}
	}
}
