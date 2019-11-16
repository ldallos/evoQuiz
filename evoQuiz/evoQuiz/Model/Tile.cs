using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model
{
    public class Tile
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Obstacle myObstacle { get; set; }
        public int Size { get; set; }
        public Tile(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }
        public Tile()
        {

        }
    }
}
