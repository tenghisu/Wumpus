using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace WumpusProject
{
    class Trivia
    {
        // Instance Variables
        static List<string> TriviaList;
        static List<string> AList;
        static List<string> BList;
        static List<string> CList;
        static List<string> DList;
        static List<string> AnswerList;

        const int NUMBER_OF_QUESTIONS = 10;

        static bool[] QuestionsUsed;

        //Constructors
        static Trivia()
        {
            QuestionsUsed = new bool[NUMBER_OF_QUESTIONS];

            TriviaList = new List<string>();
            AList = new List<string>();
            BList = new List<string>();
            CList = new List<string>();
            DList = new List<string>();
            AnswerList = new List<string>();
            StreamReader reader = new StreamReader(@".\TriviaQuestions.txt");
            for (int i = 0; i < NUMBER_OF_QUESTIONS; i++)
            {
                TriviaList.Add(reader.ReadLine());
                AList.Add(reader.ReadLine());
                BList.Add(reader.ReadLine());
                CList.Add(reader.ReadLine());
                DList.Add(reader.ReadLine());
                AnswerList.Add(reader.ReadLine());
            }
            reader.Close();
        }
        //Accessors
        public static bool CheckQuestion(int q)
        {
            if (q < TriviaList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static int GetNumberOfQuestions()
        {
            return TriviaList.Count();
        }

        public static string GetQuestion(int q)
        {
            if (q > NUMBER_OF_QUESTIONS || q <= 0)
            {
                return "No such question.";
            }
            if (TriviaList.Count == 0)
            {
                return "Out of Questions.";
            }
            return TriviaList[q - 1];
        }
        public static string[] GetAnswers(int q)
        {
            String[] answers = new String[4];
            if (AList.Count == 0)
            {
                answers[0] = "Out of answers.";
                answers[1] = "Out of answers.";
                answers[2] = "Out of answers.";
                answers[3] = "Out of answers.";
                return answers;
            }
            answers[0] = AList[q - 1];
            answers[1] = BList[q - 1];
            answers[2] = CList[q - 1];
            answers[3] = DList[q - 1];

            return answers;
        }

        public static string GetAnswer(int q)
        {
            if (q > NUMBER_OF_QUESTIONS || q <= 0)
            {
                return "No such answer";
            }
            return AnswerList[q - 1];
        }

        public static bool CheckAnswer(string answer, int q)
        {
            if (q > NUMBER_OF_QUESTIONS || q <= 0)
            {
                return false;
            }
            if (answer.Equals(AnswerList[q - 1]))
            {
                TriviaList.RemoveAt(q - 1);
                AList.RemoveAt(q - 1);
                BList.RemoveAt(q - 1);
                CList.RemoveAt(q - 1);
                DList.RemoveAt(q - 1);
                AnswerList.RemoveAt(q - 1);
                return true;
            }
            else
            { 
                TriviaList.RemoveAt(q - 1);
                AList.RemoveAt(q - 1);
                BList.RemoveAt(q - 1);
                CList.RemoveAt(q - 1);
                DList.RemoveAt(q - 1);
                AnswerList.RemoveAt(q - 1);
                return false;
            }            
        }

        public static bool AllQuestionsUsed
        {
            get
            {
                foreach (bool b in QuestionsUsed)
                    if (!b)
                        return false;
                return true;
            }
        }

        public static string[] GetRandomQuestionAndAnswers()
        {
            Random r = new Random();
            int Number;

            if(AllQuestionsUsed)
            {
                for(int i = 0; i < QuestionsUsed.Length; i++)
                    QuestionsUsed[i] = false;
            }

            do
            {
                Number = r.Next(NUMBER_OF_QUESTIONS);
            } while (QuestionsUsed[Number]);

            QuestionsUsed[Number] = true;

            string[] Question = new string[6];
            Question[0] = TriviaList[Number];
            Question[1] = AList[Number];
            Question[2] = BList[Number];
            Question[3] = CList[Number];
            Question[4] = DList[Number];
            Question[5] = AnswerList[Number];
            Question[6] = Number.ToString();
            return Question;
        }
    }
}
