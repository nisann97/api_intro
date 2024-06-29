using System;
using System.ComponentModel.DataAnnotations;

namespace practice_Api.Models
{
	public class Category : BaseEntity
	{
		[Required(ErrorMessage="This field is required!")]
		public string Name { get; set; }
	}
}

