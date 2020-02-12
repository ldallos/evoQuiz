using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model.Enemies
{
    public class Hydra : Enemy
    {
        public Hydra(int X, int Y) : base(X, Y)
        {
            Damage = 5;
            Gold = 850;
        }
        public Hydra()
        {

        }
        public override void AbilityAfterQuestion(Player player)
        {
           
        }

        public override void AbilityRight(Player player)
        {
           
        }

        public override void AbilityWrong(Player player)
        {
           
        }
    }
}
