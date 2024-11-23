using DatabaseConnection.EntityTable;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection.DBContext
{
	public class WebApplicationDBContext : DbContext
	{
		public WebApplicationDBContext(DbContextOptions<WebApplicationDBContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<ProductModel> Product { get; set; }
		public DbSet<Comment> Comments { get; set; }
	}
}
