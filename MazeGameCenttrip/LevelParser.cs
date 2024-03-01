namespace MazeGameCenttrip;
public class LevelParser
{
    public static string[,] ParseFileToArray(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        var firstLine = lines[0];
        var rows = lines.Length;
        var cols = firstLine.Length;
        string[,] grid = new string[rows, cols];
        
        for (var i = 0; i < rows; i++)
        {
            var line = lines[i];
            for (var j = 0; j< cols; j++)
            {
                char currentChar = line[j];
                grid[i, j] = currentChar.ToString();
            }
        }
        return grid;
    }
}
