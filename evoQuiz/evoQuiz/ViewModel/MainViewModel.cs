using evoQuiz.Model;
using evoQuiz.Model.Items;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace evoQuiz.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        public ObservableCollection<TileViewModel> GridItems { get; set; }
        public PlayerViewModel myPlayerViewModel { get; set; }
        public QuestionViewModel myQuestionViewModel { get; set; }
        public HealthViewModel myHealthViewModel { get; set; }
        public InventoryViewModel myInventoryViewModel { get; set; }
        public GoldViewModel myGoldViewModel { get; set; }
        private List<ViewModelBase> ViewModels = new List<ViewModelBase>();

        public Map myMap { get; set; }
        public int MapSizeX { get { return myMap.SizeX; } set { myMap.SizeX = value; OnPropertyChanged("MapSizeX"); } }
        public int MapSizeY { get { return myMap.SizeY; } set { myMap.SizeY = value; OnPropertyChanged("MapSizeY"); } }

        private int _myMapWidth;
        public int MapWidth { get { return _myMapWidth; } set { _myMapWidth = value; OnPropertyChanged("MapWidth"); } }

        private int _myMapHeight;
        public int MapHeight { get { return _myMapHeight; } set { _myMapHeight = value; OnPropertyChanged("MapHeight"); } }

        public int MapScale { get; set; } = 40;

        public double WindowHeight { get; set; }
        public double WindowWidth { get; set; }

        private Thickness myOffset;
        public Thickness Offset
        {
            get { return myOffset; }
            set { myOffset = value; OnPropertyChanged("Offset"); }
        }


        private MapSerializer ser = new MapSerializer();

        public ICommand MoveUpCommand { get; set; }
        public ICommand MoveDownCommand { get; set; }
        public ICommand MoveLeftCommand { get; set; }
        public ICommand MoveRightCommand { get; set; }
        public ICommand InventoryCommand { get; set; }
        public MainViewModel(double windowHeight, double windowWidth)
        {
            WindowHeight = windowHeight;
            WindowWidth = windowWidth;
            MoveUpCommand = new RelayCommand(MoveUp);
            MoveDownCommand = new RelayCommand(MoveDown);
            MoveLeftCommand = new RelayCommand(MoveLeft);
            MoveRightCommand = new RelayCommand(MoveRight);
            InventoryCommand = new RelayCommand(Inventory);

            GridItems = new ObservableCollection<TileViewModel>();

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
                    //myPlayerViewModel.myPlayer.Inventory.Add(new Potion());
                    //myPlayerViewModel.myPlayer.Inventory.Add(new Sword());
                    continue;
                }

                if (element is Enemy)
                {
                    GridItems.Add(new EnemyViewModel(element as Enemy, this));
                    continue;
                }

                if (element is Item)
                {
                    GridItems.Add(new ItemViewModel(element as Item, this));
                    continue;
                }
            }

            SetOffset();

            myQuestionViewModel = new QuestionViewModel() { MyPlayer = myPlayerViewModel.myPlayer, Parent = this, ControlHeight= WindowHeight, ControlWidth = WindowWidth };
            myHealthViewModel = new HealthViewModel(myPlayerViewModel.myPlayer);
            myInventoryViewModel = new InventoryViewModel(myPlayerViewModel.myPlayer, this);
            myGoldViewModel = new GoldViewModel(myPlayerViewModel.myPlayer);


            ViewModels.Add(myQuestionViewModel);
            ViewModels.Add(myHealthViewModel);
            ViewModels.Add(myInventoryViewModel);
            ViewModels.Add(myGoldViewModel);


            StartOtherThread();
        }

        private void MoveUp()
        {
            myPlayerViewModel.Move(PlayerViewModel.Directions.Up);
            SetOffset();
        }

        private void MoveDown()
        {
            myPlayerViewModel.Move(PlayerViewModel.Directions.Down);
            SetOffset();
        }

        private void MoveLeft()
        {
            myPlayerViewModel.Move(PlayerViewModel.Directions.Left);
            SetOffset();
        }

        private void MoveRight()
        {
            myPlayerViewModel.Move(PlayerViewModel.Directions.Right);
            SetOffset();
        }

        private void SetOffset()
        {
            double x = (-myPlayerViewModel.PosX -0.5) * MapScale + WindowWidth / 2;
            double y = (-myPlayerViewModel.PosY -0.5) * MapScale + WindowHeight / 2;
            Offset = new Thickness(x, y, 0, 0);
        }

        private void Inventory()
        {
            if (!myInventoryViewModel.InventoryControlVisible)
            {
                myInventoryViewModel.Open();
            }
            else
            {
                myInventoryViewModel.Close();
            }
        }


        private void StartOtherThread()
        {
            DispatcherHelper.Initialize();
            int loopIndex = 0;
            ThreadPool.QueueUserWorkItem(
                o =>
                {
                    while (true)
                    {
                        DispatcherHelper.CheckBeginInvokeOnUI(
                          () =>
                          {
                              loopIndex++;

                              foreach (var vm in ViewModels)
                              {
                                  vm.Update();
                              }
                          });
                        Thread.Sleep(mySpeed);
                    }
                }
                );
        }

        private int mySpeed = 1;


      
    }
}
