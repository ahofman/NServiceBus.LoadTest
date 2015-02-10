using System;
using FirstFloor.ModernUI.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;
using System.Threading.Tasks;
using FirstFloor.ModernUI.Windows.Navigation;
using FirstFloor.ModernUI.Windows.Controls;

namespace NServiceBus.LoadTest
{
	/// <summary>
	/// Interaction logic for MessageDetailsView.xaml
	/// </summary>
	public partial class MessageDetailsView : UserControl, IContent
	{
		object _currentMessage;

		public MessageDetailsView()
		{
			InitializeComponent();
		}

	    private void ModernFrame_Navigated(object sender, NavigationEventArgs e)
		{
		}

		public void OnFragmentNavigation(FragmentNavigationEventArgs e)
		{
		    var type = SessionContext.Instance.MessageTypes.Single(t => t.Name == e.Fragment);
			_currentMessage = Activator.CreateInstance(type, false);

			DataContext = new MessageViewModel
			{
				Message = _currentMessage,
				Properties = 
					type.GetProperties().Select(p =>
					new PropertyModel { Message = _currentMessage, PropertyInfo = p })
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
			SessionContext.Instance.Bus.Send(_currentMessage);

			var dlg = new ModernDialog
			{
				Title = "Success!",
				Content = "Message was sent successfully."
			};

			dlg.Buttons = new Button[] { dlg.OkButton };
			dlg.ShowDialog();
	    }

	}
}
