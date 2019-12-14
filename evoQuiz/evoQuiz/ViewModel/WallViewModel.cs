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
    class WallViewModel : IViewModel
    {
        public Wall myWall { get; set; }
        public int PosX { get { return myWall.PositionX; } }
        public int PosY { get { return myWall.PositionY; } }
        public int PosZ { get { return myWall.PositionZ; } }
        public int Size { get { return Parent.MapScale; } }

        private double _myVisibility;
        public double Visibility { get { return _myVisibility; } set { _myVisibility = value; OnPropertyChanged("Visibility"); } }
        public BitmapImage Skin {
            get
            {
                return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/wall.png", UriKind.RelativeOrAbsolute));
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

        public WallViewModel(Wall wall)
        {
            myWall = wall;
            Visibility = 1;
        }
    }
}
