using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame
{
    internal class Menu
    {
        public void DrawMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Game Main Menu: ");
            Console.WriteLine("1: Start a game");
            Console.WriteLine("2: Load game");
            Console.WriteLine("3: About");
            Console.WriteLine("0: Quit");
        }
        public void DrawLoad() 
        {
            Console.Clear();
            Console.Write("Enter file name: ");
        }
        public void DrawAbout() 
        {
            Console.Clear();
            Console.WriteLine("Minimalistic table game!!!");
            Console.WriteLine("Press any key to go back to the main menu.");
            Console.ReadKey();
        }
        public void DrawExit()
        {
            Console.Clear();
            Console.WriteLine("You are about to exit the game");
            Console.WriteLine("Are you sure: Y/N");
            string userExit = Console.ReadKey().KeyChar.ToString();
            if (userExit.ToUpper() == "Y") Environment.Exit(0);
        }

        /// <summary>
        /// Меню создания игры. 1: настройка карты. 2: настройка сценария. 3: настройка игроков.
        /// </summary>
        public void DrawSetupMenu()
        {
            Console.Clear();
            Console.WriteLine("Game setup: ");
            Console.WriteLine("1: Setup Map");
            Console.WriteLine("2: Setup Game Scenario");
            Console.WriteLine("3: Setup Players");
            Console.WriteLine("4: Play!");
        }

        public void DrawMapSetup()
        {
            Console.Clear();
            Console.WriteLine("Game: ");
        }
    }
}
