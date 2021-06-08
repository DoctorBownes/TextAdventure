using System.Collections.Generic;

namespace Zuul
{
	public class CommandLibrary
	{
		// a List that holds all valid command words
		private List<string> validCommands;

		/**
		 * Constructor - initialise the command words.
		 */
		public CommandLibrary()
		{
			validCommands = new List<string>();

			validCommands.Add("look");
			validCommands.Add("status");
			validCommands.Add("help");
			validCommands.Add("go");
			validCommands.Add("take");
			validCommands.Add("use");
			validCommands.Add("drop");
			validCommands.Add("quit");
		}

		/**
		 * Check whether a given string is a valid command word.
		 * Return true if it is, false if it isn't.
		 */
		public bool IsCommand(string instring)
		{
			for (int i = 0; i < validCommands.Count; i++)
			{
				if (validCommands[i] == instring)
				{
					return true;
				}
			}
			// if we get here, the string was not found in the commands
			return false;
		}

		/**
		 * returns a list of valid command words as a string.
		 */
		public string GetCommandsString()
		{
			string str = "";
			for (int i = 0; i < validCommands.Count; i++)
			{
				str += validCommands[i];
				// Add a comma after every element in the List, but not the last.
				if (i != validCommands.Count - 1)
				{
					str += ", ";
				}
			}
			return str;
		}
	}
}
