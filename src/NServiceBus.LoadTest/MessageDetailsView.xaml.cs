using FirstFloor.ModernUI.Windows;
using NServiceBus.LoadTest.TestMessageAssembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
			DataContext = new MessageViewModel
			{
				Properties = typeof(CreateOrder).Assembly.GetTypes().Where( t => t.Name == e.Fragment ).Single()
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
	}
}
