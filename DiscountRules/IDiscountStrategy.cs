using OrderManagementSystem.Models;

namespace OrderManagementSystem.DiscountRules
{
	public interface IDiscountStrategy
	{
		decimal ApplyDiscount(Order order);
	}
}
