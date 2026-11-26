using kaucjarz_api.DTO;
using kaucjarz_api.Models;
using kaucjarz_api.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace kaucjarz_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController
    {
        private readonly AppDBContext _appDbContext;
        public OrderController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("GetOrders")]
        public IEnumerable<Order> Get()
        {
            var result = _appDbContext.Orders.ToList<Order>();
            return result;
        }

        [HttpPost("AddOrder")]
        public bool Add(CreateOrderDto order)
        {
            try
            {
                var newOrder= new Order
                {
                    userId= order.UserId,
                    city=order.city,
                    street_address=order.Street_address,
                    flat_nr=order.Flat_nr,
                    estimated_bottles=order.Estimated_bottles,
                    status=order.Status,
                    pickup_date=order.Pickup_date,
                    pickup_time_slot=order.Pickup_time_slot,
                    details=order.Details
                };
                _appDbContext.Orders.Add(newOrder);
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
