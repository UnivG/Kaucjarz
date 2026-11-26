using Microsoft.AspNetCore.Mvc;
using kaucjarz_api.DTO;
using kaucjarz_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public bool Add(Order order)
        {
            try
            {
                _appDbContext.Orders.Add(order);
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
