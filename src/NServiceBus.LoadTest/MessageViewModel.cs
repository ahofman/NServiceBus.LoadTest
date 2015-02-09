using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NServiceBus.LoadTest
{
    public class MessageViewModel
    {
        public object Message { get; set; }
        public IEnumerable<PropertyModel> Properties { get; set; }
    }
}
