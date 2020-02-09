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
        public int GoldCount { get { return MyPlayer.Gold; } }

        public GoldViewModel(Player player)
        {
            MyPlayer = player;
        }
    }
}
