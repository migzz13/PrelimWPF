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
			else if (DifficultDiff.IsChecked == true)
				SelectedDifficulty = "Difficult";
			DialogResult = true;
		}

		private void EasyDiff_Checked(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("\n60 seconds for the starting timer." , "Easy Mode");
		}

		private void MediumDiff_Checked(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("\n45 second starting timer and bit labels are hidden.", "Medium Mode");
		}

		private void DifficultDiff_Checked(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("\n30 second starting timer, bit labels are hidden, and the decimal number changes within 5-10 seconds with bit values not resetting to 0." , "Difficult Mode");
		}
	}
}
