using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace UNOGame
{
    class Program
    {
        // Maximize Console Window
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        static void Main(string[] args)
        {
            // Configuration de la taille de la console
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            Console.CursorVisible = false;
            Console.Title = "UNOnfonctionnel";
            Console.OutputEncoding = Encoding.Unicode;
            GameManager gameManager = new GameManager();
            Random rnd = new Random();
            PlayerDeck playerDeck = new PlayerDeck(gameManager);
            OpponentDeck opponentDeckP1 = new OpponentDeck(20, 14, "Player 1", gameManager);
            OpponentDeck opponentDeckP2 = new OpponentDeck(107, 14, "Player 3", gameManager);
            VerticalOpponentDeck verticalOpponentDeck = new VerticalOpponentDeck(67, 2, gameManager);
            ConsoleColor[] AllColorsTable = new ConsoleColor[]
            {
                ConsoleColor.Red,
                ConsoleColor.Green,
                ConsoleColor.DarkYellow,
                ConsoleColor.Blue
            };
            //Console.ForegroundColor = AllColorsTable[rnd.Next(4)];
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleHelper.SetCurrentFont("Consolas", 22);
            // Ancre en haut à gauche
            int leftIndex = 0; // Paramètre
            int topIndex = 0; // Paramètre

            //gameManager.PrintAllCards();
            opponentDeckP1.PrintDeck();
            opponentDeckP2.PrintDeck();
            verticalOpponentDeck.PrintDeck();
            Console.SetCursorPosition(146, 34);
            Console.Write("W");
            DirectionAnimation animation = new DirectionAnimation(gameManager);
            playerDeck.PlayInterface();
            while (true)
            {
                while (!Console.KeyAvailable)
                {
                    animation.Play();
                }
                playerDeck.GetInput();

            }



            Console.ResetColor();
            //Console.WriteLine("Le deck du joueur est composé de " + playerDeck.Deck.Count + " cartes.");
            //Console.WriteLine("Le deck du jeu est composé de " + gameManager.FullGameDeck.Count + " cartes.");

            Console.Read();
        }
        static void TestPlayerDeck()
        {
            
        }
    }
}
