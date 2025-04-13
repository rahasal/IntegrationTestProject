using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace RoomBookingApp.Persistence
{
    public class RoomBookingAppDbContextFactory : IDesignTimeDbContextFactory<RoomBookingAppDBContext>
    {
        public RoomBookingAppDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RoomBookingAppDBContext>();

            optionsBuilder.UseSqlite("DataSource=:memory:");

            return new RoomBookingAppDBContext(optionsBuilder.Options);
        }
    }
}
