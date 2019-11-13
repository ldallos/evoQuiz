using evoQuiz.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.ViewModel
{
    class MainViewModel
    {
        public ObservableCollection<TileViewModel> Tiles { get; set; }
        public Map myMap { get; set; }
        public int MapSizeX { get { return myMap.SizeX; } }
        public int MapSizeY { get { return myMap.SizeY; } }

        private MapSerializer ser = new MapSerializer();

        public MainViewModel()
        {
            Tiles = new ObservableCollection<TileViewModel>();

            myMap = ser.DeserializeMap("map.xml");

            foreach (var tile in myMap.Tiles)
            {
                Tiles.Add(new TileViewModel(tile));
            }
        }
    }
}
