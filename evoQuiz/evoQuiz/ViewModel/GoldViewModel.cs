using evoQuiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.ViewModel
{
    public class GoldViewModel : ViewModelBase
    {
        public Player MyPlayer { get; set; }

        private int myGold;

        public int GoldCount
        {
            get { return myGold; }
            set { myGold = value; OnPropertyChanged("GoldCount"); }
        }


        public GoldViewModel(Player player)
        {
            MyPlayer = player;
            Actions.Add(UpdateGold);
        }

        int TempGold;
        private void UpdateGold()
        {
            if (MyPlayer.Gold == TempGold)
            {
                return;
            }

            GoldCount = MyPlayer.Gold;
            TempGold = GoldCount;
        }
    }
}
