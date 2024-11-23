using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.EntityTable
{
	public class Comment
	{
		public int Id { get; set; } // Unique identifier for the comment
		public string Content { get; set; } // The text of the comment
		public DateTime CreatedAt { get; set; } // Timestamp when the comment was created
		public string Author { get; set; } // The name or identifier of the author
		public int PostId { get; set; } // The ID of the related post (if this is part of a blog system)
		public bool IsApproved { get; set; } // Indicates if the comment has been moderated and approved
	}

}
