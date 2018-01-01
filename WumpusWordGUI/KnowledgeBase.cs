using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbsSW.SwiPlCs;
using System.IO;
using SbsSW.SwiPlCs.Exceptions;
using System.Diagnostics;

namespace Wumpus_World
{
    public class KnowledgeBase
    {
		private String Agentsrequests = "";
		public KnowledgeBase()
		{
			
			// Build a prolog source file (skip this step if you already have one :-)
			//string filename = Path.GetFileName("C:\\Users\\abrhm\\Source\\Repos\\Wumpus-World\\Wumpus World\\Packages\\Agentkb");
			// build the parameterstring to Initialize PlEngine with the generated file
			String[] param = { "-q", "-f", "Prolog/Agentkb.pl" };
			if (!PlEngine.IsInitialized)
			{
				try
				{
					//initializing prolog engine
					PlEngine.Initialize(param);
					//PlQuery.PlCall("sensebreeze(true,[1,1])");
					//Boolean q = PlQuery.PlCall("ispit([2,1])");
					//Console.WriteLine(q);
					//PlQuery.PlCall("sensebreeze(false,[1,1])");
					// q = PlQuery.PlCall("ispit([2,1])");
					//Console.WriteLine(q);
					
				}
				catch (PlException e)
				{
					Debug.WriteLine(e.MessagePl);
					Debug.WriteLine(e.Message);
				}
			}
			
			//if (!PlEngine.IsInitialized)
			//{
			//	String[] param = { "-q" };  // suppressing informational and banner messages
			//	PlEngine.Initialize(param);
			//	PlQuery.PlCall("assert(wumpus(1,1))");
			//	PlQuery.PlCall("assert(wumpus(1,2))");
			//	PlQuery.PlCall("assert(father(uwe, melanie))");
			//	PlQuery.PlCall("assert(father(uwe, ayala))");

			//	var w = new PlQuery("wumpus(X,Y)");
			//	foreach(PlQueryVariables z in w.SolutionVariables)
			//	{
			//		Console.WriteLine(z["X"].ToString());

			//	}


			//	using (var q = new PlQuery("father(P, C), atomic_list_concat([P,' is_father_of ',C], L)"))
			//	{
			//		foreach (PlQueryVariables v in q.SolutionVariables)
			//			Console.WriteLine(v["L"].ToString());

			//		Console.WriteLine("all children from uwe:");
			//		q.Variables["P"].Unify("uwe");
			//		foreach (PlQueryVariables v in q.SolutionVariables)
			//			Console.WriteLine(v["C"].ToString());
			//	}
			//	PlEngine.PlCleanup();
			//	Console.WriteLine("finshed!");
			//}
		}

		public string Getcontent()
		{
			string s = "";
			var w = new PlQuery("iswumpus(A)");
			foreach(PlQueryVariables z in w.SolutionVariables)
			{
				s+="  iswumpus("+(z["A"].ToString())+").\n";

			}
			w = new PlQuery("nowumpus(A)");
			foreach (PlQueryVariables z in w.SolutionVariables)
			{
				s += "  nowumpus(" + (z["A"].ToString()) + ").\n";

			}
			w = new PlQuery("ispit(A)");
			foreach (PlQueryVariables z in w.SolutionVariables)
			{
				s += "  ispit(" + (z["A"].ToString()) + ").\n";

			}
			w = new PlQuery("nopit(A)");
			foreach (PlQueryVariables z in w.SolutionVariables)
			{
				s += "  nopit(" + (z["A"].ToString()) + ").\n";

			}
			return s;

		}
		public string Getagentcontent()
		{
			string tempagent = Agentsrequests;
			Agentsrequests = "";
			return tempagent;
		}
			public bool ispit(int x, int y)
        {
			String line = "ispit(["+x+","+y+"])" ;
			//Console.WriteLine(line);
			return PlQuery.PlCall(line);
		}

		public bool iswumpus(int x, int y)
		{
			String line = "iswumpus([" + x + "," + y + "])";
			//Console.WriteLine(line);
			return PlQuery.PlCall(line);
		}

		public void tell(bool breeze,bool stench, bool glitter,int x,int y) {
			
			String line= "sensebreeze(a" + breeze + ",["+x+","+y+"])";

			//Writing to GUI
			Agentsrequests += line+ ":-\n";
			if (breeze)
			{
				Agentsrequests += " A1 is "+(x+1)+ " , (nopit([A1, " + y + "]); assert(ispit([A1," + y+"]))),\n";
				Agentsrequests += "A2 is " + (x - 1) + " , (nopit([A2, " + y + "]); assert(ispit([A2," + y + "]))),\n";
				Agentsrequests += "A3 is " + (y - 1) + " , (nopit([" + x + ", A3]); assert(ispit([" + x+", A3]))),\n";
				Agentsrequests += "A4 is " + (y + 1) + " , (nopit([" + x + ", A4]); assert(ispit([" + x + ", A4]))).\n";
			}
			else
			{
				Agentsrequests += "A1 is " + (x + 1) + " , retractall(ispit([A1, " + y + "])), assert(nopit([A1, " + y + "])),\n";
				Agentsrequests += "A2 is " + (x - 1) + " , retractall(ispit([A2, " + y + "])), assert(nopit([A2, " + y + "])),\n";
				Agentsrequests += "A3 is " + (y - 1) + " , retractall(ispit([" + x + ", A3])), assert(nopit([" + x + ", A3])),\n";
				Agentsrequests += "A4 is " + (y + 1) + " , retractall(ispit([" + x + ", A4])), assert(nopit([" + x + ", A4])).\n";
			}
			//Console.WriteLine(line);
			PlQuery.PlCall(line);

			//Writing to GUI
			line = "sensestench(a" + stench + ",[" + x + "," + y + "])";
			Agentsrequests += line + ":-\n";
			if (stench)
			{
				Agentsrequests += " A1 is " + (x + 1) + " , (nowumpus([A1, " + y + "]); assert(iswumpus([A1," + y + "]))),\n";
				Agentsrequests += "A2 is " + (x - 1) + " , (nowumpus([A2, " + y + "]); assert(iswumpus([A2," + y + "]))),\n";
				Agentsrequests += "A3 is " + (y - 1) + " , (nowumpus([" + x + ", A3]); assert(iswumpus([" + x + ", A3]))),\n";
				Agentsrequests += "A4 is " + (y + 1) + " , (nowumpus([" + x + ", A4]); assert(iswumpus([" + x + ", A4]))).\n";
			}
			else
			{
				Agentsrequests += "A1 is " + (x + 1) + " , retractall(iswumpus([A1, " + y + "])), assert(nowumpus([A1, " + y + "])),\n";
				Agentsrequests += "A2 is " + (x - 1) + " , retractall(iswumpus([A2, " + y + "])), assert(nowumpus([A2, " + y + "])),\n";
				Agentsrequests += "A3 is " + (y - 1) + " , retractall(iswumpus([" + x + ", A3])), assert(nowumpus([" + x + ", A3])),\n";
				Agentsrequests += "A4 is " + (y + 1) + " , retractall(iswumpus([" + x + ", A4])), assert(nowumpus([" + x + ", A4])).\n";
			}


			//Console.WriteLine(line);
			PlQuery.PlCall(line);

		}
		public void TellScream(int x, int y)
		{

			String line = "retractall(iswumpus([" + x + "," + y + "]))";
			//Console.WriteLine(line);
			PlQuery.PlCall(line);

			line = "assert(nowumpus([" + x + "," + y + "]))";
			//Console.WriteLine(line);
			PlQuery.PlCall(line);

		}

	}

    
}
