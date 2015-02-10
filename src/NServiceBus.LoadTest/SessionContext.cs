using NServiceBus;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace NServiceBus.LoadTest
{
    class SessionContext
    {
		private SessionContext()
		{
			MessageTypes = new List<Type>();
		}

        public IList<Type> MessageTypes { get; set; }

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
