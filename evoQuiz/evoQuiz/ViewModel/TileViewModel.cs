using evoQuiz.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace evoQuiz.ViewModel
{
    class TileViewModel : INotifyPropertyChanged
    {
        public Tile myTile { get; set; }
        public int PosX { get { return myTile.PositionX; } }
        public int PosY { get { return myTile.PositionY; } }
        public int Size { get { return Parent.MapScale; } }
        public BitmapImage TileSkin {
            get
            {
                if (myTile.myObstacle == null) return null;

                var T = myTile.myObstacle.GetType();

                if (T == typeof(Wall))
                {
                    return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/wall.png", UriKind.RelativeOrAbsolute));
                }
                else return null;                   
            }
        }
        public MainViewModel Parent { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public TileViewModel(Tile tile)
        {
            myTile = tile;
        }
    }
}
