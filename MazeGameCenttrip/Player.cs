using static System.Console;

namespace MazeGameCenttrip;
public class Player
{
    public int X {  get; set; }
    public int Y {  get; set; }
    private string PlayerMarker;
    private ConsoleColor PlayerColor;

    public Player(int x, int y)
    {
        X = x;
        Y = y;
        PlayerMarker = "O";
        PlayerColor = ConsoleColor.Red;
    }

    public void Draw()
    {
        ForegroundColor = PlayerColor;
        SetCursorPosition(X, Y);
        Write(PlayerMarker);
        ResetColor();
    }
}
