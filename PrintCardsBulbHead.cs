using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNOGame
{
    public class PrintCardsBulbHead
    {
        public PrintCardsBulbHead()
        {

        }
        public void Card0(int x, int y, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("╭─────────╮");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("│ 0       │");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("│   ___   │");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("│  / _ \\  │");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("│ ( (_) ) │");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("│  \\___/  │");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("│         │");
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("│       0 │");
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine("╰─────────╯");
            Console.ResetColor();
        }
        public void Card1(int x, int y, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("╭──────────╮");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("│ 1        │");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("│      _/  │");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("│   _/  _/ │");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("│  _/  _/  │");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("│ _/  _/   │");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("│  _/      │");
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("│          │");
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine("│        1 │");
            Console.SetCursorPosition(x, y + 9);
            Console.WriteLine("╰──────────╯");
            Console.ResetColor();
        }

    }
}
