﻿using System;
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

		public InputName(int score, string totaltimeplayed)
		{
			InitializeComponent();
			Gameovermsg.Content = "Thank you for playing!\n" + "Final Score: " + score + "\nTotal Time Played: " + totaltimeplayed;
		}

		private void SubmitBtn_Click(object sender, RoutedEventArgs e)
		{
			if (MainWindow.inputnameopen)
			{
				PlayerName = UserName.Text;
				MainWindow.inputnameopen = false;
				DialogResult = true;
			}
		}
	}
}
