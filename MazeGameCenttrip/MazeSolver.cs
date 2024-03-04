namespace MazeGameCenttrip;
public class MazeSolver
{
    private char[,] maze;
    private int rows;
    private int cols;
    private List<(int, int)> shortestPath;

    public MazeSolver(string filePath)
    {
        ReadMazeFromFile(filePath);
    }

    private void ReadMazeFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        rows = lines.Length;
        cols = lines[0].Length;
        maze = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                maze[i, j] = lines[i][j];
            }
        }
    }

    public void SolveMaze()
    {
        shortestPath = BFS(FindStartPoint());

        if (shortestPath.Count > 0)
        {
            Console.WriteLine("Solution found:");
            PrintMazeWithShortestPath();
        }
        else
        {
            Console.WriteLine("No solution found.");
        }
    }

    private List<(int, int)> BFS((int, int) start)
    {
        bool[,] visited = new bool[rows, cols];
        Queue<(int, int)> queue = new Queue<(int, int)>();
        Dictionary<(int, int), (int, int)> parent = new Dictionary<(int, int), (int, int)>();
        List<(int, int)> path = new List<(int, int)>();

        queue.Enqueue(start);
        visited[start.Item1, start.Item2] = true;
        parent[start] = start;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int row = current.Item1;
            int col = current.Item2;

            if (maze[row, col] == 'X')
            {
                // Reconstruct path
                while (current != start)
                {
                    path.Insert(0, current);
                    current = parent[current];
                }
                path.Insert(0, start);
                break;
            }

            int[] dr = { -1, 1, 0, 0 };
            int[] dc = { 0, 0, -1, 1 };

            for (int i = 0; i < 4; i++)
            {
                int newRow = row + dr[i];
                int newCol = col + dc[i];

                if (IsValidMove(newRow, newCol) && maze[newRow, newCol] == ' ' && !visited[newRow, newCol])
                {
                    visited[newRow, newCol] = true;
                    queue.Enqueue((newRow, newCol));
                    parent[(newRow, newCol)] = current;
                }
            }
        }

        return path;
    }

    private bool IsValidMove(int row, int col)
    {
        return row >= 0 && row < rows && col >= 0 && col < cols;
    }

    private (int, int) FindStartPoint()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (maze[i, j] == 'O')
                {
                    return (i, j);
                }
            }
        }
        throw new Exception("Start point not found in the maze.");
    }

    private void PrintMazeWithShortestPath()
    {
        foreach (var position in shortestPath)
        {
            if (maze[position.Item1, position.Item2] != 'O' && maze[position.Item1, position.Item2] != 'X')
            {
                maze[position.Item1, position.Item2] = '*';
            }
        }

        PrintMaze();
    }

    private void PrintMaze()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(maze[i, j]);
            }
            Console.WriteLine();
        }
    }
}
