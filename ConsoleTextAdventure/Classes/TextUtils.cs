using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateLockdown
{
    static class TextUtils
    {
        public static string ExtractCommand(string line)
        {
            var index = line.IndexOf(' ');
            if (index == -1)
            {
                return line;
            }
            else
            {
                return line.Substring(0, index);
            }
        }

        public static string ExtractArgument(string line)
        {
            var index = line.IndexOf(' ');
            if (index == -1)
            {
                return "";
            }
            else
            {
                return line.Substring(index + 1, line.Length - index - 1);
            }
        }

        public static string WordWrap(string text, int bufferWidth)
        {
            var result = "";
            string[] lines = text.Split('\n');
            foreach (string line in lines)
            {
                var lineLength = 0;
                string[] words = line.Split(' ');
                foreach (string word in words)
                {
                    if (word.Length + lineLength >= bufferWidth - 1)
                    {
                        result += "\n";
                        lineLength = 0;
                    }
                    result += word + " ";
                    lineLength += word.Length + 1;

                }
                result += "\n";
            }
            return result;
        }
    }
}
