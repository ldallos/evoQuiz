using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.ViewModel
{
    interface IViewModel : INotifyPropertyChanged
    {
        int PosX { get; }
        int PosY { get; }
        int PosZ { get; }

    }
}
