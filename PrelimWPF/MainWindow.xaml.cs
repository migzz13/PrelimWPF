using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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

		private DispatcherTimer DifficultModeTimer;
		public string totaltimeplayed;

        public static bool lbopen = false;
        public static bool rulesopen = false;
        public static bool diffopen = false;
        public static bool inputnameopen = false;

        int deci;
		int score;
		int RoundCount = 1;
		public int MaxTime = 60;

		bool _GameTimerStatus = false;
		bool _TimePlayedStatus = false;
		DispatcherTimer _GameTimer = null;
		DispatcherTimer _TimePlayed = null;

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
			_GameTimer = new DispatcherTimer();
			_GameTimer.Tick += _GameTimer_Tick;
			_GameTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);

			_TimePlayed = new DispatcherTimer();
			_TimePlayed.Tick += _TimePlayed_Tick;
			_TimePlayed.Interval = new TimeSpan(0, 0, 0, 1, 0);
		}

		private void _TimePlayed_Tick(object sender, EventArgs e)
		{
			int sec = int.Parse(TimePlayedSecs.Content.ToString());
			int min = int.Parse(TimePlayedMin.Content.ToString());
			sec++;

			if (sec >= 60)
			{
				sec = 0;
				min++;
			}
			TimePlayedSecs.Content = sec.ToString("00");
			TimePlayedMin.Content = min.ToString("00");
		}
		private void _GameTimer_Tick(object sender, EventArgs e)
		{
			int sec = int.Parse(Timer.Content.ToString());
			sec--;
			Timer.Content = sec.ToString();
			if (sec == 0)
			{
				totaltimeplayed = TimePlayedMin.Content.ToString() + ":" + TimePlayedSecs.Content.ToString();
				_GameTimer.Stop();
				_GameTimerStatus = false;
				_TimePlayed.Stop();
				_TimePlayedStatus = false;
				StartBtn.Visibility = Visibility.Visible;

				string PlayerName = EnterUserName();
				SavePlayerScore(PlayerName, score, totaltimeplayed);
				ShowLeaderboard();

                Timer.Content = "";
				decinum.Content = "";
				TimePlayedMin.Content = "";
				TimePlayedSecs.Content = "";

				Bit1.Content = "0";
				Bit2.Content = "0";
				Bit3.Content = "0";
				Bit4.Content = "0";
				Bit5.Content = "0";
				Bit6.Content = "0";
				Bit7.Content = "0";
				Bit8.Content = "0";

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

		private string EnterUserName()
		{
			string playerName = "";
			InputName inputname = new InputName(score, totaltimeplayed);
			if (inputname.ShowDialog() == true)
			{
				playerName = inputname.PlayerName;
			}
			return playerName;
		}

		private void SavePlayerScore(string playerName, int playerScore, string playTime)
		{
			string filePath = "leaderboard.csv";
			using (StreamWriter writer = new StreamWriter(filePath, true))
			{
				writer.WriteLine($"{playerName},{playerScore},{playTime}");
			}
		}

		private void ShowLeaderboard()
		{
			if (!lbopen)
			{
				Leaderboards leaderboards = new Leaderboards();
				lbopen = true;
				leaderboards.Show();
			}
		}

		private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
			Difficulty difficultywindow = new Difficulty();
			if (difficultywindow.ShowDialog() == true)
			{
				string selectedDifficulty = difficultywindow.SelectedDifficulty;

				switch (selectedDifficulty)
				{
					case "Easy":
						MaxTime = 60;
						Lbl128.Visibility = Visibility.Visible;
						Lbl64.Visibility = Visibility.Visible;
						Lbl32.Visibility = Visibility.Visible;
						Lbl16.Visibility = Visibility.Visible;
						Lbl8.Visibility = Visibility.Visible;
						Lbl4.Visibility = Visibility.Visible;
						Lbl2.Visibility = Visibility.Visible;
						Lbl1.Visibility = Visibility.Visible;
						break;
					case "Medium":
						MaxTime = 45;
						Lbl128.Visibility = Visibility.Hidden;
						Lbl64.Visibility = Visibility.Hidden;
						Lbl32.Visibility = Visibility.Hidden;
						Lbl16.Visibility = Visibility.Hidden;
						Lbl8.Visibility = Visibility.Hidden;
						Lbl4.Visibility = Visibility.Hidden;
						Lbl2.Visibility = Visibility.Hidden;
						Lbl1.Visibility = Visibility.Hidden;
						break;
					case "Hard":
						MaxTime = 30;
						Lbl128.Visibility = Visibility.Hidden;
						Lbl64.Visibility = Visibility.Hidden;
						Lbl32.Visibility = Visibility.Hidden;
						Lbl16.Visibility = Visibility.Hidden;
						Lbl8.Visibility = Visibility.Hidden;
						Lbl4.Visibility = Visibility.Hidden;
						Lbl2.Visibility = Visibility.Hidden;
						Lbl1.Visibility = Visibility.Hidden;
						StartHardModeTimer();
						break;
					default:
						MaxTime = 60;
						break;
				}
			}
			Score.Content = "0";
			Timer.Content = MaxTime.ToString();
			if (!_GameTimerStatus)
            {
                _GameTimer.Start();
                _GameTimerStatus = true;
                StartBtn.Visibility = Visibility.Hidden;
            }

			if (!_TimePlayedStatus)
			{
				_TimePlayed.Start();
				_TimePlayedStatus = true;
			}
			NumberGenerator();
		}
		private void StartHardModeTimer()
		{
			DifficultModeTimer = new DispatcherTimer();
			DifficultModeTimer.Tick += HardModeTimer_Tick;
			DifficultModeTimer.Interval = TimeSpan.FromSeconds(rnd.Next(7, 12));
			DifficultModeTimer.Start();
		}
		private void HardModeTimer_Tick(object sender, EventArgs e)
		{
			if (MaxTime == 30)
			{
				NumberGenerator();
            }
		}
		private void NumberGenerator()
		{
			deci = rnd.Next(1, 256);
			decinum.Content = deci;
		}
        private void RuleBtn_Click(object sender, RoutedEventArgs e)
        {
			Rules ruleswindow = new Rules();
			if (!rulesopen)
			{
				ruleswindow.Focus();
				if (_GameTimerStatus)
				{
					_GameTimer.Stop();
					rulesopen = true;
					ruleswindow.Show();
					_GameTimer.Start();
				}
				else
				{
					rulesopen = true;
					ruleswindow.Show();
				}
			}
		}
        private void Switch1_Click(object sender, RoutedEventArgs e)
        {
            if (_GameTimerStatus)
            {
                if (Bit1.Content.ToString() == "0")
                {
                    RedBird1.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
                    Bit1.Content = "1";
                    bit128 = 128;
                }
                else
                {
                    RedBird1.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
                    Bit1.Content = "0";
                    bit128 = 0;
                }
            }
        }
        private void Switch2_Click(object sender, RoutedEventArgs e)
        {
            if (_GameTimerStatus)
            {
				if (Bit2.Content.ToString() == "0")
                {
                    RedBird2.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
                    Bit2.Content = "1";
                    bit64 = 64;
                }
                else
                {
					RedBird2.Source = new BitmapImage(new Uri("Redbird.png", UriKind.RelativeOrAbsolute));
					Bit2.Content = "0";
                    bit64 = 0;
                }
            }
        }
        private void Switch3_Click(object sender, RoutedEventArgs e)
        {
			if (_GameTimerStatus)
			{
				if (Bit3.Content.ToString() == "0")
				{
					RedBird3.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
					Bit3.Content = "1";
                    bit32 = 32;
				}
				else
				{
					RedBird3.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
					Bit3.Content = "0";
                    bit32 = 0;
				}
			}
		}

        private void Switch4_Click(object sender, RoutedEventArgs e)
        {
			if (_GameTimerStatus)
			{
				if (Bit4.Content.ToString() == "0")
				{
					RedBird4.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
					Bit4.Content = "1";
                    bit16 = 16;
				}
				else
				{
					RedBird4.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
					Bit4.Content = "0";
                    bit16 = 0;
				}
			}
		}

        private void Switch5_Click(object sender, RoutedEventArgs e)
        {
			if (_GameTimerStatus)
			{
				if (Bit5.Content.ToString() == "0")
				{
					RedBird5.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
					Bit5.Content = "1";
                    bit8 = 8;
				}
				else
				{
					RedBird5.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
					Bit5.Content = "0";
                    bit8 = 0;
				}
			}
		}

        private void Switch6_Click(object sender, RoutedEventArgs e)
        {
			if (_GameTimerStatus)
			{
				if (Bit6.Content.ToString() == "0")
				{
					RedBird6.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
					Bit6.Content = "1";
                    bit4 = 4;
				}
				else
				{
					RedBird6.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
					Bit6.Content = "0";
                    bit4 = 0;
				}
			}
		}

        private void Switch7_Click(object sender, RoutedEventArgs e)
        {
			if (_GameTimerStatus)
			{
				if (Bit7.Content.ToString() == "0")
				{
					RedBird7.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
					Bit7.Content = "1";
                    bit2 = 2;
				}
				else
				{
					RedBird7.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
					Bit7.Content = "0";
                    bit2 = 0;
				}
			}
		}

        private void Switch8_Click(object sender, RoutedEventArgs e)
        {
			if (_GameTimerStatus)
			{
				if (Bit8.Content.ToString() == "0")
				{
					RedBird8.Source = new BitmapImage(new Uri("GreenBird.png", UriKind.RelativeOrAbsolute));
					Bit8.Content = "1";
                    bit1 = 1;
				}
				else
				{
					RedBird8.Source = new BitmapImage(new Uri("RedBird.png", UriKind.RelativeOrAbsolute));
					Bit8.Content = "0";
                    bit1 = 0;
				}
			}
		}

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            int UserAns = bit128 + bit64 + bit32 + bit16 + bit8 + bit4 + bit2 + bit1;
			if (UserAns == deci)
			{
                double reductionpercent = RoundCount * 0.066;
				int roundtime;

				int reduction = (int)(MaxTime * reductionpercent);
								
				if (RoundCount == 11)
				{
					reduction = (int)(MaxTime * 0.66);
				}
			
				if (RoundCount == 1)
				{
					roundtime = MaxTime;
				}
				else
				{
					roundtime = MaxTime - reduction;
				}

                Timer.Content = roundtime.ToString();
                RoundCount++;

                deci = rnd.Next(0, 256);
				decinum.Content = deci;

                if (MaxTime == 30)
                {
                    DifficultModeTimer.Stop();
                    StartHardModeTimer();
                }

                Bit1.Content = "0";
				Bit2.Content = "0";
				Bit3.Content = "0";
				Bit4.Content = "0";
				Bit5.Content = "0";
				Bit6.Content = "0";
				Bit7.Content = "0";
				Bit8.Content = "0";

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
			else
			{
				Wrong wronganswer = new Wrong();
				wronganswer.Show();
			}
		}

		private void OpenLBBtn_Click(object sender, RoutedEventArgs e)
		{
			ShowLeaderboard();
		}
	}
}
