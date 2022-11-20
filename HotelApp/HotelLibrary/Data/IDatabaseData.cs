using HotelLibrary.Models;

namespace HotelLibrary.Data
{
	public interface IDatabaseData
	{
		void BookGuest(DateTime startDate, DateTime endDate, int roomTypeId, string firstName, string lastName);

		void CheckInGuest(int bookingId);

		List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate);

		List<BookingFullModel> SearchBookings(string lastName);
	}
}