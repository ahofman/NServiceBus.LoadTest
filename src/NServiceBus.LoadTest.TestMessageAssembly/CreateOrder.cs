using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NServiceBus.LoadTest.TestMessageAssembly
{
	public class CreateOrder
	{
		public Guid Id { get; set; }
		public string SupplierCode { get; set; }

	}
}
