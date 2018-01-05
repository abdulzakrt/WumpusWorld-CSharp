# Wumpus World (GUI) - C# with Prolog Implementation 


![Logo](https://github.com/abdulzakrt/WumpusWorld-CSharp/blob/master/WumpusWordGUI/Art/LogoSmaller.png "Logo")

Wumpus World Game is based on knowledgebase agents and is described in the book , Artificial Intelligence : A Modern Approach (Russel - Norvig).

This is an implementation of Wumpus World (a Knowledgebase agent game) using csharp alongside prolog with a GUI.
* C# has the main environment of the game and the GUI
* The GUI was created using WPF , Windows Presentation Foundation
* Prolog is used as the knowledgebase of the agent of Wumpus World
* In order for C# to communicate with Prolog a Csharp interface is used [SWI-Prolog](http://www.lesta.de/prolog/swiplcs/Generated/Index.aspx).
* Author: Abdulrahman Zakrt 
* Date: Jan.02, 2018

Description of the Game
---------
The agent explores a cave consisting of rooms connected to each other. In one of the rooms of the cave lies a Wumpus, a monster that kills the agent if he enters the room. Some rooms contain bottomless pits that trap any agent that wanders into the room. In one of the rooms there is gold. The goal of the agent is to collect the gold and go back to the start room to exit the world without being killed by the Wumpus or falling in one of the pits. The agent always starts at coordinates [1,1] as you can see in figure 1. The agent can only move in a 1 step fashion either vertically or horizontally. The four rooms adjacent to the Wumpus contain a Strench that the agent can perceive in order to help him make decisions. In the same manner, the four adjacent rooms to a pit room contain a breeze that the agent can perceive. When the agent enters a room containing gold, he will be able to sense a glitter. The agent should pick up the gold and deliver it back to the start room to fulfill the game’s main objective. The agent has one arrow that he can use to shoot the Wumpus. The arrow if shot will keep on going in the direction shot until it either hits the end of the cave or kills the Wumpus
<p align="center">
<img src ="https://github.com/abdulzakrt/WumpusWorld-CSharp/blob/master/WumpusWordGUI/Art/wumpusmap.png" />
</p>

Description
---------

The main GUI displays the board game itself and the actions the agent will take along with a description of its reasoning. The GUI shows 
the interaction of the agent with the prolog knowledgebase by showing the knowledgebase itself and the commands the agent asks.


Requirements
---------

This implementation of Wumpus World uses prolog and is based on Dotnet and requires the following:
* 64 bit windows machine , Currently the game only supports 64 bit machines
* SWIPL(v6.6.6) 64 bit (Installed automatically by the game if not available)
* Latest Version of DotNet (Installed automatically by windows)


How to Use
---------

In order to use the GUI only  you can use the setup.exe in the SetupFiles.The setup will check if prolog 
is installed. If not it will automatically install it. After that the game can run.

Source Code
---------

The source code of the implementation is in WumpusWordGUI which is in C#. The visual studio project should have a dependency of SWI-prolog which
is included in the project as swipl.dll. The prolog file is in the Prolog folder and the artwork of the GUI in the Art folder.


