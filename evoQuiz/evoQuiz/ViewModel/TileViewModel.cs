using evoQuiz.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.ViewModel
{
    class TileViewModel : ViewModelBase
    {
        public Tile myTile { get; set; }
        public int PosX { get { return myTile.PositionX; } }
        public int PosY { get { return myTile.PositionY; } }

        public TileViewModel(Tile tile)
        {
            myTile = tile;
        }
    }
}
