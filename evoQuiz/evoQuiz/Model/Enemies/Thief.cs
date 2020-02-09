using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model.Enemies
{
    public class Thief : Enemy
    {
        public Thief(int X, int Y) : base(X, Y)
        {

        }
        public Thief()
        {

        }


        public override void Ability(Player player)
        {
            int goldToSteal = (int)(player.Gold * 0.1);
            this.Gold += goldToSteal;
            player.Gold -= goldToSteal;
        }
    }
}
