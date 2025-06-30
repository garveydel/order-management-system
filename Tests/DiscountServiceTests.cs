using OrderManagementSystem.Models;
using OrderManagementSystem.Services;
using Xunit;

namespace OrderManagementSystem.Tests
{
	
	public class DiscountServiceTests
	{
		[Fact]
		public void RegularCustomer_ShouldGet5PercentDiscount()
		{
			var service = new DiscountService();
			var order = new Order
			{
				TotalAmount = 100,
				Customer = new Customer { Segment = "Regular" }
			};

			var discount = service.CalculateDiscount(order);

			Assert.Equal(5, discount);
		}

		[Fact]
		public void PremiumCustomer_ShouldGet10PercentDiscount()
		{
			var service = new DiscountService();
			var order = new Order
			{
				TotalAmount = 200,
				Customer = new Customer { Segment = "Premium" }
			};

			var discount = service.CalculateDiscount(order);

			Assert.Equal(20, discount);
		}

		[Fact]
		public void LoyalCustomer_WithMoreThan10Orders_ShouldGet15PercentDiscount()
		{
			var service = new DiscountService();
			var order = new Order
			{
				TotalAmount = 100,
				Customer = new Customer { Segment = "Loyal", TotalOrders = 12 }
			};

			var discount = service.CalculateDiscount(order);

			Assert.Equal(15, discount);
		}

		[Fact]
		public void LoyalCustomer_WithLessThan10Orders_ShouldGetNoDiscount()
		{
			var service = new DiscountService();
			var order = new Order
			{
				TotalAmount = 100,
				Customer = new Customer { Segment = "Loyal", TotalOrders = 3 }
			};

			var discount = service.CalculateDiscount(order);

			Assert.Equal(0, discount);
		}
	}
}
