using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Controllers
{
	public interface IOrdersController
	{
		IActionResult CalculateDiscount([FromBody] Order order);
		IActionResult GetAnalytics([FromBody] List<Order> orders);
	}
}