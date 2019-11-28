using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace evoQuizMapMaker.ViewModel
{
    class TileViewModel : INotifyPropertyChanged
    {
        public evoQuiz.Model.Tile myTile { get; set; }
        public int PosX { get { return myTile.PositionX; } }
        public int PosY { get { return myTile.PositionY; } }
        public int Size { get { return Parent.MapScale; } }
        public ICommand SetTileCommand { get; set; }
        public MainViewModel Parent { get; set; }

        private Brush _myTileColor;
        public Brush TileColor { get { return _myTileColor; } set { _myTileColor = value; OnPropertyChanged("TileColor"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public TileViewModel(evoQuiz.Model.Tile tile)
        {
            myTile = tile;
            SetTileCommand = new RelayCommand(SetTile);
        }

        private void SetTile()
        {
            switch (Parent.PlacementMode)
            {
                case Helper.Mode.WallMode:
                    TileColor = Brushes.Black;
                    myTile.myObstacle = new evoQuiz.Model.Wall();
                    break;
                case Helper.Mode.TrapMode:
                    TileColor = Brushes.Red;
                    myTile.myObstacle = new evoQuiz.Model.Enemy();
                    break;
                case Helper.Mode.EnemyMode:
                    TileColor = Brushes.Blue;
                    myTile.myObstacle = new evoQuiz.Model.Trap();
                    break;
                case Helper.Mode.StartTileMode:
                    TileColor = Brushes.Yellow;
                    
                    break;
                case Helper.Mode.EreaserMode:
                    TileColor = null;
                    myTile.myObstacle = null;
                    break;
                default:
                    break;
            }
        }
    }
}
