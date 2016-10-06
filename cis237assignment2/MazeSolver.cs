// Kyle Sherman
// CIS 237
// Due 10/6/2016

// standard imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;       // create a new object to store the passed maze
        int xStart;         // create a new int to store the xstart point
        int yStart;         // create a new int to store the ystart point 
        bool isMazeSolved;  // bool to check if the maze has been solved 

        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        {}


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Do work needed to use mazeTraversal recursive call and solve the maze.

            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;
            isMazeSolved = false;   // initialize isMazeSolved to false

            printMaze();            // call the print maze method
            mazeTraversal(xStart, yStart);  // call the mazeTraversal method

            // change the console text color to red: From https://msdn.microsoft.com/en-us/library/system.console.foregroundcolor(v=vs.110).aspx
            Console.ForegroundColor = ConsoleColor.Red;

            // print a message telling the user the maze has been solved
            Console.WriteLine("\n" + "Maze has been solved successfully." + Environment.NewLine);
            
            // reset the console colors to default
            Console.ResetColor();
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private void mazeTraversal(int xPosition, int yPosition)
        {
            maze[xPosition, yPosition] = 'x';   // replace the current location's . with an X
            printMaze();                        // print the maze
            
            // if the current possition is within the walls of the array (not solved)
            if (xPosition != 11 && xPosition != 0 && yPosition != 11 && yPosition != 0 && !isMazeSolved)
            {
                if (maze[xPosition, yPosition + 1] == '.')      // check if the char above is a .
                {
                    mazeTraversal(xPosition, yPosition + 1);    // if so then move up 1
                }
                if (maze[xPosition, yPosition - 1] == '.')      // check if the char below is a .
                {
                    mazeTraversal(xPosition, yPosition - 1);    // if so then move down 1
                }
                if (maze[xPosition + 1, yPosition] == '.')      // check if the char to the right is a .
                {
                    mazeTraversal(xPosition + 1, yPosition);    // if so then move right 1
                }
                if (maze[xPosition - 1, yPosition] == '.')      // check if the char to the left is a .
                {
                    mazeTraversal(xPosition - 1, yPosition);    // if so then move left 1
                }

                // if none of the above criteria is met and it hasn't been solved
                if (!isMazeSolved)                             
                {
                    // this calls the backtrack method
                    // this occurs when the above fail and we need
                    // to return to the previous location
                    mazeBackTrack(xPosition, yPosition); 
                }
            }
            else    // the maze has successfully been solved 
            {
                isMazeSolved = true;
            }
        }

        // replaces the current location in the array with a 0
        // this symbol indicates that a dead end has been reached
        // this method will also print the array again
        private void mazeBackTrack(int xPosition, int yPosition)
        {
            maze[xPosition, yPosition] = '0';
            printMaze();
        }

        // printMaze method
        // prints out each index of the array based
        // on rows and column from a for loop
        private void printMaze()
        {
            Console.Write("\n\n");
            int i, j;
            // for loop, i(rows) and j(columns)
            for (i = 0; i < 12; i++)
            {
                for (j = 0; j < 12; j++)
                {
                    Console.Write("{0}", maze[i, j]); // print out the current index
                }
                Console.WriteLine();    // blank space between each row
            }
        }

        // this is an old traversal algorithm that I had problems with but 
        // opted to keep it in to look over and debug.
        // The above algorithm is a revised and working version of below
        /**
        private void mazeTraversal(int xPosition, int yPosition)
        {
            bool correctPath = false;
            bool shouldcheck = true;
            int row = xPosition; // i
            int column = yPosition; // j

            // check left
            if(maze[row + 1, column] == '#')
            {
                shouldcheck = false;
                if(maze[row - 1, column] == '#')
                {
                    shouldcheck = false;
                    if (maze[row, column + 1] == '#')
                    {
                        shouldcheck = false;
                        if (maze[row, column - 1] == '#')
                        {
                            shouldcheck = false;
                        }
                        else
                        {
                            yPosition--;
                            correctPath = correctPath || mazeTraversal(xPosition, yPosition);
                        }
                    }
                    else
                    {
                        yPosition++;
                        correctPath = correctPath || mazeTraversal(xPosition, yPosition);
                    }
                }
                else
                {
                    xPosition--;
                    correctPath = correctPath || mazeTraversal(xPosition, yPosition);
                }
            }
            else
            {
                xPosition++;
                correctPath = correctPath || mazeTraversal(xPosition, yPosition);
            }
            if(maze[row, column] == '.')
            {
                correctPath = true;
            }
            if(correctPath)
            {
                maze[xPosition, yPosition] = 'x';
                correctPath = false;
            }

            int i, j;
            Console.Write("\n\n");
            for (i = 0; i < 12; i++)
            {
                for (j = 0; j < 12; j++)
                {
                    Console.Write("{0}", maze[i, j]);
                }
                Console.Write("\n");
            }
        }
         * **/
    }
}
