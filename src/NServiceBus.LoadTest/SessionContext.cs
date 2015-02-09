using NServiceBus;
using System.Reflection;

namespace NServiceBus.LoadTest
{
    class SessionContext
    {
        public Assembly MessageAssembly { get; set; }

        public IBus Bus { get; set; }

        private static SessionContext _instance;

        public static SessionContext Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SessionContext();
                return _instance;
            }
        }
    }
}
