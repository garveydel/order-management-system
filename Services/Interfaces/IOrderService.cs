using OrderManagementSystem.DTOs;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services.Interfaces
{
	public interface IOrderService
	{
		OrderAnalytics GetAnalytics(List<Order> orders);
	}
}
