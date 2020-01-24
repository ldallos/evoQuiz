using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model
{
    class Shadow : TileElement
    {
        private double myOpacity;
        public double Opacity
        {
            get { return myOpacity; }
            set
            {
                myOpacity = value;
                if (Visited && value<0.3)
                {
                    myOpacity = 0.3;
                }
            }
        }

        public bool Visited { get; set; } = false;
        public Shadow(int X, int Y): base(X, Y)
        {
            PositionZ = 10;
            Opacity = 0.9;
        }
    }
}
