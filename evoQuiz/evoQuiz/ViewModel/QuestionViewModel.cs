using evoQuiz.Model;
using evoQuiz.Model.Quiz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoQuiz.ViewModel
{
    public class QuestionViewModel : WindowViewModel
    {
        public Enemy MyEnemey { get; set; }

        private bool myQuestionControlVisible;
        public bool QuestionControlVisible
        {
            get { return myQuestionControlVisible; }
            set { myQuestionControlVisible = value; OnPropertyChanged("QuestionControlVisible"); }
        }

        public Queue<Question> Questions { get; set; } = new Queue<Question>();


        private Question myCurrentQuestion;
        public Question CurrentQuestion
        {
            get { return myCurrentQuestion; }
            set { myCurrentQuestion = value; OnPropertyChanged("QuestionText"); OnPropertyChanged("Answer1Text"); OnPropertyChanged("Answer2Text"); OnPropertyChanged("Answer3Text"); OnPropertyChanged("Answer4Text"); }
        }
        public string QuestionText { get { return CurrentQuestion.QuestionText; } }
        public string Answer1Text { get { return CurrentQuestion.Answers[0].AnswerText; } }
        public string Answer2Text { get { return CurrentQuestion.Answers[1].AnswerText; } }
        public string Answer3Text { get { return CurrentQuestion.Answers[2].AnswerText; } }
        public string Answer4Text { get { return CurrentQuestion.Answers[3].AnswerText; } }

        public QuestionViewModel()
        {
            QuestionControlVisible = false;
            GetQuestions();
        }

        private void GetQuestions()
        {
            // to do.
            //próbának jelenleg

            Questions.Enqueue(new Question() { MyDifficulty = Question.Difficulty.Easy, QuestionText = "asd1", Answers = new Answer[] { new Answer() { AnswerText = "t1" }, new Answer() { AnswerText = "t2" }, new Answer() { AnswerText = "t3" }, new Answer() { AnswerText = "t4" } } });
            Questions.Enqueue(new Question() { MyDifficulty = Question.Difficulty.Medium, QuestionText = "asd2", Answers = new Answer[] { new Answer() { AnswerText = "t1" }, new Answer() { AnswerText = "t2" }, new Answer() { AnswerText = "t3" }, new Answer() { AnswerText = "t4" } } });
            Questions.Enqueue(new Question() { MyDifficulty = Question.Difficulty.VeryEasy, QuestionText = "asd3", Answers = new Answer[] { new Answer() { AnswerText = "t1" }, new Answer() { AnswerText = "t2" }, new Answer() { AnswerText = "t3" }, new Answer() { AnswerText = "t4" } } });
            Questions.Enqueue(new Question() { MyDifficulty = Question.Difficulty.Hard, QuestionText = "asd4", Answers = new Answer[] { new Answer() { AnswerText = "t1" }, new Answer() { AnswerText = "t2" }, new Answer() { AnswerText = "t3" }, new Answer() { AnswerText = "t4" } } });
            Questions.Enqueue(new Question() { MyDifficulty = Question.Difficulty.VeryHard, QuestionText = "asd5", Answers = new Answer[] { new Answer() { AnswerText = "t1" }, new Answer() { AnswerText = "t2" }, new Answer() { AnswerText = "t3" }, new Answer() { AnswerText = "t4" } } });
        }


        public void StartQuiz(Enemy enemy)
        {
            MyEnemey = enemy;
            QuestionControlVisible = true;
            CurrentQuestion = Questions.Dequeue();
        }
    }
}
