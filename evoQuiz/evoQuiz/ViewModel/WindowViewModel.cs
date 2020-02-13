using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evoQuiz.Model;

namespace evoQuiz.ViewModel
{
    public abstract class WindowViewModel: ViewModelBase
    {
        public abstract void ItemUsed(ItemInventoryViewModel itemVM);
    }
}
