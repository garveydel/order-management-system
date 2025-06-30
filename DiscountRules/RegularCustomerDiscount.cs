using OrderManagementSystem.Models;

namespace OrderManagementSystem.DiscountRules
{
	public class RegularCustomerDiscount : IDiscountStrategy
	{
		public decimal ApplyDiscount(Order order) => order.TotalAmount * 0.05m;
	}

	public class PremiumCustomerDiscount : IDiscountStrategy
	{
		public decimal ApplyDiscount(Order order) => order.TotalAmount * 0.1m;
	}

	public class LoyalCustomerDiscount : IDiscountStrategy
	{
		public decimal ApplyDiscount(Order order) => order.Customer.TotalOrders > 10 ? order.TotalAmount * 0.15m : 0;
	}
}
