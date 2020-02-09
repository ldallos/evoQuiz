using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model.Items
{
    public class Potion : Item
    {
        public override string Name { get; set; } = "Élet Bájital";
        public override string Description { get; set; } = "Visszatölt 2 életpontot.";

        public Potion(int X, int Y) : base(X, Y)
        {

        }
        public Potion()
        {

        }
        public override void Use()
        {
            throw new NotImplementedException();
        }
    }
}
