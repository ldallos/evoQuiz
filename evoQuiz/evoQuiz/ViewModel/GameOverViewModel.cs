using evoQuiz.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public ICommand GoBackCommand { get; set; }

        public GameOverViewModel(Player player)
        {
            GoBackCommand = new RelayCommand(GoBack);
            GameOverControlVisible = false;
            MyPlayer = player;
        }

        public void Open()
        {
            GameOverControlVisible = true;
            Parent.ViewModels.Clear();
            Score = MyPlayer.Gold;
        }

        private void GoBack()
        {
            Parent.MyPage.NavigationService.Navigate(Parent.HomePage);
            SoundsViewModel.StopGameMusic();
            SoundsViewModel.StartMenuMusic();
        }
    }
}
