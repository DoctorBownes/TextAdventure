using System;

namespace Zuul
{
	public class Game
	{
		private Parser parser;
		private Player player1;

		public Game ()
		{
			CreateRooms();
			parser = new Parser();
		}

		private void CreateRooms()
		{
			// create the rooms
			Room outside = new Room("outside the main entrance of the university");
			Room theatre = new Room("in a lecture theatre");
			Room pub = new Room("in the campus pub");
			Room lab = new Room("in a computing lab");
			Room office = new Room("in the computing admin office");
			Room lowerpub = new Room("basement of the campus pub");
			Item knife = new Item(80, "knife");
			Item medkit = new Medkit();

			// initialise room exits
			outside.AddExit("east", theatre);
			outside.AddExit("south", lab);
			outside.AddExit("west", pub);
			outside.Chest.Put(knife);
			outside.Chest.Put(medkit);

			theatre.AddExit("west", outside);

			pub.AddExit("east", outside);
			pub.AddExit("down", lowerpub);
			lowerpub.AddExit("up", pub);

			lab.AddExit("north", outside);
			lab.AddExit("east", office);

			office.AddExit("west", lab);

			player1 = new Player(outside);
		}

		/**
		 *  Main play routine.  Loops until end of play.
		 */
		public void Play()
		{
			PrintWelcome();

			// Enter the main command loop.  Here we repeatedly read commands and
			// execute them until the player wants to quit.
			bool finished = false;
			while (!finished && player1.isAlive())
			{
				Command command = parser.GetCommand();
				finished = ProcessCommand(command);
			}
			Console.WriteLine("Thank you for playing.");
			Console.WriteLine("Press any key to continue.");
			Console.ReadKey();
		}

		/**
		 * Print out the opening message for the player.
		 */
		private void PrintWelcome()
		{
			Console.WriteLine();
			Console.WriteLine("Welcome to Zuul!");
			Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
			Console.WriteLine("Type 'help' if you need help.");
			Console.WriteLine();
			Console.WriteLine(player1.GetCurrentRoomDesc());
		}

		/**
		 * Given a command, process (that is: execute) the command.
		 * If this command ends the game, true is returned, otherwise false is
		 * returned.
		 */
		private bool ProcessCommand(Command command)
		{
			bool wantToQuit = false;

			if(command.IsUnknown())
			{
				Console.WriteLine("I don't know what you mean...");
				return false;
			}

			string commandWord = command.GetCommandWord();
			switch (commandWord)
			{
				case "look":
					PrintLook();
					break;
				case "status":
					PrintStatus();
					break;
				case "take":
					Take(command);
					break;
				case "use":
					UseItem(command);
					break;
				case "drop":
					Drop(command);
					break;
				case "help":
					PrintHelp();
					break;
				case "go":
					GoRoom(command);
					break;
				case "quit":
					wantToQuit = true;
					break;
			}

			return wantToQuit;
		}

		// implementations of user commands:

		/**
		 * Print out some help information.
		 * Here we print the mission and a list of the command words.
		 */
		private void PrintHelp()
		{
			Console.WriteLine("You are lost. You are alone.");
			Console.WriteLine("You wander around at the university.");
			Console.WriteLine();
			// let the parser print the commands
			parser.PrintValidCommands();
		}
		private void PrintLook()
		{
			Console.WriteLine(player1.GetCurrentRoomDesc());
			Console.WriteLine(player1.GetCurrentRoomItems());
			Console.WriteLine();
		}
		private void PrintStatus()
		{
			Console.WriteLine(player1.HealPlayer(0));
			Console.WriteLine(player1.GetPlayerItems());
			Console.WriteLine();
		}

		private void Take(Command command)
		{
			if (player1.TakeFromChest(command.GetSecondWord()))
			{
				player1.TakeFromChest(command.GetSecondWord());
			}
		}
		private void UseItem(Command command)
		{
			if (!command.HasThirdWord())
			{
				//player1.Use(command.GetSecondWord());
			}
		}
		private void Drop(Command command)
		{
			player1.DropToChest(command.GetSecondWord());
		}

		/**
		 * Try to go to one direction. If there is an exit, enter the new
		 * room, otherwise print an error message.
		 */
		private void GoRoom(Command command)
		{
			if(!command.HasSecondWord())
			{
				// if there is no second word, we don't know where to go...
				Console.WriteLine("Go where?");
				return;
			}

			string direction = command.GetSecondWord();

			// Try to go to the next room.
			Room nextRoom = player1.CurrentRoomExits(direction);

			if (nextRoom == null)
			{
				Console.WriteLine("There is no door to "+direction+"!");
			}
			else
			{
				player1.DamagePlayer(10);
				player1.currentRoom = nextRoom;
				Console.WriteLine(player1.GetCurrentRoomDesc());
			}
		}

	}
}
