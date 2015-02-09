using System;
using FirstFloor.ModernUI.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;
using System.Threading.Tasks;
using FirstFloor.ModernUI.Windows.Navigation;

namespace NServiceBus.LoadTest
{
	/// <summary>
	/// Interaction logic for MessageDetailsView.xaml
	/// </summary>
	public partial class MessageDetailsView : UserControl, IContent
	{
		public MessageDetailsView()
		{
			InitializeComponent();
		}

	    private void ModernFrame_Navigated(object sender, NavigationEventArgs e)
		{
		}

		public void OnFragmentNavigation(FragmentNavigationEventArgs e)
		{
		    var assembly = SessionContext.Instance.MessageAssembly;
		    var type = assembly.GetTypes().Single(t => t.Name == e.Fragment);
			var m = Activator.CreateInstance(type, false);

			DataContext = new MessageViewModel
			{
                Message = m,
				Properties = 
					type.GetProperties().Select(p =>
					new PropertyModel { Message = m, PropertyInfo = p })
			};
		}

		public void OnNavigatedFrom(NavigationEventArgs e)
		{
		}

		public void OnNavigatedTo(NavigationEventArgs e)
		{
		}

		public void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{
		}

	    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
	    {
	        // bus.send
	    }

	}
}
