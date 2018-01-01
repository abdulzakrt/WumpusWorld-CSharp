using SbsSW.SwiPlCs;
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
using Wumpus_World;
namespace WumpusWordGUI
{
	/// <summary>
	/// Interaction logic for Game.xaml
	/// </summary>
	///

	public partial class Game : Window
	{
		World w;
		Agent a;
		bool agentdead = false;
		bool agentwon = false;
		KnowledeBaseGUI kb= null;
		public Game(int size,int pits,int wumpus)
		{
			InitializeComponent();

			


			w = new World(size, pits, wumpus);
			w.InitializeRandomWorld();
			
			a = new Agent(w);

			for (int i = 0; i < w.Size+1; i++) {
				Board.ColumnDefinitions.Add(new ColumnDefinition());
				Board.RowDefinitions.Add(new RowDefinition());
			}

			//Setting XY title 
			Border panel = new Border();
			Grid.SetColumn(panel, 0);
			Grid.SetRow(panel, 0);

			Label lb1 = new Label();
			lb1.Content = "Y/X";
			
			panel.Child = lb1;
			Board.Children.Add(panel);

			//Numbering Rows
			for (int j = 1; j <= w.Size; j++)
			{
				panel = new Border();				
				Grid.SetColumn(panel, 0);
				Grid.SetRow(panel, j);
				
				Label lb = new Label();
				lb.Content = j-1;
			
				panel.Child = lb;
				Board.Children.Add(panel);

			}
			for (int i = 1; i <= w.Size; i++)
			{
				panel = new Border();
				Grid.SetColumn(panel, i);
				Grid.SetRow(panel, 0);
				Label lb = new Label();
				lb.Content = i-1;				
				panel.Child = lb;
				Board.Children.Add(panel);
			}

			int iRow = 0;
			foreach(RowDefinition i in Board.RowDefinitions.Skip(1))
			{
				iRow++;
				int iCol = 0;
				foreach(ColumnDefinition j in Board.ColumnDefinitions.Skip(1))
				{
					iCol++;
					
					panel = new Border();
					Grid.SetColumn(panel, iCol);
					Grid.SetRow(panel, iRow);

					if (w.map[iCol-1, iRow-1].Glitter && w.map[iCol-1, iRow-1].CurrentAgent1 != null)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/GoldAgent.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Glitter)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/Gold.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].CurrentAgent1 != null)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/EmptyAgent.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Wumpus == true)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/Wumpus.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Pit == true)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/Pit.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Stench && w.map[iCol-1, iRow-1].Visited == true)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/StenchV.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Breeze && w.map[iCol-1, iRow-1].Visited == true)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/BreezeV.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Stench)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/StenchNotV.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Breeze)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/BreezeNotV.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Visited)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/EmptyV.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else {
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/EmptyNotV.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					
					Board.Children.Add(panel);
					
				}
				
			}
			//Show KnowledgeBase
			kb = new KnowledeBaseGUI(a.Kb);
			kb.WindowStartupLocation = WindowStartupLocation.Manual;
			kb.Left = 790;
			kb.Top = 50;
			kb.Show();
			//Agent a = new Agent(w);

			//for (int c = 0; c < size; c++)
			//	myTable.Columns.Add(new TableColumn());

			//for (int i = 0; i < size; i++)
			//{	

			//	TableRow tr = new TableRow();

			//	for (int j = 0; j < size; j++) {

			//		TableCell tc = new TableCell(new Paragraph(new Run("-")))
			//		{
			//			BorderThickness = new Thickness(1),

			//			BorderBrush = new SolidColorBrush(Color.FromRgb(79, 129, 189))
			//		};
			//		tr.Cells.Add(tc);
			//	}


			//	TableRowGroup trg = new TableRowGroup();
			//	trg.Rows.Add(tr);
			//	myTable.RowGroups.Add(trg);
			//}

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Step();
		}

		private void Step()
		{
			


			Board.Children.Clear();
			//Setting XY title 
			Border panell = new Border();
			Grid.SetColumn(panell, 0);
			Grid.SetRow(panell, 0);

			Label lb1 = new Label();
			lb1.Content = "Y/X";

			panell.Child = lb1;
			Board.Children.Add(panell);

			//Numbering Rows
			for (int j = 1; j <= w.Size; j++)
			{
				Border panel = new Border();
				Grid.SetColumn(panel, 0);
				Grid.SetRow(panel, j);

				Label lb = new Label();
				lb.Content = j - 1;

				panel.Child = lb;
				Board.Children.Add(panel);

			}
			//Numbering Columns
			for (int i = 1; i <= w.Size; i++)
			{
				Border panel = new Border();
				Grid.SetColumn(panel, i);
				Grid.SetRow(panel, 0);
				Label lb = new Label();
				lb.Content = i - 1;
				panel.Child = lb;
				Board.Children.Add(panel);
			}
			int iRow = 0;

			//Putting Art for each row of the board
			foreach (RowDefinition i in Board.RowDefinitions.Skip(1))
			{
				iRow++;
				int iCol = 0;
				foreach (ColumnDefinition j in Board.ColumnDefinitions.Skip(1))
				{

					iCol++;
					Border panel = new Border();
					Grid.SetColumn(panel, iCol);
					Grid.SetRow(panel, iRow);
					if (agentwon && w.map[iCol-1, iRow-1].CurrentAgent1 != null)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/GoldAgent.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (agentdead && w.map[iCol-1, iRow-1].CurrentAgent1 != null)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/DeadAgent.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Glitter && w.map[iCol-1, iRow-1].CurrentAgent1 != null)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/GoldAgent.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Glitter)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/Gold.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].CurrentAgent1 != null)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/EmptyAgent.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Wumpus == true)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/Wumpus.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Pit == true)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/Pit.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Stench && w.map[iCol-1, iRow-1].Visited == true)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/StenchV.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Breeze && w.map[iCol-1, iRow-1].Visited == true)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/BreezeV.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Stench)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/StenchNotV.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Breeze)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/BreezeNotV.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else if (w.map[iCol-1, iRow-1].Visited)
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/EmptyV.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					else
					{
						Image im = new Image();
						ImageSource imageSource = new BitmapImage(new Uri("/Art/EmptyNotV.png", UriKind.Relative));
						im.Source = imageSource;
						panel.Child = im;
					}
					Board.Children.Add(panel);

				}

			}
			if (!agentdead && !agentwon)
			{
				try
				{
					a.Step();
					GameText.Text = a.Textb1;
				}
				catch (Exception ex)
				{
					if (ex.Message.Equals("The agent collected the gold and won"))
					{
						GameText.Text = "The agent collected the gold and won";
						GameText.IsEnabled = false;
						a.Performance += 1000;
						agentwon = true;
					}
					else
					{
						GameText.Text = "The agent Died";
						GameText.IsEnabled = false;
						a.Performance -= 1000;
						agentdead = true;
					}

					step.IsEnabled = false;
					step.Visibility = 0;
					Step();

				}
			}
				//update KnowledeBase Content on screen
				kb.UpdateText();
			
		}
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			kb.Hide();
			kb.Close();
			PlEngine.PlCleanup();
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			kb.Hide();
			kb.Close();
			PlEngine.PlCleanup();
		}

	}
}
