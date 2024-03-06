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

namespace PrelimWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RuleBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Once the game starts, the program will generate a random 8-bit decimal number and start the 30-second timer." +
                "Your goal is to convert the decimal number into it's binary form. The game will continue to generate new numbers for you " +
                "to convert until the timer runs out.");
        }

        private void UserInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
