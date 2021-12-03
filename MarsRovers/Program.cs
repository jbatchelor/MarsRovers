using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter grid coordinates");
            string[]? arrGridCoords = Console.ReadLine()?.Split(' ');
            if (arrGridCoords != null) {
                bool xValid = int.TryParse(arrGridCoords[0], out int xWidth);
                bool yValid = int.TryParse(arrGridCoords[1], out int yWidth);
                // if improper chars are used for the grid coords
                // shut down the app
                if (!xValid || !yValid)
                {
                    return;
                }
                // otherwise we are safe to create our SearchGrid
                SearchGrid grid = new SearchGrid(xWidth, yWidth);
                // set up a loop that is only broken if the rover input
                // meets certain conditions
                while (true)
                {
                    if (CheckRoverInput(grid) == false)
                    {
                        break;
                    }
                }
            }
        }

        static bool CheckRoverInput(SearchGrid grid)
        {
            Console.WriteLine("Enter Rover starting position in format X Y Z");
            // get the rover starting coordinates
            string? roverStart = Console.ReadLine();
            if (roverStart == "x" || roverStart == null)
            {
                return false;
            }
            string[] arrRoverCoords = roverStart.Split(' ');
            if (arrRoverCoords.Length != 3)
            {
                return false;
            }
            // create the rover
            Rover rover = new Rover(grid, arrRoverCoords);

            Console.WriteLine("Enter route commands");
            // read the input route
            char[]? commands = Console.ReadLine()?.ToCharArray();

            // give the user multiple ways to end the session ... if 
            // there are no commands given when the user provides a newline
            // or if they enter an 'x', return false to indicate we should
            // break from the loop
            if (commands == null || commands.Length == 1 && commands[0].ToString() == "x")
            { 
                return false; 
            } else {
                rover.ReceiveCommands(commands);
                Console.WriteLine(rover.GetLocation);
                return true;
            }
        }
    }
}