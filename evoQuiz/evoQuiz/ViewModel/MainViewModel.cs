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
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace evoQuiz.ViewModel
{
    public class MainViewModel: WindowViewModel
    {
        public Page MyPage { get; set; }
        public Page HomePage { get; set; }
        public List<TileViewModel> GridItems { get; set; }
        public ObservableCollection<TileViewModel> LoadedGridItems { get; set; }
        public PlayerViewModel myPlayerViewModel { get; set; }
        public QuestionViewModel myQuestionViewModel { get; set; }
        public HealthViewModel myHealthViewModel { get; set; }
        public InventoryViewModel myInventoryViewModel { get; set; }
        public GoldViewModel myGoldViewModel { get; set; }
        public GameOverViewModel myGameOverViewModel { get; set; }
        public List<ViewModelBase> ViewModels = new List<ViewModelBase>();
        public List<TileViewModel> Shadows = new List<TileViewModel>();
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

            GridItems = new List<TileViewModel>();
            LoadedGridItems = new ObservableCollection<TileViewModel>();

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

                if (element is Item)
                {
                    GridItems.Add(new ItemViewModel(element as Item, this));
                    continue;
                }
            }

            SetOffset();
            LoadSurroundingMap();

            myQuestionViewModel = new QuestionViewModel(myPlayerViewModel.myPlayer) { Parent = this, ControlHeight= WindowHeight, ControlWidth = WindowWidth };
            myHealthViewModel = new HealthViewModel(myPlayerViewModel.myPlayer);
            myInventoryViewModel = new InventoryViewModel(myPlayerViewModel.myPlayer, this);
            myGoldViewModel = new GoldViewModel(myPlayerViewModel.myPlayer);
            myGameOverViewModel = new GameOverViewModel(myPlayerViewModel.myPlayer) { Parent = this };

            ViewModels.Add(myGameOverViewModel);
            ViewModels.Add(myQuestionViewModel);
            ViewModels.Add(myHealthViewModel);
            ViewModels.Add(myInventoryViewModel);
            ViewModels.Add(myGoldViewModel);
            ViewModels.Add(myPlayerViewModel);
            foreach (var enemy in GridItems.Where(x=>x is EnemyViewModel).ToList())
            {
                ViewModels.Add(enemy);
            }

            StartOtherThread();
        }

        private void LoadSurroundingMap()
        {
            List<TileViewModel> InRange = GridItems.Where(x=> Math.Sqrt(Math.Pow((x.PosY - myPlayerViewModel.PosY), 2) + Math.Pow((x.PosX - myPlayerViewModel.PosX), 2)) < myPlayerViewModel.myPlayer.VisibilityRange + 2).ToList<TileViewModel>();
            List<TileViewModel> Exept1 = LoadedGridItems.Except(InRange).ToList();
            foreach (var item in Exept1)
            {
                LoadedGridItems.Remove(item);
            }
            List<TileViewModel> Exept2 = InRange.Except(LoadedGridItems).ToList();
            foreach (var item in Exept2)
            {
                LoadedGridItems.Add(item);
            }

            //foreach (var item in GridItems)
            //{
            //    if (Math.Sqrt(Math.Pow(Math.Abs(item.PosY - myPlayerViewModel.PosY), 2) + Math.Pow(Math.Abs(item.PosX - myPlayerViewModel.PosX), 2)) < myPlayerViewModel.myPlayer.VisibilityRange+2)
            //    {
            //        LoadedGridItems.Add(item);
            //    }      
            //}

            Shadows = LoadedGridItems.Where(x => x is ShadowViewModel).ToList();
        }

        private void MoveUp()
        {
            myPlayerViewModel.Move(PlayerViewModel.Directions.Up);
            LoadSurroundingMap();
        }

        private void MoveDown()
        {
            myPlayerViewModel.Move(PlayerViewModel.Directions.Down);
            LoadSurroundingMap();
        }

        private void MoveLeft()
        {
            myPlayerViewModel.Move(PlayerViewModel.Directions.Left);
            LoadSurroundingMap();
        }

        private void MoveRight()
        {
            myPlayerViewModel.Move(PlayerViewModel.Directions.Right);
            LoadSurroundingMap();
        }

        private void SetOffset()
        {
            double x = ((-(double)myPlayerViewModel.myPlayer.VisibilityRange*2+1)/2 * MapScale) + WindowWidth / 2;
            double y = ((-(double)myPlayerViewModel.myPlayer.VisibilityRange * 2 + 1) / 2 * MapScale) + WindowHeight / 2;
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

        public void GameOver()
        {
            myQuestionViewModel.QuestionControlVisible = false;
            myGameOverViewModel.Open();
        }

        private void StartOtherThread()
        {
            DispatcherHelper.Initialize();
            
            ThreadPool.QueueUserWorkItem(
                o =>
                {
                    while (true)
                    {
                        DispatcherHelper.CheckBeginInvokeOnUI(
                          () =>
                          {
                              IterationNumber++;

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

        public override void ItemUsed(ItemInventoryViewModel itemVM)
        {
        
        }

        private int mySpeed = 1;
        public int IterationNumber = 0;

    }
}
