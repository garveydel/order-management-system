namespace OrderManagementSystem.Models
{
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Segment { get; set; } = "Regular";
		public int TotalOrders { get; set; }
		public List<Order> Orders { get; set; } = new();
	}
}
