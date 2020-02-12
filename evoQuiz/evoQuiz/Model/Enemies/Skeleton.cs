using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace evoQuiz.Model.Enemies
{
    public class Skeleton:Enemy
    {
        public Skeleton(int X, int Y) : base(X, Y)
        {
            Damage = 2;
            Gold = 300;
        }
        public Skeleton()
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
