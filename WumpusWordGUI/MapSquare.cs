using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wumpus_World
{
    class MapSquare
    {
        //percepts
        private bool stench, breeze, glitter, scream;
        //facts
        private bool visited, safe, pit, wumpus;
        Agent CurrentAgent = null;

        public bool Stench
        {
            get
            {
                return stench;
            }

            set
            {
                stench = value;
            }
        }

        public bool Breeze
        {
            get
            {
                return breeze;
            }

            set
            {
                breeze = value;
            }
        }

        public bool Glitter
        {
            get
            {
                return glitter;
            }

            set
            {
                glitter = value;
            }
        }

        public bool Scream
        {
            get
            {
                return scream;
            }

            set
            {
                scream = value;
            }
        }

        public bool Visited
        {
            get
            {
                return visited;
            }

            set
            {
                visited = value;
            }
        }

        public bool Safe
        {
            get
            {
                return safe;
            }

            set
            {
                safe = value;
            }
        }

        public bool Pit
        {
            get
            {
                return pit;
            }

            set
            {
                pit = value;
            }
        }

        public bool Wumpus
        {
            get
            {
                return wumpus;
            }

            set
            {
                wumpus = value;
            }
        }

		internal Agent CurrentAgent1 { get => CurrentAgent; set => CurrentAgent = value; }

		public MapSquare()
        {
            stench = breeze = glitter = scream = visited = safe = pit = wumpus = false;
        }

       

        public String ReturnSquare()
        {
            String s = "";
            if (CurrentAgent != null)
                s += "A";
            if (stench)
                s+="St";
            if (breeze)
                s += "Br";
            if (glitter)
                s += "Gl";
            if (scream)
                s += "Sc";
            if (visited)
                s += "V";
            if (safe)
                s += "Sa";
            if (pit)
                s += "P";
            if (wumpus)
                s += "W";
            if (!stench && !breeze && !glitter && !scream && !visited && !safe && !pit && !wumpus )
                s += "-";
            while (s.Length < 10)
            {
                s += " ";
            }
            
                
            return s;
        }
        public void PutAgent(Agent a) {
            CurrentAgent = a;
            visited = true;
        }
        public void RemoveAgent()
        {
            CurrentAgent = null;
            

        }
    }
}
