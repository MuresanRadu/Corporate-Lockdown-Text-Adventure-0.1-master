using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateLockdown
{
    public struct Direction
    {
        #region Direction Constants
        public const string North = "north";
        public const string South = "south";
        public const string East = "east";
        public const string West = "west";
        #endregion

        #region Check for Validity of Direction
        public static bool IsValidDirection(string direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return true;
                case Direction.South:
                    return true;
                case Direction.East:
                    return true;
                case Direction.West:
                    return true;
               
            }
            return false;
        }
        #endregion Check for Validity of Direction
    }
}
