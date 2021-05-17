using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNOGame
{
    public class Card
    {
        private ConsoleColor _color;
        private int _value; // 0 à 9, 10 == skip ; 11 == reverse ; 12 == +2 / 13 == wild ; 14 == +4
        private int _scoreValue;        

        public int ScoreValue
        {
            get { return _scoreValue; }
            set { _scoreValue = value; }
        }

        public int CardValue
        {
            get { return _value; }
            set { _value = value; }
        }

        public ConsoleColor CardColor
        {
            get { return _color; }
            set { _color = value; }
        }

        public Card(ConsoleColor consoleColor, int cardValue)
        {
            this._color = consoleColor;
            this._value = cardValue;
            if (this._value < 10)
                this._scoreValue = this._value; // Valeur de 0 à 9
            else if (this._value < 13)
                this._scoreValue = 20; // 20 points
            else
                this._scoreValue = 50; // 50 points
        }
        
        public string GetCardInfo()
        {
            return _color + " " + _value;
        }
        public void EraseCard(int x, int y) // n'a peut-être pas sa place dans cette classe
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("            ");// alors : non
                y++;
            }
        }
        public void PrintCard(int x, int y)
        {
            switch (this._value)
            {
                case 0:
                    Console.ForegroundColor = this._color;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("╭──────────╮");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("│ 0        │");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("│    ____  │");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("│   / __ \\ │");
                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("│  / / / / │");
                    Console.SetCursorPosition(x, y + 5);
                    Console.WriteLine("│ / /_/ /  │");
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine("│ \\____/   │");
                    Console.SetCursorPosition(x, y + 7);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 8);
                    Console.WriteLine("│        0 │");
                    Console.SetCursorPosition(x, y + 9);
                    Console.WriteLine("╰──────────╯");
                    Console.ResetColor();
                    break;
                case 1:
                    Console.ForegroundColor = this._color;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("╭──────────╮");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("│ 1        │");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("│     ___  │");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("│    <  /  │");
                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("│    / /   │");
                    Console.SetCursorPosition(x, y + 5);
                    Console.WriteLine("│   / /    │");
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine("│  /_/     │");
                    Console.SetCursorPosition(x, y + 7);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 8);
                    Console.WriteLine("│        1 │");
                    Console.SetCursorPosition(x, y + 9);
                    Console.WriteLine("╰──────────╯");
                    Console.ResetColor();
                    break;
                case 2:
                    Console.ForegroundColor = this._color;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("╭──────────╮");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("│ 2        │");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("│    ___   │");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("│   │__ \\  │");
                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("│   __/ /  │");
                    Console.SetCursorPosition(x, y + 5);
                    Console.WriteLine("│  / __/   │");
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine("│ /____/   │");
                    Console.SetCursorPosition(x, y + 7);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 8);
                    Console.WriteLine("│        2 │");
                    Console.SetCursorPosition(x, y + 9);
                    Console.WriteLine("╰──────────╯");
                    Console.ResetColor();
                    break;
                case 3:
                    Console.ForegroundColor = this._color;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("╭──────────╮");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("│ 3        │");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("│    _____ │");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("│   │__  / │");
                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("│    /_ <  │");
                    Console.SetCursorPosition(x, y + 5);
                    Console.WriteLine("│  ___/ /  │");
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine("│ /____/   │");
                    Console.SetCursorPosition(x, y + 7);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 8);
                    Console.WriteLine("│        3 │");
                    Console.SetCursorPosition(x, y + 9);
                    Console.WriteLine("╰──────────╯");
                    Console.ResetColor();
                    break;
                case 4:
                    Console.ForegroundColor = this._color;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("╭──────────╮");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("│ 4        │");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("│    __ __ │");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("│   / // / │");
                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("│  / // /_ │");
                    Console.SetCursorPosition(x, y + 5);
                    Console.WriteLine("│ /__  __/ │");
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine("│   /_/    │");
                    Console.SetCursorPosition(x, y + 7);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 8);
                    Console.WriteLine("│        4 │");
                    Console.SetCursorPosition(x, y + 9);
                    Console.WriteLine("╰──────────╯");
                    Console.ResetColor();
                    break;
                   
                case 5:
                    Console.ForegroundColor = this._color;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("╭──────────╮");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("│ 5        │");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("│    _____ │");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("│   / ___/ │");
                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("│  /__  \\  │");
                    Console.SetCursorPosition(x, y + 5);
                    Console.WriteLine("│  ___/ /  │");
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine("│ /____/   │");
                    Console.SetCursorPosition(x, y + 7);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 8);
                    Console.WriteLine("│        5 │");
                    Console.SetCursorPosition(x, y + 9);
                    Console.WriteLine("╰──────────╯");
                    Console.ResetColor();
                    break;
                case 6:
                    Console.ForegroundColor = this._color;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("╭──────────╮");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("│ 6        │");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("│    _____ │");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("│   / ___/ │");
                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("│  / __ \\  │");
                    Console.SetCursorPosition(x, y + 5);
                    Console.WriteLine("│ / /_/ /  │");
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine("│ \\____/   │");
                    Console.SetCursorPosition(x, y + 7);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 8);
                    Console.WriteLine("│        6 │");
                    Console.SetCursorPosition(x, y + 9);
                    Console.WriteLine("╰──────────╯");
                    Console.ResetColor();
                    break;
                case 7:
                    Console.ForegroundColor = this._color;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("╭──────────╮");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("│ 7        │");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("│   _____  │");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("│  /__  /  │");
                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("│    / /   │");
                    Console.SetCursorPosition(x, y + 5);
                    Console.WriteLine("│   / /    │");
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine("│  /_/     │");
                    Console.SetCursorPosition(x, y + 7);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 8);
                    Console.WriteLine("│        7 │");
                    Console.SetCursorPosition(x, y + 9);
                    Console.WriteLine("╰──────────╯");
                    Console.ResetColor();
                    break;
                case 8:
                    Console.ForegroundColor = this._color;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("╭──────────╮");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("│ 8        │");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("│    ____  │");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("│   ( __ ) │");
                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("│  / __  │ │");
                    Console.SetCursorPosition(x, y + 5);
                    Console.WriteLine("│ / /_/ /  │");
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine("│ \\____/   │");
                    Console.SetCursorPosition(x, y + 7);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 8);
                    Console.WriteLine("│        8 │");
                    Console.SetCursorPosition(x, y + 9);
                    Console.WriteLine("╰──────────╯");
                    Console.ResetColor();
                    break;
                case 9:
                    Console.ForegroundColor = this._color;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("╭──────────╮");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("│ 9        │");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("│    ____  │");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("│   / __ \\ │");
                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("│  / /_/ / │");
                    Console.SetCursorPosition(x, y + 5);
                    Console.WriteLine("│  \\__, /  │");
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine("│ /____/   │");
                    Console.SetCursorPosition(x, y + 7);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 8);
                    Console.WriteLine("│        9 │");
                    Console.SetCursorPosition(x, y + 9);
                    Console.WriteLine("╰──────────╯");
                    Console.ResetColor();
                    break;
                // Skip
                case 10:
                    Console.ForegroundColor = this._color;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("╭──────────╮");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("│ Ø        │");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("│ ______   │");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("│/ ___  \\  │");
                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("│\\ \\ / Ʌ \\ │");
                    Console.SetCursorPosition(x, y + 5);
                    Console.WriteLine("│ \\ V /_\\ \\│");
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine("│  \\______/│");
                    Console.SetCursorPosition(x, y + 7);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 8);
                    Console.WriteLine("│        Ø │");
                    Console.SetCursorPosition(x, y + 9);
                    Console.WriteLine("╰──────────╯");
                    Console.ResetColor();
                    break;
                // Reverse
                case 11:
                    Console.ForegroundColor = this._color;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("╭──────────╮");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("│ R        │");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("│  ╭───>►  │");
                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("│  │ >> │  │");
                    Console.SetCursorPosition(x, y + 5);
                    Console.WriteLine("│  │ << │  │");
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine("│  ◄<───╯  │");
                    Console.SetCursorPosition(x, y + 7);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 8);
                    Console.WriteLine("│        R │");
                    Console.SetCursorPosition(x, y + 9);
                    Console.WriteLine("╰──────────╯");
                    Console.ResetColor();
                    break;
                // +2
                case 12:
                    

                    Console.ForegroundColor = this._color;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("╭──────────╮");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("│ +2       │");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("│      ___ │");
                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("│   __/  / │");
                    Console.SetCursorPosition(x, y + 5);
                    Console.WriteLine("│  / /__/  │");
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine("│ /__/     │");
                    Console.SetCursorPosition(x, y + 7);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 8);
                    Console.WriteLine("│       +2 │");
                    Console.SetCursorPosition(x, y + 9);
                    Console.WriteLine("╰──────────╯");
                    Console.ResetColor();
                    break;
                // Wild
                case 13:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("╭──────────╮");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("│ W        │");
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 3);
                    Console.Write("│  ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("┏-  ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("-┓  ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("│");
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("│   ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("-┛");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("┗-   ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("│");
                    Console.SetCursorPosition(x, y + 5);
                    Console.Write("│   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("-┓");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("┏-   ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("│");
                    Console.SetCursorPosition(x, y + 6);
                    Console.Write("│  ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("┗-  ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("-┛  ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("│");
                    Console.SetCursorPosition(x, y + 7);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 8);
                    Console.WriteLine("│        W │");
                    Console.SetCursorPosition(x, y + 9);
                    Console.WriteLine("╰──────────╯");
                    Console.ResetColor();
                    break;
                // +4
                case 14:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("╭──────────╮");
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("│ +4       │");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("│     ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("___");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("  │");
                    Console.SetCursorPosition(x, y + 3);
                    Console.Write("│   ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("_");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("/  /");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("_");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" │");
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("│  ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("/");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("/__/");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" /");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" │");
                    Console.SetCursorPosition(x, y + 5);
                    Console.Write("│ ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("/__/");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("__/");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("  │");
                    Console.SetCursorPosition(x, y + 6);
                    Console.Write("│  ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("/__/");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("    │");
                    Console.SetCursorPosition(x, y + 7);
                    Console.WriteLine("│          │");
                    Console.SetCursorPosition(x, y + 8);
                    Console.WriteLine("│       +4 │");
                    Console.SetCursorPosition(x, y + 9);
                    Console.WriteLine("╰──────────╯");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
