using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateLockdown
{
    static class TextBuffer
    {
        static string outputBuffer;

        public static void Add(string text)
        {
            outputBuffer += text + "\n";
        }

        public static void Display()
        {
            Console.Clear();
            Console.Write(TextUtils.WordWrap(outputBuffer, Console.WindowWidth));
            Console.WriteLine("What shall I do?");
            Console.Write(">");

            outputBuffer = "";
        }
    }
}
