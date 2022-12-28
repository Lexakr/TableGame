/*using TableGame;
using TableGame.game;
using TableGame.map;

Map? _map = null;
MapStat? _mapStat = null;
GameStat? _gameStat = null;
List<Player>? _players = null;
Game? _game = null;

Menu menu = new();
string userInput;

// Главное меню
while (true)
{
    menu.DrawMainMenu();
    userInput = Console.ReadKey().KeyChar.ToString();
    if (userInput == "1")
    {
        Console.Clear();
        Console.WriteLine("Starting game...");
        Thread.Sleep(500);
        menu.DrawSetupMenu();
        break;
    }
    if (userInput == "2")
    {
        menu.DrawLoad();
        string fileName;
        fileName = Console.ReadLine();
        if (GameLoader.LoadGame(fileName) != null) break; // TODO 
        else Thread.Sleep(2000);
    }
    if (userInput == "3")
    {
        menu.DrawAbout();
    }
    if (userInput == "0")
    {
        menu.DrawExit();
    }
}

// Меню начала игры
while (true)
{
    menu.DrawSetupMenu();
    userInput = Console.ReadKey().KeyChar.ToString();
    if (userInput == "1")
    {
        Console.Clear();
        Console.Write("Enter map size X: ");
        int size_x = Int32.Parse(Console.ReadLine());
        Console.Write("Enter map size Y: ");
        int size_y = Int32.Parse(Console.ReadLine());
        Console.Write("Enter map name: ");
        string mName = Console.ReadLine();
        _map = new(size_x, size_y, mName);
    }
    if (userInput == "2")
    {
        Console.Clear();
        Console.Write("Enter number of moves: ");
        int movesNum = Int32.Parse(Console.ReadLine());
        _gameStat = new(movesNum);
    }
    if (userInput == "3")
    {
        _players = new()
        {
            new Player(),
        };
    }
    if (userInput == "4")
    {
        if (_map != null && _gameStat != null && _players != null)
        {
            _game = new(_map, _gameStat, _players);
            // Все готово для игры, очищаем консоль
            Console.Clear();
            break;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Not all parameters set!"); // Переделать проверки ввода всего
            Thread.Sleep(1000);
        }
    }
}

Console.WriteLine(_game.GameMap.Name);
GameLoader.SaveGame(_game, "game");
_game = null;
_game = GameLoader.LoadGame("game");
Console.WriteLine(_game.MapStats.ShowMapStats);
Console.ReadKey();*/