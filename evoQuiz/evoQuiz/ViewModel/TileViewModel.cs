using evoQuiz.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.ViewModel
{
    class TileViewModel : INotifyPropertyChanged
    {
        public Tile myTile { get; set; }
        public int PosX { get { return myTile.PositionX; } }
        public int PosY { get { return myTile.PositionY; } }
        public int Size { get { return Parent.MapScale; } }
        public MainViewModel Parent { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public TileViewModel(Tile tile)
        {
            myTile = tile;
        }
    }
}
