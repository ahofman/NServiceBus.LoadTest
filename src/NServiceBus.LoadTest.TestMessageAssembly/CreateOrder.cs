using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NServiceBus.LoadTest.TestMessageAssembly
{
	public enum OrderType
	{
		Regular,
		Different
	}

	public class CreateOrder 
	{
		public Guid Id { get; set; }

		private string _supplierCode;
		public string SupplierCode 
		{
			get
			{
				return _supplierCode;
			}
			set
			{
				if (value.Length > 5)
					throw new ValidationException("Supplier code must be 5 characters or less");
				_supplierCode = value;
			}
		}

		public OrderType OrderType { get; set; }

		
	}
}
