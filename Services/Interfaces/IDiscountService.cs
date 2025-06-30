using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services.Interfaces
{
	public interface IDiscountService
	{
		decimal CalculateDiscount(Order order);
	}
}
