using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace evoQuiz.Model
{
    public abstract class Enemy : Character
    {
        public Enemy(int X, int Y) : base(X, Y)
        {
            PositionZ = 5;
        }
        public Enemy()
        {
            
        }

        public abstract void AbilityAfterQuestion(Player player);
        public abstract void AbilityRight(Player player);
        public abstract void AbilityWrong(Player player);
    }
}
