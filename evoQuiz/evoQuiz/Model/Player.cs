using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace evoQuiz.Model
{
    public class Player: Character
    {
        public Player(int X, int Y) : base(X, Y)
        {
            PositionZ = 5;
        }
        public Player()
        {
            
        }
        public int VisibilityRange { get; set; }
        public List<Item> Inventory { get; set; }
        public Map myMap { get; set; }
    }
}
