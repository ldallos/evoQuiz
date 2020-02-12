using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model
{
    public abstract class Character : TileElement
    {
        public int MaxHealth { get; set; } = 10;

        private int myHealth;
        public int Health
        {
            get { return myHealth; }
            set
            {
                if (value < 0)
                {
                    myHealth = 0;
                }
                else if (value > MaxHealth)
                {
                    myHealth = MaxHealth;
                }
                else
                {
                    myHealth = value;
                }
            }
        }

        public int Damage { get; set; }
        public int Gold { get; set; }
        public Character(int X, int Y) : base(X, Y)
        {
            PositionZ = 5;

            Health = MaxHealth;
        }
        public Character()
        {

        }
    }
}
