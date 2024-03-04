namespace MazeGameCenttrip;
public class MazeGenerator
{
    private int width;
    private int height;
    private char[,] maze;
    private Random rand;

    public MazeGenerator(int width, int height)
    {
        this.width = width;
        this.height = height;
        maze = new char[width, height];
        InitializeMaze();
        rand = new Random();
    }

    private void InitializeMaze()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if ((i == 0 && j == 0))
                    maze[i, j] = 'S'; // Start point
                else if ((i == width - 1 && j == height - 1))
                    maze[i, j] = 'E'; // Exit point
                else if (i % 2 == 0 || j % 2 == 0)
                    maze[i, j] = '#'; // Walls
                else
                    maze[i, j] = ' '; // Cells
            }
        }
    }

    public void GenerateMaze(double wallChance)
    {
        // Ensure the leftmost and topmost walls are always removed
        for (int j = 1; j < height; j += 2)
        {
            maze[0, j] = ' '; // Remove leftmost walls
        }
        for (int i = 1; i < width; i += 2)
        {
            maze[i, 0] = ' '; // Remove topmost walls
        }

        // Generate the rest of the maze with a specified wall creation chance
        for (int i = 2; i < width; i += 2)
        {
            for (int j = 2; j < height; j += 2)
            {
                if (i == width - 2 && j == height - 2)
                    continue; // Skip the bottom-right cell

                if (rand.NextDouble() < wallChance) // Carve a wall with the specified chance
                {
                    if (rand.Next(2) == 0)
                    {
                        maze[i - 1, j] = ' '; // Carve north
                    }
                    else
                    {
                        maze[i, j - 1] = ' '; // Carve west
                    }
                }
            }
        }
    }

    public void PrintMaze()
    {
        for (int j = 0; j < height; j++)
        {
            for (int i = 0; i < width; i++)
            {
                Console.Write(maze[i, j]);
            }
            Console.WriteLine();
        }
    }
}
