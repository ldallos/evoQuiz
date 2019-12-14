using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model
{
    class Shadow : TileElement
    {
        public double Opacity { get; set; }
        public Shadow(int X, int Y): base(X, Y)
        {
            PositionZ = 10;
            Opacity = 0.9;
        }
    }
}
