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

        public override int PosX { get; set; }
        public override int PosY { get; set; }
        public override int PosZ { get; set; }
        public override int Size { get { return Parent.Parent.MapScale; } set { } }
        public InventoryViewModel Parent { get; set; }
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

        public ItemViewModel(Item item)
        {
            MyItem = item;
        }
    }
}
