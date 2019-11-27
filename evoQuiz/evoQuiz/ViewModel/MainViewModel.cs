﻿using evoQuiz.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TileViewModel> Tiles { get; set; }
        public Map myMap { get; set; }
        public int MapSizeX { get { return myMap.SizeX; } set { myMap.SizeX = value; OnPropertyChanged("MapSizeX"); } }
        public int MapSizeY { get { return myMap.SizeY; } set { myMap.SizeY = value; OnPropertyChanged("MapSizeY"); } }

        private int _myMapWidth;
        public int MapWidth { get { return _myMapWidth; } set { _myMapWidth = value; OnPropertyChanged("MapWidth"); } }

        private int _myMapHeight;
        public int MapHeight { get { return _myMapHeight; } set { _myMapHeight = value; OnPropertyChanged("MapHeight"); } }

        public int MapScale { get; set; } = 20;

        private MapSerializer ser = new MapSerializer();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public MainViewModel()
        {
            Tiles = new ObservableCollection<TileViewModel>();

            myMap = ser.DeserializeMap("map.xml");
            MapWidth = MapSizeX * MapScale;
            MapHeight = MapSizeY * MapScale;
            foreach (var tile in myMap.Tiles)
            {
                Tiles.Add(new TileViewModel(tile) { Parent = this });
            }
        }
    }
}
