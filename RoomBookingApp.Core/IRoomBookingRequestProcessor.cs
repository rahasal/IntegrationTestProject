namespace RoomBookingApp.Core
{
    public interface IRoomBookingRequestProcessor
    {
        RoomBookingResult BookRoom(RoomBookingRequest request);
    }
}