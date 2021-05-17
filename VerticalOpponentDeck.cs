using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNOGame
{
    public class VerticalOpponentDeck
    {
        private int maxNbOfCardsDisplayed = 14;
        private int staticAnchorX;
        private int _anchorX;
        private List<Card> _deck = new List<Card>();
        private Random rnd = new Random();
        private int _anchorY;

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


        public int StaticAnchorX
        {
            get { return staticAnchorX; }
            set { staticAnchorX = value; }
        }

        public int MaxNbOfCardsDisplayed
        {
            get { return maxNbOfCardsDisplayed; }
            set { maxNbOfCardsDisplayed = value; }
        }

        public VerticalOpponentDeck(int anchorX, int anchorY, GameManager gameManager)
        {
            for (int i = 0; i < 7; i++)
            {
                gameManager.AssignCard(rnd.Next(gameManager.FullGameDeck.Count), this);
            }
            Debug.WriteLine("Assignation réussie.");
            this._anchorY = anchorY;
            this.staticAnchorX = anchorX;
            PrintFrame();
        }

        public void PrintDeck()
        {
            this._anchorX = this.staticAnchorX - ((5 + this._deck.Count*2) / 2);// Attributs
            if (this._deck.Count > maxNbOfCardsDisplayed)
            {
                this._anchorX = this.staticAnchorX - ((5 + maxNbOfCardsDisplayed*2) / 2);
            }
            Console.SetCursorPosition(this._anchorX, this._anchorY);
            Console.Write("╭────");
            for (int i = 1; i < this._deck.Count; i++)
            {
                Console.Write("┬─");
                if (i == this.maxNbOfCardsDisplayed)
                {
                    break;
                }
            }
            Console.Write("╮");
            for (int k = 0; k < 3; k++)
            {
                Console.CursorLeft = this._anchorX;
                Console.CursorTop++;
                Console.Write("│    ");
                for (int i = 1; i < this._deck.Count; i++)
                {
                    Console.Write("│ ");
                    if (i == this.maxNbOfCardsDisplayed)
                    {
                        break;
                    }
                }
                Console.Write("│");
            }
            Console.SetCursorPosition(this._anchorX + 2, this._anchorY + 2);
            Console.Write(DisplayNbOfCards());
            Console.SetCursorPosition(this._anchorX, this._anchorY + 4);
            Console.Write("╰────");
            for (int i = 1; i < this._deck.Count; i++)
            {
                Console.Write("┴─");
                if (i == this.maxNbOfCardsDisplayed)
                {
                    break;
                }
            }
            Console.Write("╯");

            //Console.SetCursorPosition(this.StaticAnchorX, this._anchorY);
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
            Console.SetCursorPosition(this.staticAnchorX - 17, this._anchorY - 1);
            Console.Write("╭──────────────────────────────────╮");
        }
    }
}
