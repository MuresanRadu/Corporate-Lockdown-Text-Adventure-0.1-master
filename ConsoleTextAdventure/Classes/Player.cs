using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateLockdown
{

    //delegate void ColorChanged(object sender, ColorChangedEventArgs eventArgs);
    static class Player
    {
        //public static event ColorChanged OnColorChanged;

        #region Variables
        private static int posX;
        private static int posY;
        private static int moves = 0;
        private static int weightCapacity = 6;
        private static List<Item> inventoryItems;
        #endregion

        #region Properties
        public static int PosX { get { return posX; } set { posX = value; } }
        public static int PosY { get { return posY; } set { posY = value; } }
        public static int Moves { get { return moves; } set { moves = value; } }
        public static int WeightCapacity { get { return weightCapacity; } set { weightCapacity = value; } }
        //TODO: Finish Inventory Weight Calculation
        public static int InventoryWeight
        {
            get
            {
                var result = 0;
                foreach (Item item in inventoryItems)
                {
                    result += item.Weight;
                }
                return result;
            }
        }
        #endregion

        #region Constructors
        static Player()
        {
            inventoryItems = new List<Item>();
        }
        #endregion

        #region Public Methods
        public static void Move(string direction)
        {
            Room room = Player.GetCurrentRoom();
            if (!room.CanExit(direction))
            {
                TextBuffer.Add("Invalid Direction");
                return;
            }
            Player.moves++;

            switch (direction)
            {
                case Direction.North:
                    {
                        posY--;
                        break;
                    }
                case Direction.South:
                    {
                        posY++;
                        break;
                    }
                case Direction.West:
                    {
                        posX--;
                        break;
                    }
                case Direction.East:
                    {
                        posX++;
                        break;
                    }
            }

            Player.GetCurrentRoom().Describe();
        }

        public static void PickupItem(string itemName)
        {
            Room room = Player.GetCurrentRoom();
            Item item = room.GetItem(itemName);

            if (item != null)
            {
                if (Player.InventoryWeight + item.Weight > Player.weightCapacity)
                {
                    TextBuffer.Add("You must first drop some weight before you can pickup that item.");
                    return;
                }
                room.Items.Remove(item);
                Player.inventoryItems.Add(item);
                TextBuffer.Add(item.PickupText);
            }
            else
            {
                TextBuffer.Add("There is no " + itemName + " in this room.");
            }

        }

        public static void DropItem(string itemName)
        {
            Room room = Player.GetCurrentRoom();
            Item item = GetInventoryItem(itemName);

            if (item != null)
            {
                Player.inventoryItems.Remove(item);
                room.Items.Add(item);
                TextBuffer.Add("The " + itemName + " has been dropped into " + room.Title + " room.");
            }
            else
            {
                TextBuffer.Add("There is no " + itemName + " in your Inventory.");
            }
        }

        public static void DisplayInventory()
        {
            var message = "Your inventory contains:";
            var items = "";
            var underline = "";
            underline = underline.PadLeft(message.Length, '-');
            if (inventoryItems.Count > 0)
            {
                foreach (Item item in inventoryItems)
                {
                    items += "\n[" + item.Title + "][" + item.Weight.ToString() + "]";
                }
            }
            else
            {
                items = "\n<no items>";
            }
            items += "\n Total weight: [" + Player.InventoryWeight + "/" + Player.WeightCapacity + "]";
            TextBuffer.Add(message + "\n" + underline + items);
        }

        public static Room GetCurrentRoom()
        {
            return Level.Rooms[posX, posY];
        }

        public static Item GetInventoryItem(string itemName)
        {
            foreach (Item item in inventoryItems)
            {
                if (item.Title.ToLower() == itemName.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
        #endregion
    }

    //public class ColorChangedEventArgs : EventArgs
    //{
    //    public System.ConsoleColor Color { get; set; }
    //}
}
