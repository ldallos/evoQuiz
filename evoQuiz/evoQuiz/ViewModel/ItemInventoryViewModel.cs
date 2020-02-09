using evoQuiz.Model.Items;
using evoQuiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace evoQuiz.ViewModel
{
    public class ItemInventoryViewModel : TileViewModel
    {
        private Item _myItem;
        public Item MyItem
        {
            get { return _myItem; }
            set { _myItem = value; OnPropertyChanged("Skin"); }
        }

        public string ItemName { get { return MyItem.Name; } }
        public string ItemDescription { get { return MyItem.Description; } }
        public override int PosX { get; set; }
        public override int PosY { get; set; }
        public override int PosZ { get; set; }
        public override int Size { get { return Parent.ItemSize; } set { } }
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

        public ItemInventoryViewModel(Item item)
        {
            MyItem = item;
        }
    }
}
