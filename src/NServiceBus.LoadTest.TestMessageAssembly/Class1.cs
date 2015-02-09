using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NServiceBus.LoadTest.TestMessageAssembly
{
    public class SomeTestMessage
    {
        public int MyProperty { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }
    }
}
