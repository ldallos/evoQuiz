using evoQuiz.Model.Enemies;
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
    [XmlInclude(typeof(Skeleton))]
    [XmlInclude(typeof(Wall))]
    [XmlInclude(typeof(Player))]
    public abstract class TileElement
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int PositionZ { get; set; }

        public TileElement(int X, int y)
        {
            PositionX = X;
            PositionY = y;
        }
        public TileElement()
        {

        }
    }
}
