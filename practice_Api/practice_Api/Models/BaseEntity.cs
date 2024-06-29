using System;
namespace practice_Api.Models
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
	}
}

