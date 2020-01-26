using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace evoQuiz.Model
{
    public class Player: TileElement
    {
        public int Health { get; set; } = 10;
        public Player(int X, int Y) : base(X, Y)
        {
            PositionZ = 3;
        }
        public Player()
        {
            
        }
        public int VisibilityRange { get; set; }
        //public List<Item> Inventory { get; set; }
        public Map myMap { get; set; }
    }
}
