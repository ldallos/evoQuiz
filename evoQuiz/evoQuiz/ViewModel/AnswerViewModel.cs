using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace evoQuiz.ViewModel
{
    public class AnswerViewModel : ViewModelBase
    {
        public string AnswerText { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public QuestionViewModel Parent { get; set; }
        public ICommand AnswerClickCommand { get; set; }
        public AnswerViewModel(string answer, int[] pos, QuestionViewModel parent)
        {
            AnswerClickCommand = new RelayCommand(SubmitAnswer);

            AnswerText = answer;
            PosX = pos[0];
            PosY = pos[1];
            Parent = parent;
        }

        private void SubmitAnswer()
        {
            Parent.Quiz(this.AnswerText);
        }
    }
}
