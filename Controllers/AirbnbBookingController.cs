using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirbnbBookingAPI.Models;
using AirbnbBookingAPI.Data;

namespace AirbnbBookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AirbnbBookingController : ControllerBase
    {
        private readonly APIContext _context;

        public AirbnbBookingController(APIContext context)
        {
            _context = context;   
        }

        //Create POST Method
        [HttpPost]
        public JsonResult CreateEdit(AirbnbBooking abooking)
        {
            if (abooking.Id == 0)
            {
                _context.Bookings.Add(abooking);
            }

            else
            {
                var bookingInDb = _context.Bookings.Find(abooking.Id);

                if (bookingInDb == null)
                    return new JsonResult(NotFound());
                    bookingInDb = abooking;
                
            }
            _context.SaveChanges();

            return new JsonResult(Ok(abooking));

        }


        //Get Method
        [HttpGet]
        public JsonResult Get(int id)
        {

            var result = _context.Bookings.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }


        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Bookings.Find(id);

            if(result == null)
                return new JsonResult(NotFound());

            _context.Bookings.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        
        }


        //List
        [HttpGet()]
        public JsonResult List()
        {
            var result = _context.Bookings.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
