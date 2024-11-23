using DatabaseConnection.EntityTable;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.DBContext
{
    public class WebApplicationDBContext : DbContext
    {
        public WebApplicationDBContext(DbContextOptions<WebApplicationDBContext> options) : base(options)
        {
            
        }

		public DbSet<User> Users { get; set; }
		public DbSet<ProductModel> Product { get; set; }
		public DbSet<Comment> Comments { get; set; }
    }
}
