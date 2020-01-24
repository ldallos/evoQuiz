using evoQuiz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace evoQuiz
{
    public abstract class WindowHandler
    {
        public abstract void Show(WindowViewModel windowViewModel);
        public abstract void Hide(WindowViewModel windowViewModel);

        public Grid Parent;
    }
}
