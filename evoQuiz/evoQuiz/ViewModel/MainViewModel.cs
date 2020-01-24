using evoQuiz.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace evoQuiz.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<IViewModel> GridItems { get; set; }
        public PlayerViewModel myPlayerViewModel { get; set; }
        public ShadowViewModel myShadow { get; set; }
        public Map myMap { get; set; }
        public int MapSizeX { get { return myMap.SizeX; } set { myMap.SizeX = value; OnPropertyChanged("MapSizeX"); } }
        public int MapSizeY { get { return myMap.SizeY; } set { myMap.SizeY = value; OnPropertyChanged("MapSizeY"); } }

        private int _myMapWidth;
        public int MapWidth { get { return _myMapWidth; } set { _myMapWidth = value; OnPropertyChanged("MapWidth"); } }

        private int _myMapHeight;
        public int MapHeight { get { return _myMapHeight; } set { _myMapHeight = value; OnPropertyChanged("MapHeight"); } }

        public int MapScale { get; set; } = 30;

        public int WindowHeight { get; set; }
        public int WindowWidth { get; set; }

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

        public ICommand MoveUpCommand { get; set; }
        public ICommand MoveDownCommand { get; set; }
        public ICommand MoveLeftCommand { get; set; }
        public ICommand MoveRightCommand { get; set; }
        public MainViewModel()
        {
            MoveUpCommand = new RelayCommand(MoveUp);
            MoveDownCommand = new RelayCommand(MoveDown);
            MoveLeftCommand = new RelayCommand(MoveLeft);
            MoveRightCommand = new RelayCommand(MoveRight);

            GridItems = new ObservableCollection<IViewModel>();

            myMap = ser.DeserializeMap("map.xml");
            MapWidth = MapSizeX * MapScale-1;
            MapHeight = MapSizeY * MapScale-1;


            for (int i = 0; i < myMap.SizeX; i++)
            {
                for (int j = 0; j < myMap.SizeY; j++)
                {
                    GridItems.Add(new ShadowViewModel(i, j) { Parent = this });
                }
            }

            foreach (var element in myMap.TileElements)
            {
                if (element is Wall)
                {
                    GridItems.Add(new WallViewModel(element as Wall) { Parent = this });
                    continue;
                }

                if (element is Player)
                {
                    myPlayerViewModel = new PlayerViewModel(element as Player, this);
                    GridItems.Add(myPlayerViewModel);
                    continue;
                }

                if (element is Enemy)
                {
                    GridItems.Add(new EnemyViewModel(element as Enemy, this));
                    continue;
                }
            }    
        }

        private void MoveUp()
        {
            myPlayerViewModel.Move(PlayerViewModel.Directions.Up);
        }

        private void MoveDown()
        {
            myPlayerViewModel.Move(PlayerViewModel.Directions.Down);
        }

        private void MoveLeft()
        {
            myPlayerViewModel.Move(PlayerViewModel.Directions.Left);
        }

        private void MoveRight()
        {
            myPlayerViewModel.Move(PlayerViewModel.Directions.Right);
        }
    }
}
