using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.EntityTable
{
	public class Comment
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; }
		public string Author { get; set; }
		public int PostId { get; set; }
		public bool IsApproved { get; set; }
	}
}