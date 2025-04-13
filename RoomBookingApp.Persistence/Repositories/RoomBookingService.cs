using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Domain;

namespace RoomBookingApp.Persistence.Repositories
{
    public class RoomBookingService : IRoomBookingService
    {
        private readonly RoomBookingAppDBContext _context;
        public RoomBookingService(RoomBookingAppDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Room> GetAvailableRooms(DateTime date)
        {
           var availableRooms = _context.Rooms.ToList();

            return availableRooms;
        }

        public void Save(RoomBooking roomBooking)
        {
            throw new NotImplementedException();
        }
    }
}
