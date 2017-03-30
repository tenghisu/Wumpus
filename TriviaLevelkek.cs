using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PointFHelp;

namespace Hunt_the_Wumpus
{
    class TriviaLevel : Menu
    {
        TheLevel LevelToReturnTo;
        Arm ToAddTo;
        GameObject[] ToReadd;

        int MusicTimer;
        Sound TriviaMusic = new Sound("TriviaMusic.mp3"); // this is the sound for trivia
        const int TriviaMusicDuration = 33; //This is in seconds;

        Sound Correct = new Sound("Correct.mp3");
        Sound Wrong = new Sound("Wrong.mp3");

        public TriviaLevel(TheLevel l, Arm a, GameObject[] Objects)
        {
            LevelToReturnTo = l;
            ToAddTo = a;
            ToReadd = Objects;
        }
        public override void Initialize()
        {
            base.Initialize();

            CurrentSelected = 0;

            Buttons = new Button[4];  // holds all the A,B,C,D buttons

            Buttons[0] = new Button("A", "AText1.png", "AText2.png", 47, 39);  // A button
            Buttons[0].Position = new PointF(-600, 0);

            Buttons[1] = new Button("B", "BText1.png", "BText2.png", 39, 36);  // B button
            Buttons[1].Position = new PointF(-600, -60);

            Buttons[2] = new Button("C", "CText1.png", "CText2.png", 45, 38);  // C button
            Buttons[2].Position = new PointF(-600, -120);

            Buttons[3] = new Button("D", "DText1.png", "DText2.png", 50, 38);  // D button
            Buttons[3].Position = new PointF(-600, -180);

            foreach (Button b in Buttons)  // add all these buttons to the screen
            {
                ObjectManager.AddGameObject(b);
            }

            Game.LifeCounter.Visible = false;  // set all of the counters to not visible
            Game.DiskCounter.Visible = false;
            Game.RoomMessage.Visible = false;

            Game.Question.Visible = true;
            Game.OptionA.Visible = true;
            Game.OptionB.Visible = true;
            Game.OptionC.Visible = true;
            Game.OptionD.Visible = true;

            QuestionsCorrect = 0;
            CurrentQuestion = Trivia.GetRandomQuestionAndAnswers(); 

            TriviaMusic.Play();  // play the music when in trivia
            MusicTimer = TriviaMusicDuration * (int)FrameRateController.FrameRate;
        }
        int QuestionsCorrect;
        string[] CurrentQuestion;
        public override void Update()
        {
            base.Update();

            MusicTimer--;
            if (MusicTimer == 0)
            {
                MusicTimer = TriviaMusicDuration * (int)FrameRateController.FrameRate;
                TriviaMusic.Play();
            }

            Game.Question.Text = CurrentQuestion[0];

            Game.OptionA.Text = CurrentQuestion[1];
            Game.OptionB.Text = CurrentQuestion[2];
            Game.OptionC.Text = CurrentQuestion[3];
            Game.OptionD.Text = CurrentQuestion[4];

            if (InputManager.IsKeyTriggered(Keys.Enter) || (Player1.IsAPressed && CanPressA))  // when an option is chosen
            {
                CanPressA = false;
                string Selection = "";
                switch (CurrentSelected)
                {
                    case 0:
                        Selection = "A";
                        break;
                    case 1:
                        Selection = "B";
                        break;
                    case 2:
                        Selection = "C";
                        break;
                    case 3:
                        Selection = "D";
                        break;
                }
                if (Selection == CurrentQuestion[5])  // if it is the correct answer
                {
                    QuestionsCorrect++;  // increment questions
                    Correct.Play();  // play the right sound
                }
                else
                {
                    Wrong.Play();  // play the wrong sound
                }
                if (QuestionsCorrect == 3)  // when 3 questions have been answered 
                {
                    ToAddTo.Ammo += 20;

                    Game.LifeCounter.Visible = true;
                    Game.DiskCounter.Visible = true;

                    Game.Question.Visible = false;
                    Game.OptionA.Visible = false;
                    Game.OptionB.Visible = false;
                    Game.OptionC.Visible = false;
                    Game.OptionD.Visible = false;
                    foreach (GameObject g in ToReadd)
                        ObjectManager.AddGameObject(g);
                    foreach (Button b in Buttons)
                        ObjectManager.RemoveGameObject(b);
                    GameStateManager.SetCurrentStateNoInitialize(LevelToReturnTo);
                }
                CurrentQuestion = Trivia.GetRandomQuestionAndAnswers();
            }
        }
    }
}
