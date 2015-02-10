using FirstFloor.ModernUI.Windows.Navigation;
using Microsoft.Win32;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace NServiceBus.LoadTest
{
	/// <summary>
	/// Interaction logic for BrowseForAssembly.xaml
	/// </summary>
	public partial class BrowseForAssembly : UserControl
	{
        ILinkNavigator Navigator { get; set; }
		public BrowseForAssembly()
		{
			InitializeComponent();

            Navigator = new DefaultLinkNavigator();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = ".NET Assemblies (*.dll)|*.dll";
			if (ofd.ShowDialog() == true)
			{
				var a = Assembly.LoadFrom(ofd.FileName);

			    SessionContext.Instance.MessageAssembly = a;
			
			    Navigator.Navigate(new Uri("/MessagesView.xaml", UriKind.Relative), this);
			}
		}
	}
}
