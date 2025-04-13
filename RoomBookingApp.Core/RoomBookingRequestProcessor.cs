using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Core.Enum;
using RoomBookingApp.Domain;
using RoomBookingApp.Domain.BaseModel;

namespace RoomBookingApp.Core
{
    public class RoomBookingRequestProcessor : IRoomBookingRequestProcessor
    {
        private readonly IRoomBookingService _roomBookingService;
        public RoomBookingRequestProcessor(IRoomBookingService roomBookingService)
        {
            _roomBookingService = roomBookingService;
        }

        public RoomBookingResult BookRoom(RoomBookingRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));
            var availableRooms = _roomBookingService.GetAvailableRooms(request.Date);
            var result = CreateRoomBookingObject<RoomBookingResult>(request);
            if (availableRooms.Any())
            {
                var roomBooking = CreateRoomBookingObject<RoomBooking>(request);
                roomBooking.RoomId = availableRooms.First().Id;
                _roomBookingService.Save(roomBooking);
                result.Flag = BookingResultFlag.Success;
                result.RoomBookingId = roomBooking.Id;
            }
            else
            {
                result.Flag = BookingResultFlag.Failure;
            }
            return result;
        }
        private TRoomBooking CreateRoomBookingObject<TRoomBooking>(RoomBookingRequest request)
             where TRoomBooking : RoomBookingBase, new()
        {
            return new TRoomBooking
            {
                Date = request.Date
                //Email = request.Email,
                //FullName = request.FullName
            };
        }
    }
}
