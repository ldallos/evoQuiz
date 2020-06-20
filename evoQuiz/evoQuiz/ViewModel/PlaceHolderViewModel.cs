using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace evoQuiz.ViewModel
{
    public class PlaceHolderViewModel : TileViewModel
    {
        public override int PosX { get; set; }
        public override int PosY { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int PosZ { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Size { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override BitmapImage Skin => throw new NotImplementedException();
    }
}
