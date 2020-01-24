using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evoQuiz.ViewModel;

namespace evoQuiz.View
{
    public class QuestionControlHandler : WindowHandler
    {
        QuestionControl questionWindow;
        public override void Hide(WindowViewModel windowViewModel)
        {
            Parent.Children.Remove(questionWindow);
        }

        public override void Show(WindowViewModel windowViewModel)
        {
            questionWindow = new QuestionControl();
            questionWindow.DataContext = windowViewModel;
            Parent.Children.Add(questionWindow);
        }
    }
}
