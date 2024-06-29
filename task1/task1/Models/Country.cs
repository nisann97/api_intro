using System;
using System.ComponentModel.DataAnnotations;

namespace task1.Models
{
	public class Country : BaseEntity
	{
		[Required(ErrorMessage="Cannot be empty")]
		public string Name { get; set; }
        public ICollection<City> Cities { get; set; }

    }
}

