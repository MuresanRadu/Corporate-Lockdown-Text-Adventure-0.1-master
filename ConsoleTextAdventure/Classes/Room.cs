using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateLockdown
{
    
    

    class Room
    {
        #region Variables
        private List<string> exits;
        private string title;
        private string description;
        private List<Item> items;

        #endregion

        #region Properties
        public string Title { get { return title; } set { title = value; } }
        public string Description { get { return description; } set { description = value; } }
        public List<Item> Items { get { return items; } set { items = value; } }
        public ConsoleColor Color { get; set; } = ConsoleColor.White;
        #endregion

        #region Constructors
        public Room()
        {
            exits = new List<string>();
            items = new List<Item>();
        }
        #endregion

        #region Public Methods

        public void Describe()
        {
            TextBuffer.Add("Coordonates: " + this.GetCoordonates() + "\n" + this.description);
            TextBuffer.Add(this.GetItemList());
            TextBuffer.Add(this.GetExitList());
            Console.ForegroundColor = Color;

        }
        
        public void ShowTitle()
        {
            TextBuffer.Add(this.title);
        }

        public Item GetItem(string itemName)
        {
            foreach (Item item in this.items)
            {
                if (item.Title.ToLower() == itemName.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        public void AddExit(string direction)
        {
            if (this.exits.IndexOf(direction) == -1)
            {
                this.exits.Add(direction);
            }
        }

        public void RemoveExit(string direction)
        {
            if (this.exits.IndexOf(direction) != -1)
            {
                this.exits.Remove(direction);
            }
        }

        public bool CanExit(string direction)
        {
            foreach (var validExit in this.exits)
            {
                if (direction == validExit)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Private Methods

        private string GetItemList()
        {
            var itemString = "";
            var message = "Items in Room:";
            var underline = "";
            underline = underline.PadLeft(message.Length, '-');

            if (this.items.Count > 0)
            {
                foreach (Item item in this.items)
                {
                    itemString += "\n[" + item.Title + "]";
                }
            }
            else
            {
                itemString = "\n<none>";
            }

            return "\n" + message + "\n" + underline + itemString;
        }

        private string GetExitList()
        {
            var exitString = "";
            var message = "Possible Directions:";
            var underline = "";
            underline = underline.PadLeft(message.Length, '-');

            if (this.exits.Count > 0)
            {
                foreach (string exitDirection in this.exits)
                {
                    exitString += "\n[" + exitDirection + "]";
                }
            }
            else
            {
                exitString = "\n<none>";
            }

            return "\n" + message + "\n" + underline + exitString;
        }

        private string GetCoordonates()
        {
            for (int y = 0; y < Level.Rooms.GetLength(1); y++)
            {
                for (int x = 0; x < Level.Rooms.GetLength(0); x++)
                {
                    if (this == Level.Rooms[x, y])
                    {
                        return "[" + x.ToString() + ", " + y.ToString() + "]";
                    }
                }
            }
            return "This room is not within the Rooms grid";
        }
        #endregion
    }

    

}
