using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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


namespace WumpusWordGUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Game g;
		public MainWindow()
		{
			if (!Directory.Exists("C:\\Program Files\\swipl"))
			{
				System.Windows.MessageBox.Show("You need to install SWIPL v6.6.6!");
				var p = Process.Start("PLsetup.exe");
				p.WaitForExit();
			}
			if (Environment.GetEnvironmentVariable("Path").Contains("C:\\Program Files\\swipl\\bin"))
			{
				
				//Debug.WriteLine("Installed!");
			}
			else
			{
				
				String temp = Environment.GetEnvironmentVariable("Path")+ ";C:\\Program Files\\swipl\\bin";		
				Environment.SetEnvironmentVariable("Path",temp);
			}
			
			InitializeComponent();
			size.Text = "4";
			pits.Text = "2";
			wumpus.Text = "1";
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
		
		private void Initialize_Click(object sender, RoutedEventArgs e)
		{


			int s = Int32.Parse(size.Text);
			int p = Int32.Parse(pits.Text);
			int w = Int32.Parse(wumpus.Text);

			if (s < 2 || w < 0 || p < 0 || s > 15 || w > 15 || p > 15)
			{
				System.Windows.MessageBox.Show("Wrong Inputs!");
			}
			else
			{
				g = new Game(s, p, w);
				g.Show();
			}
		}
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			g.Hide();
			g.Close();
		}

	}
}
