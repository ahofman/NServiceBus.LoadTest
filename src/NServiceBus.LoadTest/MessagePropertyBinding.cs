using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace NServiceBus.LoadTest
{
	public class MessagePropertyBinding
	{
		public static readonly DependencyProperty MessagePropertyBindingProperty = DependencyProperty.RegisterAttached(
			"MessagePropertyBinding",
			typeof(string),
			typeof(MessagePropertyBinding),
			new UIPropertyMetadata(string.Empty, OnMessagePropertyBindingChanged));

		public static void SetMessagePropertyBinding(UIElement element, string binding)
		{
			element.SetValue(MessagePropertyBindingProperty, binding);	
		}

		public static string GetMessagePropertyBinding(UIElement element)
		{
			return (string)element.GetValue(MessagePropertyBindingProperty);
		}

		private static void OnMessagePropertyBindingChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e) 
		{
			if ((string)e.NewValue != string.Empty)
			{
				var textBoxElement = obj as TextBox;
				if (textBoxElement != null)
				{
					var binding = new Binding("Message." + (string)e.NewValue);
					binding.Mode = BindingMode.TwoWay;
					binding.ValidatesOnExceptions = true;
					//binding.ValidationRules.Add(new DataAnnotationsValidationRule());
					binding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
					textBoxElement.SetBinding(TextBox.TextProperty, binding);
				}
			}
		}
	}
}
