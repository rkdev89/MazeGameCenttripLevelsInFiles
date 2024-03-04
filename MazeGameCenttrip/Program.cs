using MazeGameCenttrip;

//Game currentGame = new Game();
//currentGame.Start();

//string filePath = "Level3.txt";
//MazeSolver solver = new(filePath);
//solver.SolveMaze();




//Working maze generator
//-----------------------------------
int width = 41; // Should be odd
int height = 41; // Should be odd

MazeGenerator mazeGenerator = new MazeGenerator(width, height);
double wallChance = 2.9; // Adjust this value to change the chance of a wall being created
mazeGenerator.GenerateMaze(wallChance);

Console.WriteLine("Generated Maze:");
mazeGenerator.PrintMaze();
//------------------------------------------------------
