using evoQuiz.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace evoQuiz.ViewModel
{
    public class ShadowViewModel: TileViewModel
    {
        public Shadow myShadow { get; set; }
        public override int PosX { get { return myShadow.PositionX; } set { myShadow.PositionX = value; OnPropertyChanged("PosX"); } }
        public override int PosY { get { return myShadow.PositionY; } set { myShadow.PositionY = value; OnPropertyChanged("PosY"); } }
        public override int PosZ { get { return myShadow.PositionZ; } set { myShadow.PositionZ = value; OnPropertyChanged("PosY"); } }
        public override int Size { get { return Parent.MapScale; } set { } }
        public double Opacity { get { return myShadow.Opacity; } set { myShadow.Opacity = value; OnPropertyChanged("Opacity"); } }
        public override BitmapImage Skin
        {
            get
            {
                return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/black.png", UriKind.RelativeOrAbsolute));
            }
        }

        public MainViewModel Parent { get; set; }
        public ShadowViewModel(int x, int y)
        {
            myShadow = new Shadow(x,y);
            Opacity = 1;
        }
    }
}
