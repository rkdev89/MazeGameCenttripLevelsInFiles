using static System.Console;

namespace MazeGameCenttrip;
public class World
{
    private string[,] Grid;
    private int Rows;
    private int Cols;

    public World(string[,]grid)
    {
        Grid = grid;
        Rows = Grid.GetLength(0);
        Cols = Grid.GetLength(1);
    }

    public void Draw()
    {
        for (int i = 0; i < Rows; i++)
        {
            for(int j = 0; j < Cols; j++)
            {
                var element = Grid[i, j];
                SetCursorPosition(j, i);
                
                if (element == "X")
                {
                    ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    ForegroundColor = ConsoleColor.White;
                }
                Write(element);
            }
        }
    }
    
    public string GetElementAt(int x, int y)
    {
        return Grid[y, x];
    }

    public bool IsPositionWalkable(int x, int y)
    {
        if(x < 0 || y < 0) return false;

        if(x>= Cols || y >= Rows) return false;

        return Grid[y,x] == " " || Grid[y,x] == "X";
    }
}
