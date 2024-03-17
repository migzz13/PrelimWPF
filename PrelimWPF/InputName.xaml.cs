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
using System.Windows.Shapes;

namespace PrelimWPF
{
	/// <summary>
	/// Interaction logic for InputName.xaml
	/// </summary>
	public partial class InputName : Window
	{
		public string PlayerName { get; private set; }

		public InputName()
		{
			InitializeComponent();
		}

		private void SubmitBtn_Click(object sender, RoutedEventArgs e)
		{
			PlayerName = UserName.Text;
			DialogResult = true;
		}
	}
}
