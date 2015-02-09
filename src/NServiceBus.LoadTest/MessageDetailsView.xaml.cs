using FirstFloor.ModernUI.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

		private void ModernFrame_Navigated(object sender, FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
		{
		}

		public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
		{
		    var assembly = SessionContext.Instance.MessageAssembly;

			DataContext = new MessageViewModel
			{
				Properties = assembly.GetTypes().Where( t => t.Name == e.Fragment ).Single()
					.GetProperties().Select(p =>
					new PropertyModel { PropertyInfo = p })
			};
		}

		public void OnNavigatedFrom(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
		{
		}

		public void OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
		{
		}

		public void OnNavigatingFrom(FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
		{
		}

	    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
	    {
	        // bus.send
	    }
	}
}
