using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UNOGame
{
    public class DirectionAnimation
    {
       
        private int _indX;
        private int _indY;
        private GameManager _gameManager;
        private char _animChar;

        public char AnimChar
        {
            get { return _animChar; }
            set { _animChar = value; }
        }


        public GameManager GameManager
        {
            get { return _gameManager; }
            set { _gameManager = value; }
        }

        public int IndY
        {
            get { return _indY; }
            set { _indY = value; }
        }

        public int IndX
        {
            get { return _indX; }
            set { _indX = value; }
        }



        public DirectionAnimation(GameManager game)
        {
            this._gameManager = game;
            this._indX = 53;
            this._indY = 10;
        }
        public void Play()
        {
            if (this._gameManager.GameDirection == 0)// Sens inverse des aiguilles d'une montre
            {
                if (IndY == 10 && IndX > 52 && IndX < 79)
                {
                    IndX++;
                    this._animChar = '─';
                }
                else if (IndX == 79 && IndY > 10 && IndY < 21)
                {
                    IndY++;
                    this._animChar = '╵';
                }
                else if (IndY == 21 && IndX > 52 && IndX < 79)
                {
                    IndX--;
                    this._animChar = '─';
                }
                else if (IndX == 52 && IndY > 10 && IndY < 21)
                {
                    IndY--;
                    this._animChar = '╵';
                }
                else if (IndX == 52 && IndY == 10)
                {
                    IndX++;
                    this._animChar = '┌';
                }
                else if (IndX == 79 && IndY == 10)
                {
                    IndY++;
                    this._animChar = '┐';
                }
                else if (IndX == 79 && IndY == 21)
                {
                    IndX--;
                    this._animChar = '┘';
                }
                else if(IndX == 52 && IndY == 21)
                {
                    IndY--;
                    this._animChar = '└';
                }
            }
            else if (this._gameManager.GameDirection == 1)// Sens des aiguilles d'une montre
            {
                if (IndY == 10 && IndX > 52 && IndX < 79)
                {
                    IndX--;
                    this._animChar = '─';
                }
                else if (IndX == 79 && IndY > 10 && IndY < 21)
                {
                    IndY--;
                    this._animChar = '╵';
                }
                else if (IndY == 21 && IndX > 52 && IndX < 79)
                {
                    IndX++;
                    this._animChar = '─';
                }
                else if (IndX == 52 && IndY > 10 && IndY < 21)
                {
                    IndY++;
                    this._animChar = '╵';
                }
                else if (IndX == 52 && IndY == 10)
                {
                    IndY++;
                    this._animChar = '┌';
                }
                else if (IndX == 79 && IndY == 10)
                {
                    IndX--;
                    this._animChar = '┐';
                }
                else if (IndX == 79 && IndY == 21)
                {
                    IndY--;
                    this._animChar = '┘';
                }
                else if (IndX == 52 && IndY == 21)
                {
                    IndX++;
                    this._animChar = '└';
                }
            }
            Console.SetCursorPosition(IndX, IndY);
            Console.Write(this._animChar);
            Thread.Sleep(100);
            Console.CursorLeft--;
            Console.Write(" ");
        }


    }
}
