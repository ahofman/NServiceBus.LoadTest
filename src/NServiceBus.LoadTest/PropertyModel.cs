using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NServiceBus.LoadTest
{
    public class PropertyModel
    {
		public object Message { get; set; }
        public PropertyInfo PropertyInfo { get; set; }

		public bool IsNullable
		{
			get
			{
				var type = PropertyInfo.PropertyType;
				if (!type.IsValueType) return true; // ref-type
				if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
				return false; // value-type
			}
		}
    }
}
