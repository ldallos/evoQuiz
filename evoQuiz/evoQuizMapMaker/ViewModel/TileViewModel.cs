using evoQuiz.Model;
using evoQuiz.Model.Enemies;
using evoQuiz.Model.Items;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace evoQuizMapMaker.ViewModel
{
    class TileViewModel : INotifyPropertyChanged
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Size { get { return Parent.MapScale; } }
        public ICommand SetTileCommand { get; set; }
        public MainViewModel Parent { get; set; }

        private string myName;
        public string Name
        {
            get { return myName; }
            set { myName = value; OnPropertyChanged("Name"); }
        }


        private Brush _myTileColor;
        public Brush TileColor { get { return _myTileColor; } set { _myTileColor = value; OnPropertyChanged("TileColor"); } }

        public TileElement myTileElement;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public TileViewModel(int x, int y)
        {
            PosX = x;
            PosY = y;
            SetTileCommand = new RelayCommand(SetTile);
        }

        private void SetTile()
        {
            if (myTileElement != null && Parent.PlacementMode != Helper.Mode.EreaserMode)
            {
                return;
            }

            switch (Parent.PlacementMode)
            {
                case Helper.Mode.WallMode:
                    TileColor = Brushes.Black;
                    myTileElement = new Wall(PosX, PosY);
                    break;
                case Helper.Mode.TrapMode:
                    TileColor = Brushes.Blue;
                    myTileElement = new Trap(PosX, PosY);
                    break;
                case Helper.Mode.EnemyMode:
                    TileColor = Brushes.Red;

                    if (Parent.SelectedEnemyType == typeof(Skeleton))
                    {
                        Name = "S";
                        myTileElement = new Skeleton(PosX, PosY);
                        break;
                    }
                    if (Parent.SelectedEnemyType == typeof(Thief))
                    {
                        Name = "T";
                        myTileElement = new Thief(PosX, PosY);
                        break;
                    }
                    if (Parent.SelectedEnemyType == typeof(Hydra))
                    {
                        Name = "H";
                        myTileElement = new Hydra(PosX, PosY);
                        break;
                    }
                    break;
                case Helper.Mode.ItemMode:
                    

                    if (Parent.SelectedItemType == typeof(Potion))
                    {
                        Name = "P";
                        TileColor = Brushes.Magenta;
                        myTileElement = new Potion(PosX, PosY);
                        break;
                    }
                    if (Parent.SelectedItemType == typeof(Sword))
                    {
                        Name = "S";
                        TileColor = Brushes.Magenta;
                        myTileElement = new Sword(PosX, PosY);
                        break;
                    }
                    if (Parent.SelectedItemType == typeof(Chest))
                    {
                        Name = "C";
                        TileColor = Brushes.Magenta;
                        myTileElement = new Chest(PosX, PosY);
                        break;
                    }

                    break;
                case Helper.Mode.PlayerMode:
                    TileColor = Brushes.Yellow;

                    if (Parent.Tiles.Where(y => y.myTileElement != null).All(x => x.myTileElement.GetType() != typeof(Player)))
                    {
                        myTileElement = new Player(PosX, PosY);
                    }
                    else
                    {
                        TileViewModel prevTileVM = Parent.Tiles.Where(y => y.myTileElement != null).Where(x => x.myTileElement.GetType() == typeof(Player)).FirstOrDefault();
                        prevTileVM.myTileElement = null;
                        prevTileVM.TileColor = null;
                        myTileElement = new Player(PosX, PosY);
                    }
                    
                    break;
                case Helper.Mode.EreaserMode:
                    TileColor = null;
                    myTileElement= null;
                    
                    break;
                default:
                    break;
            }
        }
    }
}
