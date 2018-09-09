using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace CorporateLockdown
{
    class Item
    {
        #region Variables
        private string title;
        private string pickupText;
        private int weight = 1;
        #endregion

        #region Properties
        public string Title { get {return title; } set {title = value; } }
        public string PickupText { get { return pickupText; } set { pickupText = value; } }
        public int Weight { get { return weight; } set { weight = value; } }
        public ConsoleColor ItemColor { get; set; }
        #endregion

    }
    
}
