using evoQuiz.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.ViewModel
{
    public class InventoryViewModel : ViewModelBase
    {
        public Player MyPlayer { get; set; }
        public ObservableCollection<ItemViewModel> Items { get; set; } = new ObservableCollection<ItemViewModel>();
        public MainViewModel Parent { get; set; }
        public int InventorySizeX { get; set; } = 5;
        public int InventorySizeY { get; set; } = 5;

        private bool myInventoryControlVisible;
        public bool InventoryControlVisible
        {
            get { return myInventoryControlVisible; }
            set { myInventoryControlVisible = value; OnPropertyChanged("InventoryControlVisible"); }
        }

        public InventoryViewModel(Player player, MainViewModel parent)
        {
            for (int i = 0; i < InventorySizeY; i++)
            {
                for (int j = 0; j < InventorySizeX; j++)
                {
                    Items.Add(new ItemViewModel(null) { PosX = j, PosY = i, Parent = this });
                }
            }
            InventoryControlVisible = false;
            MyPlayer = player;
            Parent = parent;
        }

        public void Open()
        {
            InventoryControlVisible = true;
            
            for (int i = 0; i < MyPlayer.Inventory.Count; i++)
            {
                int x = Items[i].PosX;
                int y = Items[i].PosY;
                Items[i] = new ItemViewModel( MyPlayer.Inventory[i]) { PosX = x, PosY = y, Parent = this };
            }
        }

        public void Close()
        {
            InventoryControlVisible = false;
        }
    }
}
