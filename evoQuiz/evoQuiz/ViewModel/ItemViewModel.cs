using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using evoQuiz.Model;
using evoQuiz.Model.Items;

namespace evoQuiz.ViewModel
{
    public class ItemViewModel : TileViewModel
    {
        private Item _myItem;
        public Item MyItem
        {
            get { return _myItem; }
            set { _myItem = value; OnPropertyChanged("Skin"); }
        }

        public override int PosX { get { return MyItem.PositionX; } set { MyItem.PositionX = value; OnPropertyChanged("PosX"); } }
        public override int PosY { get { return MyItem.PositionY; } set { MyItem.PositionY = value; OnPropertyChanged("PosY"); } }
        public override int PosZ { get { return MyItem.PositionZ; } set { MyItem.PositionZ = value; OnPropertyChanged("PosZ"); } }
        public override int Size { get { return Parent.MapScale; } set { } }
        public MainViewModel Parent { get; set; }
        public override BitmapImage Skin
        {
            get
            {
                if (MyItem is Sword)
                {
                    return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/Items/sword.png", UriKind.RelativeOrAbsolute));
                }
                else if (MyItem is Potion)
                {
                    return new BitmapImage(new Uri(@"pack://application:,,,/evoQuiz;component/Images/Items/potion.png", UriKind.RelativeOrAbsolute));
                }

                return null;
            }
        }

        public ItemViewModel(Item item, MainViewModel parent)
        {
            MyItem = item;
            Parent = parent;
        }
    }
}
