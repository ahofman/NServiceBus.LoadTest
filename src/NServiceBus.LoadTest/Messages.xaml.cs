﻿using FirstFloor.ModernUI.Presentation;
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
	/// Interaction logic for Messages.xaml
	/// </summary>
	public partial class Messages : UserControl
	{
		public LinkCollection Links { get; set; }

		public Messages()
		{
			InitializeComponent();

			Links = new LinkCollection();

			foreach (var t in typeof(CreateOrder).Assembly.GetTypes())
			{
				Links.Add(new Link { DisplayName = t.Name, Source = new Uri(string.Format("/MessageDetails.xaml#{0}", t.Name), UriKind.Relative) });
			}

			DataContext = this;
		}
	}
}
