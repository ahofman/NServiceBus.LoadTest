using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
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
	/// Interaction logic for MessagesView.xaml
	/// </summary>
	public partial class MessagesView : UserControl
	{
		public LinkCollection Links { get; set; }

		public MessagesView()
		{
			InitializeComponent();

			Links = new LinkCollection();

		    var a = SessionContext.Instance.MessageAssembly;

		    var types = a.GetTypes();

			foreach (var t in types)
			{
				Links.Add(new Link { DisplayName = t.Name, Source = new Uri(string.Format("/MessageDetailsView.xaml#{0}", t.Name), UriKind.Relative) });
			}

			DataContext = this;
		}

	}
}
