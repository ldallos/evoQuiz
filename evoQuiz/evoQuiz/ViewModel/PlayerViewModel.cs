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

            //UpdateVisibilityV2();
            Update();
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
            //UpdateVisibilityV2();
            Update();
        }

        private bool CheckCollision(int newX, int newY)
        {
            return !Parent.myMap.TileElements.Where(x=>x is Wall).Any(x=>x.PositionX == newX && x.PositionY == newY);
        }

        //private void UpdateVisibility()
        //{
        //    Parent.GridItems.Where(x => x is ShadowViewModel).Where(x => Math.Sqrt(Math.Pow(Math.Abs((x as ShadowViewModel).PosY - this.PosY),2) + Math.Pow(Math.Abs((x as ShadowViewModel).PosX - this.PosX),2)) <= 6).ToList().ForEach(x => (x as ShadowViewModel).Opacity = 0.8);
        //    Parent.GridItems.Where(x => x is ShadowViewModel).Where(x => Math.Sqrt(Math.Pow(Math.Abs((x as ShadowViewModel).PosY - this.PosY), 2) + Math.Pow(Math.Abs((x as ShadowViewModel).PosX - this.PosX), 2)) <= 5).ToList().ForEach(x => (x as ShadowViewModel).Opacity = 0.5);
        //    Parent.GridItems.Where(x => x is ShadowViewModel).Where(x => Math.Sqrt(Math.Pow(Math.Abs((x as ShadowViewModel).PosY - this.PosY), 2) + Math.Pow(Math.Abs((x as ShadowViewModel).PosX - this.PosX), 2)) <= 3).ToList().ForEach(x => (x as ShadowViewModel).Opacity = 0);
        //}

        //private void UpdateVisibilityV2()
        //{
        //    Parent.GridItems.Where(i => i is ShadowViewModel).ToList().ForEach(x => (x as ShadowViewModel).Opacity = 1);
        //    List<int[]> ShadowEnds = GetShadowEndCoordinates();

        //    foreach (var coord in ShadowEnds)
        //    {
        //        int x1 = this.PosX;
        //        int y1 = this.PosY;
        //        int x2 = coord[0];
        //        int y2 = coord[1];

        //        int m_new = 2 * (y2 - y1);
        //        int slope_error_new = m_new - (x2 - x1);

        //        double opacity = 0;
        //        for (int x = x1, y = y1; x <= x2; x++)
        //        {
                     
        //            ShadowViewModel shadow = Parent.GridItems.Where(i => i is ShadowViewModel).Where(i => (i as ShadowViewModel).PosX == x && (i as ShadowViewModel).PosY == y).FirstOrDefault() as ShadowViewModel;
        //            shadow.Opacity = opacity;
        //            opacity += 1/20;
        //            slope_error_new += m_new;          
               
        //            if (slope_error_new >= 0)
        //            {
        //                y++;
        //                slope_error_new -= 2 * (x2 - x1);
        //            }
        //            //todo: IviewModel bővítése a konvertálások elkerüöléséhez
        //            if (Parent.GridItems.Where(i=>i is WallViewModel).Any(i=>(i as WallViewModel).PosX == x && (i as WallViewModel).PosY == y))
        //            {
        //                break;
        //            }
        //        }
        //    }

            
        //}

        //private List<int[]> GetShadowEndCoordinates()
        //{
        //    return Parent.GridItems.Where(x => x is ShadowViewModel).Where(x => Math.Round(Math.Sqrt(Math.Pow(Math.Abs((x as ShadowViewModel).PosY - this.PosY), 2) + Math.Pow(Math.Abs((x as ShadowViewModel).PosX - this.PosX), 2))) == 20).Select(x => new int[]{ (x as ShadowViewModel).PosX, (x as ShadowViewModel).PosY }).ToList();
        //}


        private List<IViewModel> GetSurroundingShadows(IViewModel shadow)
        {
            return Parent.GridItems.Where(x=> x is ShadowViewModel && Math.Sqrt(Math.Pow(Math.Abs(x.PosY - shadow.PosY), 2) + Math.Pow(Math.Abs(x.PosX - shadow.PosX), 2)) < 2).ToList();
        }

        private List<ShadowViewModel> shadowsToBlend = new List<ShadowViewModel>();
        private void drawBresenham(int x0, int y0, int x1, int y1)
        {
            float opacity = 0;
            int dx = Math.Abs(x1 - x0);
            int sx = -1;
            if (x0 < x1)
            {
                sx = 1;
            }
            int dy = Math.Abs(y1 - y0);
            int sy = -1;
            if (y0 < y1)
            {
                sy = 1;
            }
            float err = -dy / 2;
            if (dx > dy){
                err = dx / 2;
            }
            do
            {
                if (x0 < 0 || y0 < 0 || x0 >= Parent.MapSizeX || y0 >= Parent.MapSizeY)
                {
                    break;
                }

                ShadowViewModel shadow = Parent.GridItems.Where(i => i is ShadowViewModel).Where(i => (i as ShadowViewModel).PosX == x0 && (i as ShadowViewModel).PosY == y0).FirstOrDefault() as ShadowViewModel;
                if (shadow.Opacity>=opacity)
                {
                    shadow.Opacity = opacity;
                    shadow.myShadow.Visited = true;
                }
                opacity += (float)0.1;
                shadowsToBlend.Add(shadow);

                if (opacity >=1)
                {
                    break;
                }

                if (Parent.GridItems.Where(i => i is WallViewModel).Any(i => i.PosX == x0 && i.PosY == y0))
                {
                    break;
                }

                float e2 = err;
                if (e2 > -dx)
                {
                    err -= dy;
                    x0 += sx;
                }
                if (e2 < dy)
                {
                    err += dx;
                    y0 += sy;
                }
            } while (x0 != x1 || y0 != y1);

        }

        private void drawBresenhamCircle(int x0, int y0, int radius)
        {
            int x = -radius;
            int y = 0;
            int err = 2 - 2 * radius;
            do
            {
                drawBresenham(x0, y0, (x0 - x), (y0 + y));
                drawBresenham(x0, y0, (x0 - y), (y0 - x));
                drawBresenham(x0, y0, (x0 + x), (y0 - y));
                drawBresenham(x0, y0, (x0 + y), (y0 + x));
                radius = err;
                if (radius <= y)
                {
                    y++;
                    err += y * 2 + 1;
                }
                if (radius > x || err > y){
                    x++;
                    err += x * 2 + 1;
                }
            } while (x < 0);
        }

      
        private void BlendShadows()
        {
            foreach (var shadow in shadowsToBlend)
            {
                float OpacitySum = 0;
                List<IViewModel> SurShadows = GetSurroundingShadows(shadow);
                foreach (var s in SurShadows)
                {
                    OpacitySum += (float)(s as ShadowViewModel).Opacity;
                }
                (shadow as ShadowViewModel).Opacity = OpacitySum / SurShadows.Count;
            }
        }

        private void Update()
        {
            Parent.GridItems.Where(i => i is ShadowViewModel).ToList().ForEach(i => (i as ShadowViewModel).Opacity = 1);
            shadowsToBlend.Clear();
            drawBresenhamCircle(PosX, PosY, 9);
            //BlendShadows();
        }
    }
}
