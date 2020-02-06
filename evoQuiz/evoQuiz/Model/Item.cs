using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.Model
{
    public abstract class Item
    {
        public string Name { get; set; }
        abstract public void Use(); 
    }
}
