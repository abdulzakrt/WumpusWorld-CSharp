using System.Collections.Generic;
using System.Drawing;


namespace Wumpus_World
{
	public class WorldPlacements
	{
		private int size = 0;
		private Point gold;
		private List<Point> wumpuses = new List<Point>();
		private List<Point> pits = new List<Point>();
		public WorldPlacements(List<Point> w, List<Point> p, Point g)
		{
			wumpuses = w;
			pits = p;
			gold = g;
		}

		public List<Point> Wumpuses { get => wumpuses; set => wumpuses = value; }
		public List<Point> Pits { get => pits; set => pits = value; }
		public Point Gold { get => gold; set => gold = value; }
	}
}