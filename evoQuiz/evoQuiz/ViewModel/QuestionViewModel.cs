using evoQuiz.Model;
using evoQuiz.Model.Quiz;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.ViewModel
{
    public class QuestionViewModel : WindowViewModel
    {
        public EnemyViewModel EnemyVM { get; set; }
        public HealthViewModel EnemyHealthViewModel { get; set; }
        public Player MyPlayer { get; set; }
        public MainViewModel Parent { get; set; }

        private bool myQuestionControlVisible;
        public bool QuestionControlVisible
        {
            get { return myQuestionControlVisible; }
            set { myQuestionControlVisible = value; OnPropertyChanged("QuestionControlVisible"); }
        }

        public Queue<Question> Questions { get; set; } = new Queue<Question>();
        public ObservableCollection<AnswerViewModel> Answers { get; set; } = new ObservableCollection<AnswerViewModel>();

        private Question myCurrentQuestion;
        public Question CurrentQuestion
        {
            get { return myCurrentQuestion; }
            set { myCurrentQuestion = value; OnPropertyChanged("QuestionText"); OnPropertyChanged("Answer1Text"); OnPropertyChanged("Answer2Text"); OnPropertyChanged("Answer3Text"); OnPropertyChanged("Answer4Text"); }
        }
        public string QuestionText { get { return CurrentQuestion.QuestionText; } }

        public QuestionViewModel()
        {
            QuestionControlVisible = false;
            CurrentQuestion = new Question() { QuestionText = "PlaceHolder", Answers = new Answer[] { new Answer() { AnswerText = "" }, new Answer() { AnswerText = "" }, new Answer() { AnswerText = "" }, new Answer() { AnswerText = "" }}};
            GetQuestions();

            
        }

        private void GetQuestions()
        {
            // to do.
            //próbának jelenleg

            Questions.Enqueue(new Question() { MyDifficulty = Question.Difficulty.Easy, QuestionText = "asd1", Answers = new Answer[] { new Answer() { AnswerText = "t1", IsCorrect=true}, new Answer() { AnswerText = "t2" }, new Answer() { AnswerText = "t3" }, new Answer() { AnswerText = "t4" } } });
            Questions.Enqueue(new Question() { MyDifficulty = Question.Difficulty.Medium, QuestionText = "asd21312", Answers = new Answer[] { new Answer() { AnswerText = "t1", IsCorrect = true }, new Answer() { AnswerText = "t2" }, new Answer() { AnswerText = "t3" }, new Answer() { AnswerText = "t4" } } });
            Questions.Enqueue(new Question() { MyDifficulty = Question.Difficulty.VeryEasy, QuestionText = "asd311111111", Answers = new Answer[] { new Answer() { AnswerText = "t1", IsCorrect = true }, new Answer() { AnswerText = "t2" }, new Answer() { AnswerText = "t3" }, new Answer() { AnswerText = "t4" } } });
            Questions.Enqueue(new Question() { MyDifficulty = Question.Difficulty.Hard, QuestionText = "asd22224", Answers = new Answer[] { new Answer() { AnswerText = "t1", IsCorrect = true }, new Answer() { AnswerText = "t2" }, new Answer() { AnswerText = "t3" }, new Answer() { AnswerText = "t4" } } });
            Questions.Enqueue(new Question() { MyDifficulty = Question.Difficulty.VeryHard, QuestionText = "asd533333333333333", Answers = new Answer[] { new Answer() { AnswerText = "t1", IsCorrect = true }, new Answer() { AnswerText = "t2" }, new Answer() { AnswerText = "t3" }, new Answer() { AnswerText = "t4" } } });
        }


        public void StartQuiz(EnemyViewModel enemy)
        {
            EnemyVM = enemy;
            QuestionControlVisible = true;
            EnemyHealthViewModel = new HealthViewModel(enemy.myEnemy);
            GetCurrentQuestion();
        }

        private void GetCurrentQuestion()
        {
            CurrentQuestion = Questions.Dequeue();

            int[][] Pos = new int[][] { new int[] { 0, 0 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 1, 1 } };

            for (int i = 0; i < CurrentQuestion.Answers.Length; i++)
            {
                Answers.Add(new AnswerViewModel(CurrentQuestion.Answers[i], Pos[i], this));
            }
        }


        public void Quiz(Answer answer)
        {
            if (answer.IsCorrect)
            {
                EnemyVM.myEnemy.Health -= MyPlayer.Damage;

                if (EnemyVM.myEnemy.Health<=0)
                {
                    EndQuiz();
                    return;
                }

                
            }
            else
            {
                MyPlayer.Health -= EnemyVM.myEnemy.Damage;
            }

            GetCurrentQuestion();
        }


        private void EndQuiz()
        {
            QuestionControlVisible = false;
            Parent.GridItems.Remove(EnemyVM);
        }
    }
}
