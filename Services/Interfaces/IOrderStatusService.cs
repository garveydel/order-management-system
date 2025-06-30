using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services.Interfaces
{
	public interface IOrderStatusService
	{
		bool TryChangeStatus(Order order, OrderStatus newStatus);
	}
}
