using RoomBookingApp.Core.Enum;
using RoomBookingApp.Domain.BaseModel;

namespace RoomBookingApp.Core
{
    public class RoomBookingResult : RoomBookingBase
    {
        public BookingResultFlag Flag { get; set; }
        public int? RoomBookingId { get; set; }
    }
}