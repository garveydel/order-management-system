using Microsoft.EntityFrameworkCore;

namespace OrderManagementSystem.Models
{
	public class OrderDbContext : DbContext
	{
		public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

		public DbSet<Order> Orders => Set<Order>();
		public DbSet<Customer> Customers => Set<Customer>();
	}
}
