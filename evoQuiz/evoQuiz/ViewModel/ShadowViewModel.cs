using evoQuiz.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace evoQuiz.ViewModel
{
    class ShadowViewModel: IViewModel
    {
        public Shadow myShadow { get; set; }
        public int PosX { get { return myShadow.PositionX; } set { myShadow.PositionX = value; OnPropertyChanged("PosX"); } }
        public int PosY { get { return myShadow.PositionY; } set { myShadow.PositionY = value; OnPropertyChanged("PosY"); } }
        public int PosZ { get { return myShadow.PositionZ; } set { myShadow.PositionZ = value; OnPropertyChanged("PosY"); } }
        public int Size { get { return Parent.MapScale; } }
        public double Opacity { get { return myShadow.Opacity; } set { myShadow.Opacity = value; OnPropertyChanged("Opacity"); } }
        public BitmapImage Skin
        {
            get
            {
                return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/black.png", UriKind.RelativeOrAbsolute));
            }
        }
        public MainViewModel Parent { get; set; }
        public ShadowViewModel(int x, int y)
        {
            myShadow = new Shadow(x, y);
            Opacity = 1;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
