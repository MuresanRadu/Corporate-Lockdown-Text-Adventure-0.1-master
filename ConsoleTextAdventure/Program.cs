using System;
using System.Runtime.InteropServices;

namespace CorporateLockdown
{
    class Program
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;
        public static bool quit;

        static void Main()
        {

            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            GameManager.ShowTitleScreen();
            Level.Initialize();
            GameManager.StartGame();

            while (!quit)
            {
                CommandProcessor.ProcessCommand(Console.ReadLine());
            }
        }
    }
}
