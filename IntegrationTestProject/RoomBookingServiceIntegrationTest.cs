using Microsoft.EntityFrameworkCore;
using RoomBookingApp.Domain;
using RoomBookingApp.Persistence;
using RoomBookingApp.Persistence.Repositories;

namespace TestProject1
{
    public class RoomBookingServiceIntegrationTest
    {
        [Fact]
        public void Should_Return_Available_Rooms()
        {
            //Arrange
            var date = new DateTime(2021, 06, 09);
            var dbOptions = new DbContextOptionsBuilder<RoomBookingAppDBContext>().UseInMemoryDatabase("AvailableRoomTest").Options;
            using var context = new RoomBookingAppDBContext(dbOptions);
            context.Add(new Room { Id = 1, Name = "Room 1" });
            context.Add(new Room { Id = 2, Name = "Room 2" });
            context.Add(new Room { Id = 3, Name = "Room 3" });
            context.Add(new RoomBooking { RoomId = 1, Date = date });
            context.Add(new RoomBooking { RoomId = 2, Date = date.AddDays(-1) });

            context.SaveChanges(); 

            var roomBookingService = new RoomBookingService(context);

            //Act
            var availableRooms = roomBookingService.GetAvailableRooms(date);

            //Assert
            Assert.Equal(2,availableRooms.Count());
            Assert.Contains(availableRooms, q => q.Id == 2);
            Assert.Contains(availableRooms,q=>q.Id == 3);
            Assert.DoesNotContain(availableRooms,q=>q.Id == 1);
        }
    }
}
