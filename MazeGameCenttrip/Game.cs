using static System.Console;

namespace MazeGameCenttrip;
public class Game
{
    private World MyWorld;
    private Player CurrentPlayer;

    public void Start()
    {
        Title = "Welcome to the Centtrip Maze";
        CursorVisible = false;

        var grid = LevelParser.ParseFileToArray("Level1.txt");

        //maybe have a factory to create a world
        MyWorld = new World(grid);
        // maybe have a factory to create player
        CurrentPlayer = new Player(2, 2);
        RunGameLoop();
    }

    private void DisplayIntro()
    {
        WriteLine("Welcome to the Centtrip maze!");
        WriteLine("\nInstructions");
        WriteLine("> Use the arrow keys to move");
        Write("> Try to reach the goal, which looks like this: ");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("X");
        ResetColor();
        WriteLine("> Press any key to start");
        ReadKey(true);
    }

    private void DisplayOutro()
    {
        Clear();
        WriteLine("You completed the maze!");
        WriteLine("Thanks for playing.");
        WriteLine("Press any key to exit");
        ReadKey(true);
    }

    private void DrawFrame()
    {
        Clear();
        MyWorld.Draw();
        CurrentPlayer.Draw();
    }

    private void HandlePlayerInput()
    {
        ConsoleKey key;
        do
        { 
            ConsoleKeyInfo keyInfo = ReadKey(true);
            key = keyInfo.Key;
        }while(KeyAvailable);

        switch (key)
        {
            case ConsoleKey.UpArrow:
                if(MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                {
                    CurrentPlayer.Y -= 1;
                }
                break;
            case ConsoleKey.DownArrow:
                if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                {
                    CurrentPlayer.Y += 1;
                }
                break;
            case ConsoleKey.LeftArrow:
                if(MyWorld.IsPositionWalkable(CurrentPlayer.X - 1,CurrentPlayer.Y))
                {
                    CurrentPlayer.X -= 1;
                }
                break;
            case ConsoleKey.RightArrow:
                if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                {
                    CurrentPlayer.X += 1;
                }
                break;
            default:
                break;
        }
    }

    private void RunGameLoop()
    {
        DisplayIntro();
        while (true)
        {
            DrawFrame();

            HandlePlayerInput();

            var elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
            if (elementAtPlayerPos == "X")
            {
                break;
            }
            Thread.Sleep(20);
        }
        DisplayOutro();
    }
}
