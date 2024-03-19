using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PrelimWPF
{
	/// <summary>
	/// Interaction logic for Leaderboards.xaml
	/// </summary>
	public partial class Leaderboards : Window
	{
		public Leaderboards()
		{
			InitializeComponent();
			LoadLeaderboard();
		}

		private void LoadLeaderboard()
		{
			string filePath = "leaderboard.csv";
			if (File.Exists(filePath))
			{
				List<string[]> leaderboardData = new List<string[]>();
				using (StreamReader reader = new StreamReader(filePath))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						string[] data = line.Split(',');
						leaderboardData.Add(data);
					}
				}

				for (int i = 0; i < leaderboardData.Count - 1; i++)
				{
					for (int j = i + 1; j < leaderboardData.Count; j++)
					{
						if (int.Parse(leaderboardData[j][1]) > int.Parse(leaderboardData[i][1]))
						{
							string[] temp = leaderboardData[i];
							leaderboardData[i] = leaderboardData[j];
							leaderboardData[j] = temp;
						}
						else if (int.Parse(leaderboardData[j][1]) == int.Parse(leaderboardData[i][1]))
						{
							int playtimeA, playtimeB;

							if (int.TryParse(leaderboardData[i][2], out playtimeA) && int.TryParse(leaderboardData[j][2], out playtimeB))
							if (playtimeA < playtimeB)
							{
								string[] temp = leaderboardData[i];
								leaderboardData[i] = leaderboardData[j];
								leaderboardData[j] = temp;
							}
						}
					}
				}

				LeaderboardBox.Items.Clear();

				for (int i = 0; i < Math.Min(leaderboardData.Count, 10); i++)
				{
					LeaderboardBox.Items.Add($"{leaderboardData[i][0]} - Score: {leaderboardData[i][1]}, Playtime: {leaderboardData[i][2]}");
				}
			}
		}
		private void CloseBtn_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}