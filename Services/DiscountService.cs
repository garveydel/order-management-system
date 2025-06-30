using OrderManagementSystem.DiscountRules;
using OrderManagementSystem.Models;
using OrderManagementSystem.Services.Interfaces;

namespace OrderManagementSystem.Services
{
	public class DiscountService : IDiscountService
	{
		public decimal CalculateDiscount(Order order)
		{
			IDiscountStrategy strategy = order.Customer.Segment switch
			{
				"Premium" => new PremiumCustomerDiscount(),
				"Loyal" => new LoyalCustomerDiscount(),
				_ => new RegularCustomerDiscount(),
			};
			return strategy.ApplyDiscount(order);
		}
	}
}
