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
using System.Windows.Threading;

namespace PrelimWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();

        bool _timerStatus = false;
        DispatcherTimer _dt = null;

        public MainWindow()
        {
            InitializeComponent();
            _dt = new DispatcherTimer();
            _dt.Tick += _dt_Tick;
            _dt.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        }

        private void _dt_Tick(object sender, EventArgs e)
        {
            int sec = int.Parse(Timer.Content.ToString());
            sec--;
            if (sec < 0)
            {
                sec = 59;
            }
            Timer.Content = sec.ToString();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!_timerStatus)
            {
                _dt.Start();
                _timerStatus = true;
                StartBtn.Visibility = Visibility.Hidden;
            }
            int deci = rnd.Next(0, 256);
            decinum.Content = deci;
        }
        private void RuleBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Once the game starts, the program will generate a random 8-bit decimal number and start the timer. Your goal is to convert the decimal number into it's binary form. The game will continue to generate new numbers for you to convert until the timer runs out.", "How To Play");
        }
        private void Switch1_Click(object sender, RoutedEventArgs e)
        {
            if (_timerStatus)
            {
                if (Bit1.Text == "0")
                {
                    Bit1.Text = "1";
                }
                else
                    Bit1.Text = "0";
            }
        }
        private void Switch2_Click(object sender, RoutedEventArgs e)
        {
            if (_timerStatus)
            {
                if (Bit2.Text == "0")
                {
                    Bit2.Text = "1";
                }
                else
                    Bit2.Text = "0";
            }
        }
        private void Switch3_Click(object sender, RoutedEventArgs e)
        {
            if (_timerStatus)
            {
                if (Bit3.Text == "0")
                {
                    Bit3.Text = "1";
                }
                else
                    Bit3.Text = "0";
            }
        }

        private void Switch4_Click(object sender, RoutedEventArgs e)
        {
            if (_timerStatus)
            {
                if (Bit4.Text == "0")
                {
                    Bit4.Text = "1";
                }
                else
                    Bit4.Text = "0";
            }
        }

        private void Switch5_Click(object sender, RoutedEventArgs e)
        {
            if (_timerStatus)
            {
                if (Bit5.Text == "0")
                {
                    Bit5.Text = "1";
                }
                else
                    Bit5.Text = "0";
            }
        }

        private void Switch6_Click(object sender, RoutedEventArgs e)
        {
            if (_timerStatus)
            {
                if (Bit6.Text == "0")
                {
                    Bit6.Text = "1";
                }
                else
                    Bit6.Text = "0";
            }
        }

        private void Switch7_Click(object sender, RoutedEventArgs e)
        {
            if (_timerStatus)
            {
                if (Bit7.Text == "0")
                {
                    Bit7.Text = "1";
                }
                else
                    Bit7.Text = "0";
            }
        }

        private void Switch8_Click(object sender, RoutedEventArgs e)
        {
            if (Bit8.Text == "0")
            {
                Bit8.Text = "1";
            }
            else
                Bit8.Text = "0";
        }
    }
}
