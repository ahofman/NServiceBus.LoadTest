﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
	/// Interaction logic for BrowseForAssembly.xaml
	/// </summary>
	public partial class BrowseForAssembly : UserControl
	{
		public BrowseForAssembly()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = ".NET Assemblies (*.dll)|*.dll";
			if (ofd.ShowDialog() == true)
			{
				var a = Assembly.LoadFrom(ofd.FileName);


			}
		}
	}
}
