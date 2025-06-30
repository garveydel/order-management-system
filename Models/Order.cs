namespace OrderManagementSystem.Models
{
	public class Order
	{
		public int Id { get; set; }
		public decimal TotalAmount { get; set; }
		public OrderStatus Status { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? FulfilledAt { get; set; }
		public Customer Customer { get; set; } = null!;
		public int CustomerId { get; set; }
	}

	public enum OrderStatus
	{
		Pending,
		Processed,
		Shipped,
		Delivered,
		Cancelled
	}
}
