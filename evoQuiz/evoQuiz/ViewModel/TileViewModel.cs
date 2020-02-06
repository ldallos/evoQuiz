using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace evoQuiz.ViewModel
{
    public abstract class  TileViewModel : ViewModelBase
    {
        public abstract int PosX { get; set; }
        public abstract int PosY { get; set; }
        public abstract int PosZ { get; set; }
        public abstract int Size { get; set; }
        public abstract BitmapImage Skin { get;}
    }
}
