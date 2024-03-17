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
	/// Interaction logic for Difficulty.xaml
	/// </summary>
	public partial class Difficulty : Window
	{
		public string SelectedDifficulty { get; private set; }

		public Difficulty()
		{
			InitializeComponent();
		}

		private void SelectBtn_Click(object sender, RoutedEventArgs e)
		{
			if (EasyDiff.IsChecked == true)
				SelectedDifficulty = "Easy";
			else if (MediumDiff.IsChecked == true)
				SelectedDifficulty = "Medium";
			else if (HardDiff.IsChecked == true)
				SelectedDifficulty = "Hard";
			DialogResult = true;
		}

		private void EasyDiff_Checked(object sender, RoutedEventArgs e)
		{
			SelectBtn.IsEnabled = true;
		}

		private void MediumDiff_Checked(object sender, RoutedEventArgs e)
		{
			SelectBtn.IsEnabled = true;
		}

		private void HardDiff_Checked(object sender, RoutedEventArgs e)
		{
			SelectBtn.IsEnabled = true;
		}
	}
}
