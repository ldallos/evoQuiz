using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using evoQuiz;
using evoQuiz.Model;
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
        public ICommand OpenMapCommand { get; set; }
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
            OpenMapCommand = new RelayCommand(OpenMap);
        }

        private void SaveMap()
        {
            foreach (var tile in Tiles)
            {
                myMap.TileElements.Add(tile.myTileElement);
            }
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

            for (int i = 0; i < myMap.SizeX; i++)
            {
                for (int j = 0; j < myMap.SizeY; j++)
                {
                    Tiles.Add(new TileViewModel(i,j) { Parent = this });
                }
            }

            NewMapControlVisible = false;
        }

        private void OpenMap()
        {
            myMap = ser.DeserializeMap("map.xml");
            MapWidth = MapSizeX * MapScale;
            MapHeight = MapSizeY * MapScale;
            Tiles.Clear();

            for (int i = 0; i < myMap.SizeX; i++)
            {
                for (int j = 0; j < myMap.SizeY; j++)
                {
                    Tiles.Add(new TileViewModel(i, j) { Parent = this });
                }
            }

            //foreach (var element in myMap.TileElements.Where(x=>x != null))
            //{
            //    TileViewModel tile = Tiles.Where(x=>(x.PosX == element.PositionX && x.PosY == element.PositionY)).FirstOrDefault();
            //    tile.myTileElement = element;

            //    if (element is Wall)
            //    {
            //        tile.TileColor = Brushes.Black;
            //    }
            //    else if (element is Player)
            //    {
            //        tile.TileColor = Brushes.Yellow;
            //    }
            //    else if (element is Enemy)
            //    {
            //        tile.TileColor = Brushes.Blue;
            //    }
            //    else if (element is Trap)
            //    {
            //        tile.TileColor = Brushes.Red;
            //    }
            //}
        }
    }
}
