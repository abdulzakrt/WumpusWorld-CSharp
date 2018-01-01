using System;
using System.Drawing;

namespace Wumpus_World
{
	class World
    {

        public MapSquare[,] map ;
		private int size;
		private int numofpits;
		private int numofwumpus;		
		Random r = new Random();

		public World(int siZe, int pits,int wumpus) {
			size = siZe;
            map = new MapSquare[size, size];
			numofpits = pits;
			numofwumpus = wumpus;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    map[i, j] = new MapSquare();
                }
               
            }
            
        }
		

		public int Size { get => size; set => size = value; }

		public void InitializeSpecificWorld(WorldPlacements p)
		{
			foreach (Point i in p.Wumpuses)
			{
				Placewumpus(i.X, i.Y);
			}
			foreach (Point j in p.Pits)
			{
				Placepit(j.X, j.Y);
			}
			map[(int)p.Gold.X, (int)p.Gold.Y].Glitter = true;

		}
		public void InitializeRandomWorld()
        {
            //Random Number Generator
            
            int x=0,y=0;
			//Adding a wumpus
			for (int m = 0; m < numofwumpus; m++)
			{
				x = r.Next(1, size);
				y = r.Next(1, size);
				while (x == 0 && y == 0)
				{
					x = r.Next(1, size);
					y = r.Next(1, size);
				}
				Placewumpus(x, y);
			}
            //Adding numofpits pits
            for(int i = 0; i < numofpits; i++)
            {
                x = r.Next(0, size);
                y = r.Next(0, size);
                while (map[x,y].Pit || map[x, y].Wumpus || (x==0 && y==0)) {
                    x = r.Next(0, size);
                    y = r.Next(0, size);
                }
				Placepit(x, y);
                
            }
            //Adding Gold
            x = r.Next(0, size);
            y = r.Next(0, size);
            while (map[x, y].Pit || map[x, y].Wumpus || (x == 0 && y == 0))
            {
                x = r.Next(0, size);
                y = r.Next(0, size);
            }
            map[x, y].Glitter = true;
           
            

        }
		private void Placewumpus(int x,int y)
		{
			map[x, y].Wumpus = true;
			//map[x, y].Stench = true;
			if (x + 1 < size && x + 1 >= 0)
			{
				map[x + 1, y].Stench = true;
			}
			if (x - 1 < size && x - 1 >= 0)
			{
				map[x - 1, y].Stench = true;
			}
			if (y + 1 < size && y + 1 >= 0)
			{
				map[x, y + 1].Stench = true;
			}
			if (y - 1 < size && y - 1 >= 0)
			{
				map[x, y - 1].Stench = true;
			}
		}
		private void Placepit(int x, int y)
		{
			map[x, y].Pit = true;
			map[x, y].Breeze = true;
			if (x + 1 < size && x + 1 >= 0)
			{
				map[x + 1, y].Breeze = true;
			}
			if (x - 1 < size && x - 1 >= 0)
			{
				map[x - 1, y].Breeze = true;
			}
			if (y + 1 < size && y + 1 >= 0)
			{
				map[x, y + 1].Breeze = true;
			}
			if (y - 1 < size && y - 1 >= 0)
			{
				map[x, y - 1].Breeze = true;
			}
		}
		public void PrintMap() {
			Console.WriteLine();
			Console.WriteLine("______________________________________________");
			Console.WriteLine("   0         1         2         3");
            for (int i = 0; i < size; i++) {
                Console.Write(i+"  ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write(map[j,i].ReturnSquare());
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("(W = Wumpus, St=Stench, Br=Breeze, Gl=Glitter, Sc=Scream, V=Visited, Sa=Safe, P=Pit, A=Agent)");
        }

        
    }
}
