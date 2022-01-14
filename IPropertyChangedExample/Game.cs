using System;
using System.Collections.Generic;
using System.ComponentModel;//for INotifyPropertyChanged
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Как вариант использование привязки можно показать реализацию игры
namespace IPropertyChangedExample
{
    #region No use
    enum GameStatus
    {
        Win, Lose, Plaing, Pause
    }


    #endregion


    class Game : INotifyPropertyChanged
    {
        #region No use
        public GameStatus GameStatus
        {
            get
            {
                return gameStatus;
            }
            set
            {
                if (gameStatus != value)
                {
                    gameStatus = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GameStatus"));
                }
            }
        }
        GameStatus gameStatus;
        #endregion

        int finish;

        public Game()
        {
            Finish = 100;
        }

        public int Finish
        {
            get
            {
                return finish;
            }
            set
            {
                finish = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Finish"));
            }
        }

      
        public event PropertyChangedEventHandler PropertyChanged;


    }
}
