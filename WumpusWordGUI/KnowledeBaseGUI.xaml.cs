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
	/// Interaction logic for KnowledeBaseGUI.xaml
	/// </summary>
	public partial class KnowledeBaseGUI : Window
	{
		KnowledgeBase k;
		
		public KnowledeBaseGUI(KnowledgeBase k)
		{
			this.k = k;
			InitializeComponent();
			KBText.Text = "Prolog's KnowledgeBase will be here";
			AgentText.Text = "Agent's Prolog Requests will be here";
		}
		public void  UpdateText()
		{
			AgentText.Text = k.Getagentcontent();
			KBText.Text = k.Getcontent();
		}

	}
}
