using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model
{
    public abstract class Item:TileElement
    {
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        abstract public void Use();
        public Item(int X, int Y):base(X,Y)
        {
            PositionZ = 5;
        }
        public Item()
        {

        }
    }
}
