using System;
namespace task1.Models
{
	public class City : BaseEntity
	{
		public string Name { get; set; }
		public Country Country { get; set; }
		public int CountryId { get; set; }
	}
}

