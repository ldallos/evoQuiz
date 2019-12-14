using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model
{
    public class Wall : TileElement
    {
        public Wall(int X, int Y) : base(X, Y)
        {
            PositionZ = 1;
        }
        public Wall()
        {
            PositionZ = 1;
        }
    }
}
