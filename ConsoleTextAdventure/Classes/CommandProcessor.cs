using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateLockdown
{
    static class CommandProcessor
    {
        #region Command Processor
        public static void ProcessCommand(string line)
        {
            var command = TextUtils.ExtractCommand(line.Trim()).Trim().ToLower();
            var arguments = TextUtils.ExtractArgument(line.Trim()).Trim().ToLower();

            if (Direction.IsValidDirection(command))
            {
                Player.Move(command);
            }
            else
            { 
                switch (command)
                {
                    case "exit":
                        Program.quit = true;
                        return;

                    case "help":
                        ShowHelp();
                        break;

                    case "move":
                        Player.Move(arguments);
                        break;

                    case "look":
                        Player.GetCurrentRoom().Describe();
                        break;

                    case "pickup":
                        Player.PickupItem(arguments);
                        break;

                    case "drop":
                        Player.DropItem(arguments);
                        break;

                    case "inventory":
                        Player.DisplayInventory();
                        break;

                    case "whereami":
                        Player.GetCurrentRoom().ShowTitle();
                        break;

                    default:
                        TextBuffer.Add("Input not understood.");
                        break;
                }
            }
            GameManager.ApplyRules();
            TextBuffer.Display();
        }
        #endregion Command Processor

        #region Help Tips
        public static void ShowHelp()
        {
            TextBuffer.Add("Available commands:");
            TextBuffer.Add("+-------------------------------------------------------+");
            TextBuffer.Add("Help");
            TextBuffer.Add("Exit");
            TextBuffer.Add("Move [North, East, South, West]");
            TextBuffer.Add("Look");
            TextBuffer.Add("Pickup");
            TextBuffer.Add("Drop");
            TextBuffer.Add("Inventory");
            TextBuffer.Add("WhereAmI");
            TextBuffer.Add("+-------------------------------------------------------+");
        }
        #endregion Help Tips
    }
}
