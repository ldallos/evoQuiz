using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using evoQuiz;
using GalaSoft.MvvmLight.CommandWpf;

namespace evoQuizMapMaker.ViewModel
{
    class MainViewModel
    {
        public ObservableCollection<TileViewModel> Tiles { get; set; }
        public evoQuiz.Model.Map myMap { get; set; }
        public int MapSizeX { get { return myMap.SizeX; } set { myMap.SizeX = value; } }
        public int MapSizeY { get { return myMap.SizeY; } set { myMap.SizeY = value; } }
        public ICommand SaveMapCommand { get; set; }

        private MapSerializer ser = new MapSerializer();

        public MainViewModel()
        {
            Tiles = new ObservableCollection<TileViewModel>();

            myMap = new evoQuiz.Model.Map(50,50);

            foreach (var tile in myMap.Tiles)
            {
                Tiles.Add(new TileViewModel(tile));
            }

            SaveMapCommand = new RelayCommand(SaveMap);
        }

        private void SaveMap()
        {
            ser.SerializeMap("map.xml", myMap);
        }
    }
}
