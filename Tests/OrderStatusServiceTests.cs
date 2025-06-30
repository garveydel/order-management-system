using OrderManagementSystem.Models;
using OrderManagementSystem.Services;
using Xunit;


namespace OrderManagementSystem.Tests
{
	

	public class OrderStatusServiceTests
	{
		[Fact]
		public void CanTransition_FromPendingToProcessed()
		{
			var service = new OrderStatusService();
			var order = new Order { Status = OrderStatus.Pending };

			var result = service.TryChangeStatus(order, OrderStatus.Processed);

			Assert.True(result);
			Assert.Equal(OrderStatus.Processed, order.Status);
		}

		[Fact]
		public void CannotTransition_FromPendingToDelivered()
		{
			var service = new OrderStatusService();
			var order = new Order { Status = OrderStatus.Pending };

			var result = service.TryChangeStatus(order, OrderStatus.Delivered);

			Assert.False(result);
			Assert.Equal(OrderStatus.Pending, order.Status);
		}

		[Fact]
		public void DeliveredStatus_SetsFulfilledAt()
		{
			var service = new OrderStatusService();
			var order = new Order { Status = OrderStatus.Shipped };

			var result = service.TryChangeStatus(order, OrderStatus.Delivered);

			Assert.True(result);
			Assert.Equal(OrderStatus.Delivered, order.Status);
			Assert.NotNull(order.FulfilledAt);
		}
	}

}
