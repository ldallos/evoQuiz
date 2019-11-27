using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model
{
    public class Map
    {
        public List<Tile> Tiles { get; set; } = new List<Tile>();
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public Map(int x, int y)
        {
            SizeX = x;
            SizeY = y;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Tiles.Add(new Tile(i,j));
                }
            }
        }
        public Map()
        {

        }
    }
}
