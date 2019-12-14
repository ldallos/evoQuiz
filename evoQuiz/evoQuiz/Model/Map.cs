using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model
{
    public class Map
    {
        public List<TileElement> TileElements { get; set; } = new List<TileElement>();
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public Map(int x, int y)
        {
            SizeX = x;
            SizeY = y;
        }
        public Map()
        {

        }
    }
}
