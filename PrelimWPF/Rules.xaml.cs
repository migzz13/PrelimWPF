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
	/// Interaction logic for Rules.xaml
	/// </summary>
	public partial class Rules : Window
	{
		public Rules()
		{
			InitializeComponent();
			Ruleslbl.Content = "Once the game starts, the program will \ngenerate a random 8-bit decimal number\nand start the timer. Your goal is to \nconvert the decimal " +
				"number into it's \nbinary form. The game will continue to \ngenerate new numbers for you to convert \nuntil the timer runs out." +
				"\n\nDifficulties:\nEasy - 60 seconds for the starting timer.\n\nMedium - 45 second starting timer and \nbit labels are hidden.\n\nHard - 30 second starting timer, bit labels are hidden, " +
				"and \nthe decimal number changes within 5-10 seconds with bit values not resetting to 0.";
		}

		private void CloseBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
