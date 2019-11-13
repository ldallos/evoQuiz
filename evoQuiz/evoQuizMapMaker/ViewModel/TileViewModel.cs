using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace evoQuizMapMaker.ViewModel
{
    class TileViewModel : ViewModelBase
    {
        public evoQuiz.Model.Tile myTile { get; set; }
        public int PosX { get { return myTile.PositionX; } }
        public int PosY { get { return myTile.PositionY; } }
        public ICommand SetTileCommand { get; set; }
        public Brush TileColor { get; set; }
        public bool IsWall { get; set; }
        public bool IsEnemy { get; set; }
        public bool IsTrap { get; set; }

        public TileViewModel(evoQuiz.Model.Tile tile)
        {
            myTile = tile;
            SetTileCommand = new RelayCommand(SetTile);
        }

        private void SetTile()
        {
            if (IsWall)
            {
                TileColor = Brushes.Black;
                myTile.myObstacle = new evoQuiz.Model.Wall();
            }
            else if (IsEnemy)
            {
                TileColor = Brushes.Red;
                myTile.myObstacle = new evoQuiz.Model.Enemy();
            }
            else if (IsTrap)
            {
                TileColor = Brushes.Blue;
                myTile.myObstacle = new evoQuiz.Model.Trap();
            }
        }
    }
}
