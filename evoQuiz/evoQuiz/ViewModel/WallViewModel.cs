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
    class WallViewModel : TileViewModel
    {
        public Wall myWall { get; set; }
        public override int PosX { get { return myWall.PositionX; } set { } }
        public override int PosY { get { return myWall.PositionY; } set { } }
        public override int PosZ { get { return myWall.PositionZ; } set { } }
        public override int Size { get { return Parent.MapScale; } set { } }

        private double _myVisibility;
        public double Visibility { get { return _myVisibility; } set { _myVisibility = value; OnPropertyChanged("Visibility"); } }
        public override BitmapImage Skin {
            get
            {
                return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/wall.png", UriKind.RelativeOrAbsolute));
            }
        }

        public MainViewModel Parent { get; set; }

        public WallViewModel(Wall wall)
        {
            myWall = wall;
            Visibility = 1;
        }
    }
}
