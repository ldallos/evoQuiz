using evoQuiz.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace evoQuiz.ViewModel
{
    class PlayerViewModel : IViewModel
    {
        public Player myPlayer { get; set; }
        public int PosX { get { return myPlayer.PositionX; } set { myPlayer.PositionX = value; OnPropertyChanged("PosX"); } }
        public int PosY { get { return myPlayer.PositionY; } set { myPlayer.PositionY = value; OnPropertyChanged("PosY"); } }
        public int PosZ { get { return myPlayer.PositionZ; } set { myPlayer.PositionZ = value; OnPropertyChanged("PosZ"); } }
        public int Size { get { return Parent.MapScale; } }
        public int PosYasd { get { return 2; } }
        public BitmapImage Skin
        {
            get
            {
                return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/char.png", UriKind.RelativeOrAbsolute));
            }
        }
        public MainViewModel Parent { get; set; }
        public PlayerViewModel(Player player, MainViewModel parent)
        {
            myPlayer = player;
            Parent = parent;
            UpdateVisibility();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


        public enum Directions { Up, Down, Left, Right };
        public void Move(Directions dir)
        {
            switch (dir) 
            {
                case Directions.Up:
                    if (CheckCollision(myPlayer.PositionX, myPlayer.PositionY - 1))
                    {
                        PosY--;
                    }
                    else return;
                    break;
                case Directions.Down:
                    if (CheckCollision(myPlayer.PositionX, myPlayer.PositionY + 1))
                    {
                        PosY++;
                    }
                    else return;
                    break;
                case Directions.Left:
                    if (CheckCollision(myPlayer.PositionX-1, myPlayer.PositionY))
                    {
                        PosX--;
                    }
                    else return;
                    break;
                case Directions.Right:
                    if (CheckCollision(myPlayer.PositionX+1, myPlayer.PositionY))
                    {
                        PosX++;
                    }
                    else return;
                    break;
                default:       
                    break;
            }
            UpdateVisibility();
        }

        private bool CheckCollision(int newX, int newY)
        {
            return !Parent.myMap.TileElements.Where(x=>x is Wall).Any(x=>x.PositionX == newX && x.PositionY == newY);
        }

        private void UpdateVisibility()
        {
            Parent.GridItems.Where(x => x is ShadowViewModel).Where(x => Math.Sqrt(Math.Pow(Math.Abs((x as ShadowViewModel).PosY - this.PosY),2) + Math.Pow(Math.Abs((x as ShadowViewModel).PosX - this.PosX),2)) <= 6).ToList().ForEach(x => (x as ShadowViewModel).Opacity = 0.8);
            Parent.GridItems.Where(x => x is ShadowViewModel).Where(x => Math.Sqrt(Math.Pow(Math.Abs((x as ShadowViewModel).PosY - this.PosY), 2) + Math.Pow(Math.Abs((x as ShadowViewModel).PosX - this.PosX), 2)) <= 5).ToList().ForEach(x => (x as ShadowViewModel).Opacity = 0.5);
            Parent.GridItems.Where(x => x is ShadowViewModel).Where(x => Math.Sqrt(Math.Pow(Math.Abs((x as ShadowViewModel).PosY - this.PosY), 2) + Math.Pow(Math.Abs((x as ShadowViewModel).PosX - this.PosX), 2)) <= 3).ToList().ForEach(x => (x as ShadowViewModel).Opacity = 0);
        }
    }
}
