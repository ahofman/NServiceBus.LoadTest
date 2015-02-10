using NServiceBus.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NServiceBus.LoadTest
{
	class GetMessageTypesFeature : Feature
	{
		protected override void Setup(FeatureConfigurationContext context)
		{
			var c = context.Settings.Get<Conventions>();

			var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany( a => a.GetTypes() );

			foreach( var t in allTypes )
			{
				if ( c.IsMessageType(t) )
				{
					SessionContext.Instance.MessageTypes.Add( t );
				}
			}
		}
	}
}
