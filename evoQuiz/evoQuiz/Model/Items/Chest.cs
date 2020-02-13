using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model.Items
{
    public class Chest : Item
    {
        public override string Name { get; set; }
        public override string Description { get; set; }

        public Chest(int X, int Y) : base(X, Y)
        {

        }
        public Chest()
        {

        }

        public override void Use()
        {
            throw new NotImplementedException();
        }
    }
}
