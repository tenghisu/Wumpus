using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterfaceNEW2
{
    public partial class UserInterfaceTest : Form
    {
        //GameControl gameControl();
        public String answerChosen = "";
        public String question = "";

        public UserInterfaceTest()
        {
            InitializeComponent();
            CavePnl.Hide();
            StatsPnl.Hide();
            TriviaPnl.Hide();
            secretLbl.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newGameBttn_Click(object sender, EventArgs e)
        {
            CavePnl.Show();
            NewGamePnl.Hide();
        }

        private void StatsQuitBttn_Click(object sender, EventArgs e)
        {
            StatsPnl.Hide();
            CavePnl.Show();
        }

        private void StatsBttn_Click(object sender, EventArgs e)
        {
            StatsPnl.Show();
            CavePnl.Hide();
            //scores(GameControl.getStats());

        }

        public void scores(int[] stats)
        {
            //score, turns, coins, arrows, 
            CoinsLbl.Text = "Coins: " + stats[2];
            ArrowLbl.Text = "Arrows: " + stats[3];
            ScoresGottenLbl.Text = "Score: " + stats[0];
            TurnsTakenLbl.Text = "Turns: " + stats[1];
        }

        private void GetSecretBttn_Click(object sender, EventArgs e)
        {
            TriviaPnl.Show();
            CavePnl.Hide();

            bool secret = gameControl.triviaRound(2, 3);
            if (secret)
            {
                secretLbl.Text = "Your secret is: " + gameControl.getSecret();
                secretLbl.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TriviaPnl.Hide();
            CavePnl.Show();
        }

        private void Abttn_Click(object sender, EventArgs e)
        {
            answerChosen = "a";
        }

        private void Bbttn_Click(object sender, EventArgs e)
        {
            answerChosen = "b";
        }

        private void Cbttn_Click(object sender, EventArgs e)
        {
            answerChosen = "c";
        }

        private void Dbttn_Click(object sender, EventArgs e)
        {
            answerChosen = "d";
        }

     /*  public bool triviaTime(int questionsNeeded) //receives trivia question from Trivia object and displays it
        {
                question = gameControl.getNextQuestion();
                QuestionLbl.Text = "Question: " + question;
                QuestionsNeededLbl.Text = questionsNeeded.ToString();

                String[] answersArr = gameControl.getAnswers();
                //GC returns ArrayList of answer choices
                //set each label with different index of arraylist
                answerALbl.Text = answersArr[0];
                answerBLbl.Text = answersArr[1];
                answerCLbl.Text = answersArr[2];
                answerDLbl.Text = answersArr[3];

           bool correct = gameControl.getCorrectness(answerChosen);

            if (correct)
               answerLbl.Text = "Your answer is " + "correct!";
           else
                 answerLbl.Text = answerChosen + " is wrong!";

            return correct;
        }*/
    }
}
