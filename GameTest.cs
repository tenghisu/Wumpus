using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WumpusProject
{
    public partial class GameTest : Form
    {
        private GameControl gameControl;
        private Player player;
        private Wumpus wumpus;
        public GameTest()
        {
            InitializeComponent();
            gameControl = new GameControl();
            player = new Player();
            wumpus = new Wumpus();
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            player.setPlayersPosition(0);
            //while (gameControl.checkIfAlive()) - get after cave and map are done
            //{
                
            //} 
        }

        private void submitAnswer_Click(object sender, EventArgs e)
        {
            String uA = userInput.Text;
            displayBox.Text = gameControl.getCorrectness(uA);
        }

        private void checkStats_Click(object sender, EventArgs e)
        {
            playerPosition.Text = gameControl.getPlayerPosition().ToString();
            playerArrows.Text = gameControl.getArrows().ToString();
            playerCoins.Text = gameControl.getCoins().ToString();
            playerScore.Text = gameControl.getScore().ToString();
        }


        
    
        private void playTrivia_Click(object sender, EventArgs e)
        {
            displayBox.Text = gameControl.getNextQuestion();
            userInput.Text = "";
            String[] answers = new String[4];
            answers = gameControl.getAnswers();
            label8.Text = answers[0];
            label9.Text = answers[1];
            label10.Text = answers[2];
            label11.Text = answers[3];
            //}
        }

        private void getNumber_Click(object sender, EventArgs e)
        {
            questionsCorrect.Text = gameControl.getQuestionsRight().Count().ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            label8.Text = gameControl.getAnswers()[0];
        }

        private void label9_Click(object sender, EventArgs e)
        {
            label9.Text = gameControl.getAnswers()[1];
        }

        private void label10_Click(object sender, EventArgs e)
        {
            label10.Text = gameControl.getAnswers()[2];
        }

        private void label11_Click(object sender, EventArgs e)
        {
            label11.Text = gameControl.getAnswers()[3];
        }
    }
}
