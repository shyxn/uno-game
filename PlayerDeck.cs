using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UNOGame
{
    public class PlayerDeck
    {
        private List<Card> _deck = new List<Card>();
        private Random rnd = new Random();

        private int _spacing = 4;
        private List<ConsoleColor> _colors = new List<ConsoleColor>() {
            ConsoleColor.Red,
            ConsoleColor.DarkYellow,
            ConsoleColor.Green,
            ConsoleColor.Blue
        };
        
        private int anchorX = 70;
        private int _selectionIndex;
        private GameManager gameManager;
        private bool _isSelecting;
        private int _printIndexLeft;
        private int _printIndexTop;
        private int _maxNbOfCards = 25; // Must be odd
        private int _initialNbOfCards = 24;
        private int _selectionIndexDisplay;
        private int _margeLeftCards;
        private int _margeRightCards;
        private bool _isCardDrawedFocused;

        public bool IsCardDrawedFocused
        {
            get { return _isCardDrawedFocused; }
            set { _isCardDrawedFocused = value; }
        }


        public int MargeRightCards
        {
            get { return _margeRightCards; }
            set { _margeRightCards = value; }
        }


        public int MargeLeftCards
        {
            get { return _margeLeftCards; }
            set { _margeLeftCards = value; }
        }


        public int SelectionIndexDisplay
        {
            get { return _selectionIndexDisplay; }
            set { _selectionIndexDisplay = value; }
        }

        public int InitialNbOfCards
        {
            get { return _initialNbOfCards; }
            set { _initialNbOfCards = value; }
        }
        
        public int MaxNbOfCards
        {
            get { return _maxNbOfCards; }
            set { _maxNbOfCards = value; }
        }

        public int PrintIndexTop
        {
            get { return _printIndexTop; }
            set { _printIndexTop = value; }
        }

        public int PrintLeftIndex
        {
            get { return _printIndexLeft; }
            set { _printIndexLeft = value; }
        }

        public bool IsSelecting
        {
            get { return _isSelecting; }
            set { _isSelecting = value; }
        }

        public GameManager GameManager
        {
            get { return gameManager; }
            set { gameManager = value; }
        }

        public int SelectionIndex
        {
            get { return _selectionIndex; }
            set { _selectionIndex = value; }
        }

        public int AnchorX
        {
            get { return anchorX; }
            set { anchorX = value; }
        }

        public int Spacing
        {
            get { return _spacing; }
            set { _spacing = value; }
        }

        public List<Card> Deck
        {
            get { return _deck; }
            set { _deck = value; }
        }
        public PlayerDeck(GameManager gameManager)
        {
            this.gameManager = gameManager;
            Debug.WriteLine("Assignation des cartes pour le joueur...");
            for (int i = 0; i < this._initialNbOfCards; i++)
            {
                gameManager.AssignCard(rnd.Next(gameManager.FullGameDeck.Count), this);
            }
            Debug.WriteLine("Assignation réussie.");
            SortCards();
            PrintFrame();
            this._selectionIndex = this._deck.Count / 2;
            this._selectionIndexDisplay = this._selectionIndex; // les deux index sont égaux pour l'instant
            this._printIndexTop = 25;

            this._isSelecting = false;
            this._isCardDrawedFocused = true;
        }

        public void PlayInterface()
        {
            if (this._deck.Count < this._maxNbOfCards)
            {
                ClearFrame();
                //PrintCards();
                // Ancrage
                this._printIndexLeft = anchorX - ((12 + (this._deck.Count) * 4) / 2);

                // Print les cartes jusqu'à l'index de gauche à droite
                for (int i = 0; i < this._selectionIndex; i++)
                {
                    this._deck[i].PrintCard(this._printIndexLeft + this._spacing * i, this._printIndexTop);
                }
                // Print les cartes jusqu'à l'index de droite à gauche
                for (int i = this._deck.Count - 1; i > this._selectionIndex ; i--)
                {
                    this._deck[i].PrintCard(this._printIndexLeft + this._spacing * i, this._printIndexTop);
                }

                // Print la carte de l'index, en haut si sélection true grâce à la méthode privée heightOfCard()
                this._deck[this._selectionIndex].PrintCard(this._printIndexLeft + this._spacing * this._selectionIndex, HeightOfCard());
            }
            else
            {
                ClearFrame();
                this._selectionIndexDisplay = GetDisplayIndexFromSelectIndex(this._selectionIndex);
                UpdateDisplayMargeCardsNumbers();
                
                // Ancrage
                this._printIndexLeft = anchorX - ((12 + (this._maxNbOfCards) * 4) / 2);
                int waw;
                // Print les cartes jusqu'à l'index displayed de gauche à droite
                for (int i = 0; i < this._selectionIndexDisplay; i++)
                {
                    waw = i + this._margeLeftCards;// remplacer par marge left peut-être
                    this._deck[waw].PrintCard(this._printIndexLeft + this._spacing * i, this._printIndexTop);
                }

                // Print les cartes jusqu'à l'index de droite à gauche
                for (int i = this._maxNbOfCards - 1; i > this._selectionIndexDisplay; i--)
                {
                    waw = i + this._margeLeftCards; // remplacer par marge left peut-être
                    if (waw == this._deck.Count)
                    {
                        Debug.WriteLine("WESH");
                        waw--;
                    }
                    this._deck[waw].PrintCard(this._printIndexLeft + this._spacing * i, this._printIndexTop);
                }

                // Print la carte de l'index, en haut si sélection true grâce à la méthode privée heightOfCard()
                this._deck[this._selectionIndex].PrintCard(this._printIndexLeft + this._spacing * this._selectionIndexDisplay, HeightOfCard());

            }
        }
        public void GetInput()
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
            {
                if (this._deck.Count <= this._maxNbOfCards) // Déplacement normal
                {
                    NormalSelecting(key);
                    Debug.WriteLine("Déplacement normal");
                }
                else if (this._selectionIndex <= ((this._maxNbOfCards) / 2 - 1)) // Se trouve dans la zone 1 -> déplacement normal
                {
                    NormalSelecting(key);
                    Debug.WriteLine("Déplacement normal [Zone 1]");
                }
                else if (this._selectionIndex >= (this._deck.Count - (this._maxNbOfCards) / 2)) // Se trouve dans la zone 3 -> déplacement normal
                {
                    NormalSelecting(key);
                    Debug.WriteLine("Déplacement normal [Zone 3]");
                }
                else if (this._selectionIndex == this._maxNbOfCards / 2)
                {
                    if (key == ConsoleKey.LeftArrow)
                    {
                        NormalSelecting(key);
                        Debug.WriteLine("Déplacement normal [Zone 1]");
                    }
                    else if (key == ConsoleKey.RightArrow)
                    {
                        ExtendedSelection(key);
                        Debug.WriteLine("Déplacement extended [vers la droite]");
                    }
                }
                else if (this._selectionIndex == (this._deck.Count - this._maxNbOfCards / 2 - 1))
                {
                    if (key == ConsoleKey.LeftArrow)
                    {
                        ExtendedSelection(key);
                        Debug.WriteLine("Déplacement extended [vers la gauche]");
                    }
                    else if (key == ConsoleKey.RightArrow)
                    {
                        NormalSelecting(key);
                        Debug.WriteLine("Déplacement normal [Zone 3]");
                    }
                }
                else // DECK EXTENDED
                {
                    ExtendedSelection(key);
                    Debug.WriteLine("Déplacement extended [else]");
                }
            }

            switch (key)
            {
                case ConsoleKey.Enter:
                    if (this._isSelecting && gameManager.IsCardPlayable(this._deck[this._selectionIndex]))
                    {
                        this._isSelecting = false;
                        Card playedCard = this._deck[this._selectionIndex];
                        gameManager.DiscardPile.Add(playedCard);
                        this._deck.Remove(playedCard);
                        gameManager.PrintDiscardPile();

                        gameManager.PlayEffect(playedCard);

                        //Actualiser l'index si le joueur a sélectionné la dernière carte de son deck ; car le deck a changé de taille (baissé d'une carte)
                        //if (this._selectionIndex == this._deck.Count)
                        //{
                        //    this._selectionIndex--;
                        //}   
                        // Si en zone 3
                        //if (this._selectionIndex >= (this._deck.Count - (this._maxNbOfCards) / 2))
                        //{
                        //    this._selectionIndex--;
                        //}
                        //if (this._deck.Count < this._maxNbOfCards)
                        //{
                        //    this._selectionIndexDisplay = this._selectionIndex;
                        //}
                        if (this._selectionIndex != 0)
                        {
                            this._selectionIndex--;
                            this._selectionIndexDisplay = GetDisplayIndexFromSelectIndex(this._selectionIndex);
                        }
                        //}
                        Debug.WriteLine("Le joueur a sélectionné sa carte [ENTER].");
                        PlayInterface();
                    }
                    break;

                case ConsoleKey.U:
                    SwitchSelection();
                    Debug.WriteLine("isSelecting = true");
                    break;
                case ConsoleKey.C:
                    if (this._isSelecting)
                    {
                        DrawCard();
                    }
                    PlayInterface();
                    break;
            }
            Console.SetCursorPosition(2, 0);
            Console.WriteLine("this._selectionIndex : " + this._selectionIndex + "   ");
            Console.SetCursorPosition(2, 1);
            Console.WriteLine("this._selectionIndexDisplay : " + this._selectionIndexDisplay + "    ");
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("this._deck.Count : " + this._deck.Count + "    ");
        }
        private void NormalSelecting(ConsoleKey key)
        {
            // Efface l'ancienne carte qui était montrée sélectionnée
            if (this._isSelecting && key != ConsoleKey.C && key != ConsoleKey.Enter)
            {
                this._deck[this._selectionIndex].EraseCard(this._printIndexLeft + this._spacing * (this._selectionIndexDisplay), this._printIndexTop - 1);
            }
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    this._selectionIndex--;
                    this._selectionIndexDisplay--;

                    if (this._selectionIndex > -1)
                    {
                        // Si la sélection est active... (gérer la carte un cran plus haut)
                        if (this._isSelecting)
                        {
                            // Efface la prochaine carte basse (bug de l'extrémité gauche)
                            this._deck[this._selectionIndex].EraseCard(this._printIndexLeft + this._spacing * this._selectionIndexDisplay, this._printIndexTop);

                            // On réaffiche l'ancienne carte mais un cran plus bas
                            this._deck[this._selectionIndex + 1].PrintCard(this._printIndexLeft + this._spacing * (this._selectionIndexDisplay + 1), this._printIndexTop);
                            if (this._selectionIndex != 0)
                            {
                                // Affiche en bas la carte à sa gauche pour éviter les trous
                                this._deck[this._selectionIndex - 1].PrintCard(this._printIndexLeft + this._spacing * (this._selectionIndexDisplay - 1), this._printIndexTop);
                            }
                        }
                    }
                    else // Ne dépasse pas le maximum
                    {
                        this._selectionIndex = 0;
                        this._selectionIndexDisplay = 0;
                    }

                    // Print la carte de l'index, en haut si sélection true grâce à la méthode privée heightOfCard()
                    this._deck[this._selectionIndex].PrintCard(this._printIndexLeft + this._spacing * this._selectionIndexDisplay, HeightOfCard());

                    break;

                case ConsoleKey.RightArrow:
                    this._selectionIndex++;
                    this._selectionIndexDisplay++;
                    if (this._selectionIndex < this._deck.Count) // PEUT-ÊTRE ELSE IF
                    {
                        // Si la sélection est active... (gérer la carte un cran plus haut)
                        if (this._isSelecting)
                        {
                            // Efface la prochaine carte basse (bug de l'extrémité droite)
                            this._deck[this._selectionIndex].EraseCard(this._printIndexLeft + this._spacing * this._selectionIndexDisplay, this._printIndexTop);

                            // On réaffiche l'ancienne carte mais un cran plus bas
                            this._deck[this._selectionIndex - 1].PrintCard(this._printIndexLeft + this._spacing * (this._selectionIndexDisplay - 1), this._printIndexTop);

                            if (this._selectionIndex != this._deck.Count - 1)
                            {
                                // Affiche en bas la carte à sa gauche pour éviter les trous
                                this._deck[this._selectionIndex + 1].PrintCard(this._printIndexLeft + this._spacing * (this._selectionIndexDisplay + 1), this._printIndexTop);
                            }
                        }
                    }
                    else // Ne dépasse pas le maximum
                    {
                        this._selectionIndex = this._deck.Count - 1;
                        this._selectionIndexDisplay--;
                    }

                    // Print la carte de l'index, en haut si sélection true grâce à la méthode privée heightOfCard()
                    this._deck[this._selectionIndex].PrintCard(this._printIndexLeft + this._spacing * this._selectionIndexDisplay, HeightOfCard());

                    break;
            }
            
        }
        private void ExtendedSelection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    this._selectionIndex--;
                    break;
                case ConsoleKey.RightArrow:
                    this._selectionIndex++;
                    break;
            }
            this._selectionIndexDisplay = GetDisplayIndexFromSelectIndex(this._selectionIndex);

            ClearFrame();
            UpdateDisplayMargeCardsNumbers();
            // INSPIRÉ DE PLAYINTERFACE
            // Ancrage
            this._printIndexLeft = anchorX - ((12 + (this._maxNbOfCards) * 4) / 2);
            int waw;
            // Print les cartes jusqu'à l'index displayed de gauche à droite
            for (int i = 0; i < this._selectionIndexDisplay; i++)
            {
                waw = i + ((this._selectionIndex - this._maxNbOfCards / 2));
                this._deck[waw].PrintCard(this._printIndexLeft + this._spacing * i, this._printIndexTop);
            }

            // Print les cartes jusqu'à l'index de droite à gauche
            for (int i = this._maxNbOfCards - 1; i > this._selectionIndexDisplay; i--)
            {
                waw = i + ((this._selectionIndex - this._maxNbOfCards / 2));
                this._deck[waw].PrintCard(this._printIndexLeft + this._spacing * i, this._printIndexTop);
            }

            // Print la carte de l'index, en haut si sélection true grâce à la méthode privée heightOfCard()
            this._deck[this._selectionIndex].PrintCard(this._printIndexLeft + this._spacing * this._selectionIndexDisplay, HeightOfCard());

        }
        private int HeightOfCard()
        {
            if (IsSelecting)
            {
                return this._printIndexTop - 1;
            }
            else
            {
                return this._printIndexTop;
            }
        }
        private int GetDisplayIndexFromSelectIndex(int selectionIndex)
        {
            // Si zone 1 ou deck normal (pas extended)
            if (this._deck.Count < this._maxNbOfCards || selectionIndex < this._maxNbOfCards / 2)
            {
                return selectionIndex;
            }
            // Si zone 3
            else if (selectionIndex > this._deck.Count - this._maxNbOfCards / 2)
            {
                return this._maxNbOfCards - (this._deck.Count - selectionIndex);
            }
            // Si borne 1 ou borne 2 ou zone 2
            else 
            {
                Debug.WriteLine("A essayé de déterminer l'index à la borne 1 ou 2");
                return this._maxNbOfCards / 2;

            }
        }
        private void UpdateDisplayMargeCardsNumbers()
        {
            void Clear(int x)
            {
                Console.SetCursorPosition(x, 25);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("       ");
                    Console.CursorLeft = x;
                }
            }

            // Clear here
            // ...

            if (this._deck.Count >= this._maxNbOfCards)
            {
                this._margeLeftCards = this._selectionIndex - this._selectionIndexDisplay;
                this._margeRightCards = (this._deck.Count - this._maxNbOfCards) - this._margeLeftCards;
                //if (this._margeRightCards == -1)
                //{
                //    this._margeRightCards = 0;
                //}
                // Pile de cartes de gauche
                if (this._margeLeftCards > 0)
                {
                    Console.SetCursorPosition(7, 25);

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(7, 25);
                    Console.Write("╭─╭────");
                    Console.SetCursorPosition(7, 26);
                    for (int i = 0; i < 8; i++)
                    {
                        Console.Write("│ │    ");
                        Console.CursorTop++;
                        Console.CursorLeft = 7;
                    }
                    Console.WriteLine("╰─╰────");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(12, 29);
                    Console.Write("+");
                    // décalage d'un à gauche pour raisons esthétiques
                    if (this._margeRightCards >= 10)
                        Console.SetCursorPosition(11, 30);
                    else
                        Console.SetCursorPosition(12, 30);

                    Console.Write(this._margeLeftCards);
                }
                else
                {
                    Clear(7);
                }



                // Pile de cartes de droite
                if (this._margeRightCards > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(122, 25);
                    Console.Write("────╮─╮");
                    Console.SetCursorPosition(122, 26);
                    for (int i = 0; i < 8; i++)
                    {
                        Console.Write("    │ │");
                        Console.CursorTop++;
                        Console.CursorLeft = 122;
                    }
                    Console.WriteLine("────╯─╯");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(123, 29);
                    Console.Write("+");
                    Console.SetCursorPosition(123, 30);
                    Console.Write(this._margeRightCards);
                }
                else
                {
                    Clear(122);
                }

                Console.ResetColor();
            }
            else
            {
                Debug.WriteLine("ATTENTION : UpdateDisplayMargeCardsNumbers n'a pas marché : le deck est inférieur à la limite");
            }
            
           
        }
        /// <summary>
        /// Imprime tout le deck à la fois sur l'espace joueur
        /// </summary>
        public void PrintCards()
        {
            this._printIndexLeft = anchorX - ((12 + (this._deck.Count) * 4) / 2);// OK
            // Imprime les cartes après la marge de gauche, jusqu'à avant la marge de droite (de base 24 cartes, mais ce code permet de garder libre la variable _maxNbOfCards)
            for (int i = 0; i < this._deck.Count; i++)
            {
                Thread.Sleep(50);
                this._deck[i].PrintCard(this._printIndexLeft + this._spacing * i, this._printIndexTop);
            }
            
        }

        /// <summary>
        /// Affiche un cadre gris
        /// </summary>
        private void PrintFrame()
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Console.SetCursorPosition(13, 24);
            //Console.Write("┌────────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.CursorLeft = 13;
            //    Console.CursorTop++;
            //    Console.Write("│                                                                                                            │");
            //}
            Console.SetCursorPosition(13, 35);
            Console.Write("╰────────────────────────────────────────────────────────────────────────────────────────────────────────────╯");
        }
        private void ClearFrame()
        {
            Console.SetCursorPosition(13, 24);
            for (int i = 0; i < 11; i++)
            {
                Console.Write("                                                                                                             ");
                Console.CursorLeft = 13;
                Console.CursorTop++;
            }
        }
        private void SwitchSelection()
        {
            this._isSelecting = true;
            // Permet de gérer l'affichage proprement en dessous de la carte (indice de sélection) qui se lève,

            this._deck[this._selectionIndex].EraseCard(this._printIndexLeft + this._spacing * (this._selectionIndexDisplay), this._printIndexTop);
            // Réimprimer celles de gauche et de droite (qui restent dans le cran en bas)
            if (this._selectionIndex != 0)
                this._deck[this._selectionIndex - 1].PrintCard(this._printIndexLeft + this._spacing * (this._selectionIndexDisplay - 1), this._printIndexTop);
            if (this._selectionIndex != this._deck.Count - 1)
                this._deck[this._selectionIndex + 1].PrintCard(this._printIndexLeft + this._spacing * (this._selectionIndexDisplay + 1), this._printIndexTop);

            // Réimprimer la carte sélectionnée un cran plus haut
            this._deck[this._selectionIndex].PrintCard(this._printIndexLeft + this._spacing * (this._selectionIndexDisplay), this._printIndexTop - 1);
        }
        private void DrawCard()
        {
            Card newCardIndex = gameManager.FullGameDeck[rnd.Next(gameManager.FullGameDeck.Count)];
            this._deck.Add(newCardIndex);
            gameManager.FullGameDeck.Remove(newCardIndex);
            newCardIndex.PrintCard(54, 11);
            Thread.Sleep(500);
            gameManager.PrintRemainingCardsPile();
            SortCards();
            if (this._isCardDrawedFocused)
            {
                this._selectionIndex = this._deck.IndexOf(newCardIndex);
                this._selectionIndexDisplay = GetDisplayIndexFromSelectIndex(this._selectionIndex);
            }
        } 
        public void SortCards()
        {
            Debug.WriteLine("Triage des cartes du deck du joueur...");
            // Création de la liste intermédiaire
            List<Card> interList = new List<Card>();
            // Pour chaque couleur (dans l'ordre)
            foreach (ConsoleColor i_color in this._colors)
            {
                Debug.WriteLine("Commence à trier les " + i_color.ToString() + " ...");
                // Récolter les rouges dans une liste intermédiaire,
                foreach (Card card in this._deck)
                {
                    if (card.CardColor == i_color && card.CardValue != 13 && card.CardValue != 14)
                    {
                        interList.Add(card);
                    }
                }
                //les trier dans la liste interList
                for (int i = 0; i < interList.Count - 1; i++)
                {
                    if (interList[i].CardValue > interList[i + 1].CardValue)
                    {
                        // Ramener à la fin
                        interList.Add(interList[i]);
                        interList.Remove(interList[i]);
                        i -= 2;
                        if (i == -2)
                            i = 0;
                    }
                }
                //puis les ramener sur le devant du deck du joueur
                foreach (Card card in interList)
                {
                    this._deck.Add(card);
                    this._deck.Remove(card);
                }
                interList.Clear();
            }

            // Ramener les wild et les +4 sur le devant du deck
            Debug.WriteLine("Triage des wild...");
            // Anti-bug
            int count = 0;
            for (int i = 0; i < this._deck.Count - 2; i++)
            {
                if (this._deck[i].CardValue == 13)
                {
                    this._deck.Add(this._deck[i]);
                    this._deck.Remove(this._deck[i]);
                    i -= 1;
                    count++;
                    if (count == 4)
                    {
                        break;
                    }
                }
            }
            Debug.WriteLine("Triage des +4...");
            count = 0;
            for (int i = 0; i < this._deck.Count - 2; i++)
            {
                if (this._deck[i].CardValue == 14)
                {
                    this._deck.Add(this._deck[i]);
                    this._deck.Remove(this._deck[i]);
                    i -= 1;
                    count++;
                    if (count == 4)
                    {
                        break;
                    }
                    Debug.WriteLine("Carte +4 triée");
                }
            }
            Debug.WriteLine("Triage des cartes du joueur terminé.");

            // Ramener les +4 sur le devant du deck
            /// TRI : foreach carte dans la liste intermédiaire,
            ///         while true, , en commençant par le début, if la valeur de l'actuelle est supérieure à celle de la prochaine, alors on la ramène à la fin, puis on reprend à [l'index - 1 (s'il n'est pas égal à 0)]


        }
    }
}
