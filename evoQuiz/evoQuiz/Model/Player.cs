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
        public Player(int X, int Y) : base(X, Y)
        {
            
            PositionZ = 3;
        }
        public Player()
        {
            
        }
        public int VisibilityRange { get; set; } = 20;
        //public List<Item> Inventory { get; set; }
        public Map myMap { get; set; }
    }
}
