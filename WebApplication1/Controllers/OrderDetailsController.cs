using Dto.dto_classes;
using Dto;
using Ibll;
using Idal;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dal.Models;
using System.Net.Mail;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrdersDetailBll c;

        public OrderDetailsController(IOrdersDetailBll ordersDetailBll)
        {
            c = ordersDetailBll;
        }

        [HttpGet]
        public async Task<List<OrdersDetailDto>> Get()
        {
            return await c.SelectAll();
        }

        [HttpPost("CalculateTotalPrice")]
        public async Task<ActionResult<double>> CalculateTotalPrice([FromBody] TotalPriceRequest request)
        {
            if (request == null || request.Customer == null || request.OrdersDetails == null)
            {
                return BadRequest("Invalid request. Please provide both customer and order details.");
            }

            try
            {
                // קריאה לפונקציה TotalPriceAsync עם המידע שנשלח בבקשה
                double totalPrice = await c.TotalPriceAsync(request.Customer, request.OrdersDetails);
                return Ok(totalPrice);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        public class TotalPriceRequest
        {
            public CustomerDto Customer { get; set; }
            public OrdersDetailDto[] OrdersDetails { get; set; }
        }
    }
}



