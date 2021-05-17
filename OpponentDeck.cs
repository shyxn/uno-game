using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNOGame
{
    public class OpponentDeck
    {
        private int maxNbOfCardsDisplayed = 14;
        private int staticAnchorY;
        private int _anchorX;
        private List<Card> _deck = new List<Card>();
        private Random rnd = new Random();
        private int _anchorY;
        private string _side;
        
        public string Side
        {
            get { return _side; }
            set { _side = value; }
        }

        public int AnchorY
        {
            get { return _anchorY; }
            set { _anchorY = value; }
        }

        public List<Card> Deck
        {
            get { return _deck; }
            set { _deck = value; }
        }

        public int AnchorX
        {
            get { return _anchorX; }
            set { _anchorX = value; }
        }

        public int StaticAnchorY
        {
            get { return staticAnchorY; }
            set { staticAnchorY = value; }
        }

        public int MaxNbOfCardsDisplayed
        {
            get { return maxNbOfCardsDisplayed; }
            set { maxNbOfCardsDisplayed = value; }
        }

        public OpponentDeck(int anchorX, int anchorY, string side, GameManager gameManager)
        {
            this._side = side;
            for (int i = 0; i < 7; i++)
            {
                gameManager.AssignCard(rnd.Next(gameManager.FullGameDeck.Count), this);
            }
            Debug.WriteLine("Assignation réussie.");
            this._anchorX = anchorX;
            this.staticAnchorY = anchorY;
            PrintFrame();
        }

        public void PrintDeck()
        {
            this._anchorY = this.staticAnchorY - ((2 + this._deck.Count) / 2);// Attributs
            if (this._deck.Count > maxNbOfCardsDisplayed)
            {
                this._anchorY = this.staticAnchorY - ((2 + maxNbOfCardsDisplayed) / 2);
            }
            Console.SetCursorPosition(this._anchorX, this._anchorY);
            Console.Write("╭────────╮");
            for (int i = 1; i < this._deck.Count; i++)
            {
                Console.SetCursorPosition(this._anchorX, this._anchorY + i);
                Console.Write("├────────┤");
                if (i == this.maxNbOfCardsDisplayed)
                {
                    break;
                }
            }
            Console.CursorLeft = this._anchorX;
            Console.CursorTop++;
            Console.WriteLine("│   {0}   │", DisplayNbOfCards());
            Console.CursorLeft = this._anchorX;
            Console.WriteLine("╰────────╯");
            //Console.SetCursorPosition(this._anchorX, this.staticAnchorY);
            //Console.Write("X");
            Debug.Write("Le paquet opposant a bien été imprimé avec " + this._deck.Count + " cartes.");
        }
        private string DisplayNbOfCards()
        {
            if (this._deck.Count > this.maxNbOfCardsDisplayed)
                return this._deck.Count.ToString();
            else
                return "  ";
        }
        private void PrintFrame()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (this._side == "Player 1")
            {
                Console.SetCursorPosition(this._anchorX - 1, this.staticAnchorY - 9);
                Console.Write("╭");
                for (int i = 0; i < 17; i++)
                {
                    Console.CursorLeft = this._anchorX - 1;
                    Console.CursorTop++;
                    Console.Write("│");
                }
                Console.CursorLeft = this._anchorX - 1;
                Console.CursorTop++;
                Console.Write("╰");
            }
            if (this._side == "Player 3")
            {
                Console.SetCursorPosition(this._anchorX - 1, this.staticAnchorY - 9);
                Console.Write("           ╮");
                for (int i = 0; i < 17; i++)
                {
                    Console.CursorLeft = this._anchorX - 1;
                    Console.CursorTop++;
                    Console.Write("           │");
                }
                Console.CursorLeft = this._anchorX - 1;
                Console.CursorTop++;
                Console.Write("           ╯");
            }
        }
    }
}
