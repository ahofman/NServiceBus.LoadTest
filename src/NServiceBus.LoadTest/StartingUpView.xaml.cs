using FirstFloor.ModernUI.Windows.Navigation;
using NServiceBus.Unicast.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NServiceBus.LoadTest
{
	/// <summary>
	/// Interaction logic for StartingUpView.xaml
	/// </summary>
	public partial class StartingUpView : UserControl
	{
		ILinkNavigator Navigator { get; set; }

		public StartingUpView()
		{
			InitializeComponent();

			Navigator = new DefaultLinkNavigator();
			Task.Factory.StartNew(() =>
				{
					var configuration = new BusConfiguration();
					configuration.EnableFeature<GetMessageTypesFeature>();

					SessionContext.Instance.Bus = EndpointConfig.Init( configuration);

				}, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default ).ContinueWith(_ =>
					{
						Navigator.Navigate(new Uri("/MessagesView.xaml", UriKind.Relative), this);
					});
		}


	}
}
