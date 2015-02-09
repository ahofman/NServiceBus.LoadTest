using System;
using FirstFloor.ModernUI.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

	    public override void OnApplyTemplate()
	    {
	        base.OnApplyTemplate();
            /*
	        foreach (var item in this.PropertiesListBox.Items)
	        {
	            var container = PropertiesListBox.ItemContainerGenerator.ContainerFromItem(item);
	            int childCount = VisualTreeHelper.GetChildrenCount(container);
	            for (int i = 0; i < childCount; ++i)
	            {
	                var child = VisualTreeHelper.GetChild(container, i);
                     
	            }
	          
	        }

	        var t = this.FindName("PropertyValueTextBox");
            */
	    }


	    private void ModernFrame_Navigated(object sender, FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
		{
		}

		public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
		{
		    var assembly = SessionContext.Instance.MessageAssembly;
		    var type = assembly.GetTypes().Single(t => t.Name == e.Fragment);

			DataContext = new MessageViewModel
			{
                Message = Activator.CreateInstance(type, false),
				Properties = 
					type.GetProperties().Select(p =>
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
