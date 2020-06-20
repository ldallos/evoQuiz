using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model
{
    public class Shadow : TileElement
    {
        private double myOpacity;
        public double Opacity
        {
            get { return myOpacity; }
            set { myOpacity = value; }
        }
        public Shadow(int X, int Y): base(X, Y)
        {
            PositionZ = 10;
            Opacity = 0.9;
        }
    }
}
