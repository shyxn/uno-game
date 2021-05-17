using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNOGame
{
    public class GameManager
    {
        private List<Card> _fullGameDeck = new List<Card>();
        private List<ConsoleColor> _colors = new List<ConsoleColor>() {
            ConsoleColor.Blue,
            ConsoleColor.Red,
            ConsoleColor.Green,
            ConsoleColor.DarkYellow
        };
        private List<Card> _discardPile = new List<Card>();
        private Random rnd = new Random();
        private byte _gameDirection; // 0 : Sens inverse des aiguilles d'une montre, 1 : Sens des aiguilles d'une montre

        public byte GameDirection
        {
            get { return _gameDirection; }
            set { _gameDirection = value; }
        }

        public List<Card> DiscardPile
        {
            get { return _discardPile; }
            set { _discardPile = value; }
        }

        public List<Card> FullGameDeck
        {
            get { return _fullGameDeck; }
            set { _fullGameDeck = value; }
        }

        public GameManager()
        {
            Debug.WriteLine("Création des cartes du jeu dans GameManager...");
            foreach (ConsoleColor i_color in this._colors)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int i_value = 1; i_value <= 12; i_value++)
                    {
                        this._fullGameDeck.Add(new Card(i_color, i_value));
                    }
                }
                // Seulement quatre cartes de valeur 0
                this._fullGameDeck.Add(new Card(i_color, 0));
                // Seulement quatre cartes de valeur 14 (color changer)
                this._fullGameDeck.Add(new Card(i_color, 13));
                // Seulement quatre cartes de valeur 15 (plus4)
                this._fullGameDeck.Add(new Card(i_color, 14));
            }
            Debug.WriteLine("Création des cartes réussie.");

            PrintRemainingCardsPile();
            AssignFirstCard();
            PrintDiscardPile();
            this._gameDirection = 1;
        }
        /// <summary>
        /// Retire une carte du deck du jeu, pour l'attribuer au deck du joueur
        /// </summary>
        /// <param name="index"></param>
        /// <param name="playerDeck"></param>
        public void AssignCard(int index, PlayerDeck playerDeck)
        {
            playerDeck.Deck.Add(this._fullGameDeck[index]);
            this._fullGameDeck.RemoveAt(index);
        }
        public void AssignCard(int index, OpponentDeck opponentDeck)
        {
            opponentDeck.Deck.Add(this._fullGameDeck[index]);
            this._fullGameDeck.RemoveAt(index);
        }
        public void AssignCard(int index, VerticalOpponentDeck opponentDeck)
        {
            opponentDeck.Deck.Add(this._fullGameDeck[index]);
            this._fullGameDeck.RemoveAt(index);
        }
        public void PrintAllCards()
        {
            Debug.WriteLine("Impression de toutes les cartes du deck général...");
            int leftIndex = 0;
            int topIndex = 0;
            foreach (Card card in this.FullGameDeck)
            {
                card.PrintCard(leftIndex, topIndex);
                leftIndex += 12;
                if (leftIndex > 50)
                {
                    leftIndex = 0;
                    topIndex += 10;
                }
            }
            Debug.WriteLine("Impression de toutes les cartes du deck général réussie.");
        }
        public void PrintRemainingCardsPile()
        {
            Console.SetCursorPosition(54, 11);
            Console.Write("╭──────────╮");
            for (int i = 0; i < 8; i++)
            {
                Console.CursorLeft = 54;
                Console.CursorTop++;
                Console.Write("│          │");
            }
            Console.CursorLeft = 54;
            Console.CursorTop++;
            Console.Write("╰──────────╯");


        }
        public void PrintDiscardPile()
        {
            this._discardPile[this._discardPile.Count - 1].PrintCard(66, 11);
        }
        public void AssignFirstCard()
        {
            do // tant que la première carte (la dernière ajoutée dans discardPile) n'est pas un chiffre
            {
                this._discardPile.Add(this._fullGameDeck[rnd.Next(this._fullGameDeck.Count)]);
            } while (this._discardPile[this._discardPile.Count - 1].CardValue > 9);
        }
        public bool IsCardPlayable(Card cardPlayed)
        {
            Card cardOnPile = this._discardPile[this._discardPile.Count - 1];

            // Si la carte jouée est un changement de couleur ou un +4
            if (cardPlayed.CardValue >= 13)
            {
                return true;
            }
            else if (cardPlayed.CardValue < 13)
            {
                if (cardPlayed.CardValue == cardOnPile.CardValue)
                {
                    return true;
                }
                if (cardPlayed.CardColor == cardOnPile.CardColor)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
            return false;
        }
        public void PlayEffect(Card card)
        {
            switch (card.CardValue)
            {
                case 10:// Skip
                    break;
                case 11:// Reverse
                    if (this._gameDirection == 0)
                    {
                        this._gameDirection = 1;
                    }
                    else
                    {
                        this._gameDirection = 0;
                    }
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
            }
        }
    }
}
