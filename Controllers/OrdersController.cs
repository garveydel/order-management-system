using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;
using OrderManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace OrderManagementSystem.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class OrdersController : ControllerBase
	{
		private readonly IDiscountService _discountService;
		private readonly IOrderService _orderService;
		private readonly IOrderStatusService _orderStatusService;
		private readonly OrderDbContext _db;

		public OrdersController(IDiscountService discountService, IOrderService orderService, IOrderStatusService orderStatusService, OrderDbContext db)
		{
			_discountService = discountService;
			_orderService = orderService;
			_orderStatusService = orderStatusService;
			_db = db;
		}

		[HttpPost("calculate-discount")]
		public IActionResult CalculateDiscount([FromBody] Order order)
		{
			var discount = _discountService.CalculateDiscount(order);
			return Ok(new { Discount = discount });
		}

		[HttpPost("analytics")]
		public IActionResult GetAnalytics()
		{
			var orders = _db.Orders.Include(o => o.Customer).ToList();
			var result = _orderService.GetAnalytics(orders);
			return Ok(result);
		}

		[HttpPut("change-status/{id}")]
		public IActionResult ChangeStatus(int id, [FromQuery] OrderStatus newStatus)
		{
			var order = _db.Orders.Include(o => o.Customer).FirstOrDefault(o => o.Id == id);
			if (order == null) return NotFound();

			var success = _orderStatusService.TryChangeStatus(order, newStatus);
			if (!success) return BadRequest("Invalid status transition");

			_db.SaveChanges();
			return Ok(order);
		}

		[HttpPost("create")]
		public IActionResult CreateOrder([FromBody] Order order)
		{
			_db.Orders.Add(order);
			_db.SaveChanges();
			return CreatedAtAction(nameof(CreateOrder), new { id = order.Id }, order);
		}
	}

}
