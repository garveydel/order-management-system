using OrderManagementSystem.DTOs;
using OrderManagementSystem.Models;
using OrderManagementSystem.Services.Interfaces;

namespace OrderManagementSystem.Services
{
	public class OrderService : IOrderService
	{
		public OrderAnalytics GetAnalytics(List<Order> orders)
		{
			var averageValue = orders.Any() ? orders.Average(o => o.TotalAmount) : 0;
			var avgTime = orders.Where(o => o.FulfilledAt.HasValue)
								 .Select(o => (o.FulfilledAt.Value - o.CreatedAt).TotalHours)
								 .DefaultIfEmpty(0).Average();
			return new OrderAnalytics { AverageOrderValue = averageValue, AverageFulfillmentTimeHours = avgTime };
		}
	}
}
