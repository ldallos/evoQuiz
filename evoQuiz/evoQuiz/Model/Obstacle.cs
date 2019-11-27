using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace evoQuiz.Model
{
    [XmlInclude(typeof(Trap))]
    [XmlInclude(typeof(Enemy))]
    [XmlInclude(typeof(Wall))]
    public abstract class Obstacle
    {
        public Tile myTile { get; set; }
    }
}
