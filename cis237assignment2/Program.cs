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
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// <summary>
            /// Starting Coordinates.
            /// </summary>
            // since array indexes start at zero, this 
            // will start the point 1 over and 1 down
            // from the upper left corner
            const int X_START = 1;
            const int Y_START = 1;

            ///<summary>
            /// The first maze that needs to be solved.
            /// Note: You may want to make a smaller version to test and debug with.
            /// You don't have to, but it might make your life easier.
            /// </summary>
            char[,] maze1 = 
            { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '.' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

            /// <summary>
            /// Create a new instance of a mazeSolver.
            /// </summary>
            MazeSolver mazeSolver = new MazeSolver();

            //Create the second maze by transposing the first maze
            char[,] maze2 = transposeMaze(maze1);

            /// <summary>
            /// Tell the instance to solve the first maze with 
            /// the passed maze, and start coordinates.
            /// </summary>
            // call the maze solver passing through the first(original) maze
            mazeSolver.SolveMaze(maze1, X_START, Y_START);

            // clear the console 
            // don't continue until the user presses a key
            
            Console.WriteLine("Press any key to read the next array");
            Console.ReadKey();  // wait for the user to press a key
            Console.Clear();    // clear the contents of the array

            /// <summary>
            /// Tell the instance to solve the second(transposed)
            /// maze with the passed maze, and start coordinates.
            /// </summary>
            //Solve the transposed maze.
            // call the maze solver passing through the second(transposed) maze
            mazeSolver.SolveMaze(maze2, X_START, Y_START);

        }

        /// <summary>
        /// This method will take in a 2 dimensional char array and return
        /// a char array maze that is flipped along the diagonal, or in mathematical
        /// terms, transposed.
        /// ie. if the array looks like 1, 2, 3
        ///                             4, 5, 6
        ///                             7, 8, 9
        /// The returned result will be:
        ///                             1, 4, 7
        ///                             2, 5, 8
        ///                             3, 6, 9
        /// The current return statement is just a placeholder so the program
        /// doesn't complain about no return value.
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
        static char[,] transposeMaze(char[,] mazeToTranspose)
        {
            // create a new char array (maze) that is the same size(dimensions) as the first array
            // zero ferences the left side of the comma and 1 represents the right
            char[,] maze = new char[mazeToTranspose.GetLength(0), mazeToTranspose.GetLength(1)];

            // create two ints for the for loop
            int x, y;
            // for loop that iterates through the rows (x) of the array
            for (x = 0; x <= 11; x++)
            {
                // for loop that iterates through the columns (y) of the array
                for (y = 0; y <= 11; y++)
                {
                    // actively relaces each index from the old array with
                    // the opposite index into mazeTranspose
                    maze[x, y] = mazeToTranspose[y, x];
                }
            }
            // returns the new maze after 
            // completing the for loop
            return maze;
        }
    }
}
