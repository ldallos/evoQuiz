using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model
{
    public abstract class Character : TileElement
    {
        public int Health { get; set; } = 10;
        public int Damage { get; set; } = 10;
        public int Gold { get; set; }
        public Character(int X, int Y) : base(X, Y)
        {

        }
        public Character()
        {

        }
    }
}
