using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace evoQuiz.Model
{
    class Player
    {
        public int PositionX { get; set; } = 0;
        public int PositionY { get; set; } = 0;

        public enum Direction { Up, Down, Left, Right }
        public void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    PositionY++;
                    break;
                case Direction.Down:
                    PositionY--;
                    break;
                case Direction.Left:
                    PositionX--;
                    break;
                case Direction.Right:
                    PositionX++;
                    break;
            }
        }
    }
}
