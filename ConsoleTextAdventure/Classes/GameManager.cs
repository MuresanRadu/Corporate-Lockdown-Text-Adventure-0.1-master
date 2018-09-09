using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateLockdown
{
    static class GameManager
    {
        #region Public Methods
        public static void ShowTitleScreen()
        {
            
            Console.Clear();
            Console.Title = "Corporate Lockdown v1.0.0";
            Console.WriteLine(@"+--------------------------------------------------------+");
            Console.WriteLine(@" _____                                          _         ");
            Console.WriteLine(@"/  __ \                                        | |        ");
            Console.WriteLine(@"| /  \/  ___   _ __  _ __    ___   _ __   __ _ | |_   ___ ");
            Console.WriteLine(@"| |     / _ \ | '__|| '_ \  / _ \ | '__| / _` || __| / _ \");
            Console.WriteLine(@"| \__/\| (_) || |   | |_) || (_) || |   | (_| || |_ |  __/");
            Console.WriteLine(@" \____/ \___/ |_|   | .__/  \___/ |_|    \__,_| \__| \___|");
            Console.WriteLine(@"                    | |                                   ");
            Console.WriteLine(@"                    |_|                                   ");
            Console.WriteLine(@" _                   _         _                          ");
            Console.WriteLine(@"| |                 | |       | |                         ");
            Console.WriteLine(@"| |      ___    ___ | | __  __| |  ___  __      __ _ __   ");
            Console.WriteLine(@"| |     / _ \  / __|| |/ / / _` | / _ \ \ \ /\ / /| '_ \  ");
            Console.WriteLine(@"| |____| (_) || (__ |   < | (_| || (_) | \ V  V / | | | | ");
            Console.WriteLine(@"\_____/ \___/  \___||_|\_\ \__,_| \___/   \_/\_/  |_| |_| ");
            Console.WriteLine(@"+--------------------------------------------------------+");
            Console.WriteLine("\nNOTE: You can write 'help' at any time to see a list of commands.");
            Console.WriteLine("\nPress Enter to start the Game");
            var keyInfo = Console.ReadKey();
            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey(true);
            }
            Console.CursorVisible = false;

            Console.CursorVisible = true;
            Console.Clear();
        }

        public static void StartGame()
        {
            Player.GetCurrentRoom().Describe();
            TextBuffer.Display();
        }

        public static void EndGame(string endingText)
        {
            Program.quit = true;
            Console.Clear();
            Console.WriteLine(TextUtils.WordWrap(endingText, Console.WindowWidth));
            Console.WriteLine("\nYou may now close this window.");
            Console.CursorVisible = false;
            while (true)
            {
                Console.ReadKey(true); //Will wait for a key but not show the keys pressed.
            }
        }

        public static void ApplyRules()
        {
            #region Test Rules
            if (Level.Rooms[0, 0].GetItem("red ball") != null &&
                Level.Rooms[1, 0].GetItem("blue ball") != null &&
                Level.Rooms[1, 0].GetItem("yellow ball") != null &&
                Level.Rooms[0, 1].GetItem("green ball") != null)
            {
                EndGame("Great job, you win!");
            }

            if (Player.GetInventoryItem("Key") != null)
            {
                Level.Rooms[0, 0].AddExit(Direction.South); //red room
                Level.Rooms[0, 0].Description = "You have entered the Red Room";

                Level.Rooms[0, 1].AddExit(Direction.North); //green room
                Level.Rooms[0, 1].Description = "You have entered the Green Room";
            }

            if (Player.Moves > 10)
            {
                EndGame("You are old and die.");
            }
            #endregion Test Rules
        }
        #endregion Public Methods
    }
}
