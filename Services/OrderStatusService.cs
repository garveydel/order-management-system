using OrderManagementSystem.Models;
using OrderManagementSystem.Services.Interfaces;

namespace OrderManagementSystem.Services
{
	public class OrderStatusService : IOrderStatusService
	{
		private readonly Dictionary<OrderStatus, List<OrderStatus>> _validTransitions = new()
	{
		{ OrderStatus.Pending, new() { OrderStatus.Processed, OrderStatus.Cancelled } },
		{ OrderStatus.Processed, new() { OrderStatus.Shipped } },
		{ OrderStatus.Shipped, new() { OrderStatus.Delivered } }
	};

		public bool TryChangeStatus(Order order, OrderStatus newStatus)
		{
			if (_validTransitions.TryGetValue(order.Status, out var allowedTransitions) && allowedTransitions.Contains(newStatus))
			{
				order.Status = newStatus;
				if (newStatus == OrderStatus.Delivered)
				{
					order.FulfilledAt = DateTime.UtcNow;
				}
				return true;
			}
			return false;
		}
	}
}
