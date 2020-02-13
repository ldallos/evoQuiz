using evoQuiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.ViewModel
{
    public class GameOverViewModel: ViewModelBase
    {
        public Player MyPlayer { get; set; }
        public MainViewModel Parent { get; set; }

        private int myScore;

        public int Score
        {
            get { return myScore; }
            set { myScore = value; OnPropertyChanged("Score"); }
        }

        private bool myGameOverControlVisible;
        public bool GameOverControlVisible
        {
            get { return myGameOverControlVisible; }
            set { myGameOverControlVisible = value; OnPropertyChanged("GameOverControlVisible"); }
        }


        public GameOverViewModel(Player player)
        {
            GameOverControlVisible = false;
            MyPlayer = player;
        }

        public void Open()
        {
            GameOverControlVisible = true;
            Score = MyPlayer.Gold;
        }
    }
}
