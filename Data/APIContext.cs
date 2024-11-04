using Microsoft.EntityFrameworkCore;
using AirbnbBookingAPI.Models;


namespace AirbnbBookingAPI.Data
{
    public class APIContext : DbContext
    {
        public DbSet<AirbnbBooking> Bookings { get; set; }
        public APIContext(DbContextOptions<APIContext>options) : base(options)
        { 
            
        
        }


    }
}
