using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
namespace Hunt_the_Wumpus
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

        const int NUMBER_OF_QUESTIONS = 15;

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
            StreamReader reader = new StreamReader("Assets\\Trivia.txt");
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

        public static string GetQuestion(int q)
        {
            if (q > NUMBER_OF_QUESTIONS || q <= 0)
            {
                return "No such question";
            }
            return TriviaList[q - 1];
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
                AnswerList.RemoveAt(q - 1);
                return true;
            }
            TriviaList.RemoveAt(q - 1);
            AnswerList.RemoveAt(q - 1);
            return false;
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
            return Question;
        }
    }
}
