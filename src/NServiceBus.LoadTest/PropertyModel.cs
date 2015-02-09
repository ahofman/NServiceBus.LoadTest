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
    }
}
