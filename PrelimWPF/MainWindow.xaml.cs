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

        int deci;
        int score;
        bool _timerStatus = false;
        DispatcherTimer _dt = null;

        int bit128;
        int bit64;
        int bit32;
        int bit16;
        int bit8;
        int bit4;
        int bit2;
        int bit1;
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
            Timer.Content = sec.ToString();
            if (sec == 0)
            {
                _dt.Stop();
				_timerStatus = false;
				StartBtn.Visibility = Visibility.Visible;
                MessageBox.Show("Thank you for playing!\nFinal Score: " + Score.Content, "Game Over");
                Timer.Content = "";
                decinum.Content = "";

				Bit1.Text = "0";
				Bit2.Text = "0";
				Bit3.Text = "0";
				Bit4.Text = "0";
				Bit5.Text = "0";
				Bit6.Text = "0";
				Bit7.Text = "0";
				Bit8.Text = "0";

				bit128 = 0;
				bit64 = 0;
				bit32 = 0;
				bit16 = 0;
				bit8 = 0;
				bit4 = 0;
				bit2 = 0;
				bit1 = 0;

				RedBird1.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
				RedBird2.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
				RedBird3.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
				RedBird4.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
				RedBird5.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
				RedBird6.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
				RedBird7.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
				RedBird8.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));

				Score.Content = "0";
			}
		}

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            Timer.Content = "60";
            if (!_timerStatus)
            {
                _dt.Start();
                _timerStatus = true;
                StartBtn.Visibility = Visibility.Hidden;
            }
            deci = rnd.Next(0, 256);
            decinum.Content = deci;
        }
        private void RuleBtn_Click(object sender, RoutedEventArgs e)
        {
			_dt.Stop();
			MessageBox.Show("Once the game starts, the program will generate a random 8-bit" +
                " decimal number and start the timer. Your goal is to convert the decimal" +
                " number into it's binary form. The game will continue to generate " +
                "new numbers for you to convert until the timer runs out.", "How To Play");
			_dt.Start();
		}
        private void Switch1_Click(object sender, RoutedEventArgs e)
        {
            if (_timerStatus)
            {
                if (Bit1.Text == "0")
                {
                    RedBird1.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
                    Bit1.Text = "1";
                    bit128 = 128;
                }
                else
                {
                    RedBird1.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
                    Bit1.Text = "0";
                    bit128 = 0;
                }
            }
        }
        private void Switch2_Click(object sender, RoutedEventArgs e)
        {
            if (_timerStatus)
            {
                if (Bit2.Text == "0")
                {
                    RedBird2.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
                    Bit2.Text = "1";
                    bit64 = 64;
                }
                else
                {
					RedBird2.Source = new BitmapImage(new Uri("Redbird.png", UriKind.RelativeOrAbsolute));
					Bit2.Text = "0";
                    bit64 = 0;
                }
            }
        }
        private void Switch3_Click(object sender, RoutedEventArgs e)
        {
			if (_timerStatus)
			{
				if (Bit3.Text == "0")
				{
					RedBird3.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
					Bit3.Text = "1";
                    bit32 = 32;
				}
				else
				{
					RedBird3.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
					Bit3.Text = "0";
                    bit32 = 0;
				}
			}
		}

        private void Switch4_Click(object sender, RoutedEventArgs e)
        {
			if (_timerStatus)
			{
				if (Bit4.Text == "0")
				{
					RedBird4.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
					Bit4.Text = "1";
                    bit16 = 16;
				}
				else
				{
					RedBird4.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
					Bit4.Text = "0";
                    bit16 = 0;
				}
			}
		}

        private void Switch5_Click(object sender, RoutedEventArgs e)
        {
			if (_timerStatus)
			{
				if (Bit5.Text == "0")
				{
					RedBird5.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
					Bit5.Text = "1";
                    bit8 = 8;
				}
				else
				{
					RedBird5.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
					Bit5.Text = "0";
                    bit8 = 0;
				}
			}
		}

        private void Switch6_Click(object sender, RoutedEventArgs e)
        {
			if (_timerStatus)
			{
				if (Bit6.Text == "0")
				{
					RedBird6.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
					Bit6.Text = "1";
                    bit4 = 4;
				}
				else
				{
					RedBird6.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
					Bit6.Text = "0";
                    bit4 = 0;
				}
			}
		}

        private void Switch7_Click(object sender, RoutedEventArgs e)
        {
			if (_timerStatus)
			{
				if (Bit7.Text == "0")
				{
					RedBird7.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
					Bit7.Text = "1";
                    bit2 = 2;
				}
				else
				{
					RedBird7.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
					Bit7.Text = "0";
                    bit2 = 0;
				}
			}
		}

        private void Switch8_Click(object sender, RoutedEventArgs e)
        {
			if (_timerStatus)
			{
				if (Bit8.Text == "0")
				{
					RedBird8.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
					Bit8.Text = "1";
                    bit1 = 1;
				}
				else
				{
					RedBird8.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
					Bit8.Text = "0";
                    bit1 = 0;
				}
			}
		}

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            int UserAns = bit128 + bit64 + bit32 + bit16 + bit8 + bit4 + bit2 + bit1;
            if (UserAns == deci)
            {
                deci = rnd.Next(0, 256);
                decinum.Content = deci;
                Bit1.Text = "0";
                Bit2.Text = "0";
                Bit3.Text = "0";
                Bit4.Text = "0";
                Bit5.Text = "0";
                Bit6.Text = "0";
                Bit7.Text = "0";
                Bit8.Text = "0";

                bit128 = 0;
                bit64 = 0;
                bit32 = 0;
                bit16 = 0;
                bit8 = 0;
                bit4 = 0;
                bit2 = 0;
                bit1 = 0;

				RedBird1.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
				RedBird2.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
				RedBird3.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
				RedBird4.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
				RedBird5.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
				RedBird6.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
				RedBird7.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
				RedBird8.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));

				score++;
                Score.Content = score;
            }
        }
    }
}
