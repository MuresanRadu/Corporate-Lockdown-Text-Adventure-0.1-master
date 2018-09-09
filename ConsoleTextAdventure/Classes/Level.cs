using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateLockdown
{
    static class Level
    {
        #region Variables
        //2D array of type Room
        private static Room[,] rooms;
        #endregion

        #region Properties
        public static Room[,] Rooms { get { return rooms; } }
        #endregion

        #region Methods

        public static void Initialize()
        {
            BuildLevel();
        }

        private static void BuildLevel()
        {
            #region Test Level Builder
            rooms = new Room[2, 2];
            Room room;
            Item item;

            /////////////////////////////////////////////////////
            //Create a RED ROOM
            room = new Room();

            //Assign this room to location
            rooms[0, 0] = room;

            //Set Room properties
            room.Title = "Red Room";
            room.Description = "You have entered the Red Room. There is a locked door to the [South].";
            room.AddExit(Direction.East);
            room.Color = ConsoleColor.Red;
            /////////////////////////////////////////////////////
            //Create a new item
            item = new Item();

            //Set Item
            item.Title = "Blue Ball";
            item.PickupText = "You just picked up the Blue Ball!";
            item.ItemColor = ConsoleColor.Blue;
            //Add Item to Room
            room.Items.Add(item);

            /////////////////////////////////////////////////////
            //Create a BLUE ROOM
            room = new Room();

            //Assign this room to location
            rooms[1, 0] = room;

            //Set Room properties
            room.Title = "Blue Room";
            room.Description = "You have entered the Blue Room.";
            room.AddExit(Direction.West);
            room.AddExit(Direction.South);
            room.Color = ConsoleColor.Blue;
            /////////////////////////////////////////////////////
            //Create a new item
            item = new Item();

            //Set Item
            item.Title = "Anvil";
            item.PickupText = "You struggle to pickup the Anvil";
            item.Weight = 6;

            //Add Item to Room
            room.Items.Add(item);

            /////////////////////////////////////////////////////
            //Create a new item
            item = new Item();

            //Set Item
            item.Title = "Key";
            item.PickupText = "You just picked up the Key!";

            //Add Item to Room
            room.Items.Add(item);

            /////////////////////////////////////////////////////
            //Create a new item
            item = new Item();

            //Set Item
            item.Title = "Green Ball";
            item.PickupText = "You just picked up the Green Ball!";

            //Add Item to Room
            room.Items.Add(item);

            /////////////////////////////////////////////////////
            //Create a YELLOW ROOM
            room = new Room();

            //Assign this room to location
            rooms[1, 1] = room;

            //Set Room properties
            room.Title = "Yellow Room";
            room.Description = "You have entered the Yellow Room.";
            room.AddExit(Direction.West);
            room.AddExit(Direction.North);

            /////////////////////////////////////////////////////
            //Create a new item
            item = new Item();

            //Set Item
            item.Title = "Red Ball";
            item.PickupText = "You just picked up the Red Ball!";

            //Add Item to Room
            room.Items.Add(item);

            /////////////////////////////////////////////////////
            //Create a GREEN ROOM
            room = new Room();

            //Assign this room to location
            rooms[0, 1] = room;

            //Set Room properties
            room.Title = "Green Room";
            room.Description = "You have entered the Green Room. There is a locked door to the [North].";
            room.AddExit(Direction.East);

            /////////////////////////////////////////////////////
            //Create a new item
            item = new Item();

            //Set Item
            item.Title = "Yellow Ball";
            item.PickupText = "You just picked up the Yellow Ball!";

            //Add Item to Room
            room.Items.Add(item);
            #endregion Test Level Builder

            #region Player Position in Room
            /////////////////////////////////////////////////////
            //Place the Player in the starting room
            Player.PosX = 0;
            Player.PosY = 0;
            #endregion Player Position in Room
        }
        #endregion
    }
}
