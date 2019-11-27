using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using evoQuiz;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace evoQuizMapMaker.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TileViewModel> Tiles { get; set; }
        public evoQuiz.Model.Map myMap { get; set; } = new evoQuiz.Model.Map();
        public int MapSizeX { get { return myMap.SizeX; } set { myMap.SizeX = value; OnPropertyChanged("MapSizeX"); } }
        public int MapSizeY { get { return myMap.SizeY; } set { myMap.SizeY = value; OnPropertyChanged("MapSizeY"); } }

        private int _myMapWidth;
        public int MapWidth { get { return _myMapWidth; } set { _myMapWidth = value; OnPropertyChanged("MapWidth"); } }

        private int _myMapHeight;
        public int MapHeight { get { return _myMapHeight; } set { _myMapHeight = value; OnPropertyChanged("MapHeight"); } }

        public int MapScale { get; set; } = 20;

        public ICommand SaveMapCommand { get; set; }
        public ICommand NewMapCommand { get; set; }
        public ICommand CancelMapCommand { get; set; }
        public ICommand CreateMapCommand { get; set; }
        public Helper.Mode PlacementMode { get; set; }

        private bool _myNewMapControlVisible;
        public bool NewMapControlVisible { get { return _myNewMapControlVisible; } set { _myNewMapControlVisible = value; OnPropertyChanged("NewMapControlVisible"); } }

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
            NewMapControlVisible = false;
            Tiles = new ObservableCollection<TileViewModel>();

            SaveMapCommand = new RelayCommand(SaveMap);
            NewMapCommand = new RelayCommand(NewMap);
            CancelMapCommand = new RelayCommand(CancelMap);
            CreateMapCommand = new RelayCommand(CreateMap);
        }

        private void SaveMap()
        {
            ser.SerializeMap("map.xml", myMap);
        }

        private void NewMap()
        {
            NewMapControlVisible = true;     
        }

        private void CancelMap()
        {
            NewMapControlVisible = false;
        }

        private void CreateMap()
        {
            myMap = new evoQuiz.Model.Map(MapSizeX, MapSizeY);   
            MapWidth = MapSizeX * MapScale;
            MapHeight = MapSizeY * MapScale;
            Tiles.Clear();
            foreach (var tile in myMap.Tiles)
            {
                Tiles.Add(new TileViewModel(tile) { Parent = this });
            }

            NewMapControlVisible = false;
        }
    }
}
