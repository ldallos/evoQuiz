using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model.Items
{
    public class Sword : Item
    {
        public override string Name { get; set; } = "Kristály Kard";
        public override string Description { get; set; } = "Elpusztít két válaszlehetőséget egy adott kérdésnél.";
        public Sword(int X, int Y) : base(X, Y)
        {

        }
        public Sword()
        {

        }
        public override void Use()
        {
            throw new NotImplementedException();
        }
    }
}
