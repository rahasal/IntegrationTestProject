namespace RoomBookingApp.Domain
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RoomBooking> RoomBooking { get; set; }
    }
}