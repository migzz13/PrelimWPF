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
            _dt.Interval = new TimeSpan(0, 0, 0, 1, 0);
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
            MessageBox.Show("Once the game starts, the program will generate a random 8-bit" +
                " decimal number and start the timer. Your goal is to convert the decimal" +
                " number into it's binary form. The game will continue to generate " +
                "new numbers for you to convert until the timer runs out.", "How To Play");
        }
        private void Switch1_Click(object sender, RoutedEventArgs e)
        {
            if (_timerStatus)
            {
                if (Bit1.Text == "0")
                {
                    Bird1.Source = new BitmapImage(new Uri("bird.png", UriKind.RelativeOrAbsolute));
                    Bit1.Text = "1";
                }
                else
                {
                    Bird1.Source = new BitmapImage(new Uri("deadbird.png", UriKind.RelativeOrAbsolute));
                    Bit1.Text = "0";
                }
            }
        }
        private void Switch2_Click(object sender, RoutedEventArgs e)
        {
            if (_timerStatus)
            {
                if (Bit2.Text == "0")
                {
                    Bird2.Source = new BitmapImage(new Uri("bird.png", UriKind.RelativeOrAbsolute));
                    Bit2.Text = "1";
                }
                else
                {
					Bird2.Source = new BitmapImage(new Uri("deadbird.png", UriKind.RelativeOrAbsolute));
					Bit2.Text = "0";
                }
            }
        }
        private void Switch3_Click(object sender, RoutedEventArgs e)
        {
			if (_timerStatus)
			{
				if (Bit3.Text == "0")
				{
					Bird3.Source = new BitmapImage(new Uri("bird.png", UriKind.RelativeOrAbsolute));
					Bit3.Text = "1";
				}
				else
				{
					Bird3.Source = new BitmapImage(new Uri("deadbird.png", UriKind.RelativeOrAbsolute));
					Bit3.Text = "0";
				}
			}
		}

        private void Switch4_Click(object sender, RoutedEventArgs e)
        {
			if (_timerStatus)
			{
				if (Bit4.Text == "0")
				{
					Bird4.Source = new BitmapImage(new Uri("bird.png", UriKind.RelativeOrAbsolute));
					Bit4.Text = "1";
				}
				else
				{
					Bird4.Source = new BitmapImage(new Uri("deadbird.png", UriKind.RelativeOrAbsolute));
					Bit4.Text = "0";
				}
			}
		}

        private void Switch5_Click(object sender, RoutedEventArgs e)
        {
			if (_timerStatus)
			{
				if (Bit5.Text == "0")
				{
					Bird5.Source = new BitmapImage(new Uri("bird.png", UriKind.RelativeOrAbsolute));
					Bit5.Text = "1";
				}
				else
				{
					Bird5.Source = new BitmapImage(new Uri("deadbird.png", UriKind.RelativeOrAbsolute));
					Bit5.Text = "0";
				}
			}
		}

        private void Switch6_Click(object sender, RoutedEventArgs e)
        {
			if (_timerStatus)
			{
				if (Bit6.Text == "0")
				{
					Bird6.Source = new BitmapImage(new Uri("bird.png", UriKind.RelativeOrAbsolute));
					Bit6.Text = "1";
				}
				else
				{
					Bird6.Source = new BitmapImage(new Uri("deadbird.png", UriKind.RelativeOrAbsolute));
					Bit6.Text = "0";
				}
			}
		}

        private void Switch7_Click(object sender, RoutedEventArgs e)
        {
			if (_timerStatus)
			{
				if (Bit7.Text == "0")
				{
					Bird7.Source = new BitmapImage(new Uri("bird.png", UriKind.RelativeOrAbsolute));
					Bit7.Text = "1";
				}
				else
				{
					Bird7.Source = new BitmapImage(new Uri("deadbird.png", UriKind.RelativeOrAbsolute));
					Bit7.Text = "0";
				}
			}
		}

        private void Switch8_Click(object sender, RoutedEventArgs e)
        {
			if (_timerStatus)
			{
				if (Bit8.Text == "0")
				{
					Bird8.Source = new BitmapImage(new Uri("bird.png", UriKind.RelativeOrAbsolute));
					Bit8.Text = "1";
				}
				else
				{
					Bird8.Source = new BitmapImage(new Uri("deadbird.png", UriKind.RelativeOrAbsolute));
					Bit8.Text = "0";
				}
			}
		}
	}
}
