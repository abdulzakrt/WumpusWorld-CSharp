# Wumpus World (GUI) - C# with Prolog Implementation 


![Logo](https://github.com/abdulzakrt/WumpusWorld-CSharp/blob/master/WumpusWordGUI/Art/LogoSmaller.png "Logo")

Wumpus World Game is based on knowledgebase agents and is described in the book , Artificial Intelligence : A Modern Approach (Russel - Norvig).

This is an implementation of Wumpus World (a Knowledgebase agent game) using csharp alongside prolog with a GUI.
* C# has the main environment of the game and the GUI
* Prolog is used as the knowledgebase of the agent of Wumpus World
* In order for C# to communicate with Prolog a Csharp interface is used [SWI-Prolog](http://www.lesta.de/prolog/swiplcs/Generated/Index.aspx).

Description
---------

The main GUI displays the board game itself and the actions the agent will take based on description of its reasoning. The GUI shows describes
the interaction of the agent with the prolog knowledgebase by showing the knowledgebase itself and the commands, the agent asks.


Requirements
---------

This implementation of Wumpus World uses prolog and is based on Dotnet and requires the following:
* 64 bit machine , Currently the game only works on 64 bit machines
* SWIPL(v6.6.6) 64 bit (Installed automatically by the game if not available)
* Latest Version of DotNet


How to use
---------

In order to use the GUI only without manipulating the source code you can use the setup.exe in the SetupFiles.The setup will check if prolog 
is installed. If not it will automatically install it. After that the game can run.

Source Code
---------

The source code of the implementation is in WumpusWordGUI which is in C#. The visual studio project should have a dependency of SWI-prolog which
is included in the project as swipl.dll. The prolog file is in the Prolog folder and the artwork of the GUI in the Art folder.

