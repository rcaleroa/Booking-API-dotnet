namespace AirbnbBookingAPI.Models
{
    public class AirbnbBooking
    {
        public int Id { get; set; }
        public DateTime EntranceDate { get; set; }

        public DateTime ExitDate { get; set; }

        public String? ClientName { get; set; }
    }
}
