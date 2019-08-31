using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            new Settings();

            endText1.Text = Settings.gameOver;
            endText2.Text = Settings.gameOverScore + Settings.score;

            endText1.Visible = Settings.endText1Vis;
            endText2.Visible = Settings.endText2Vis;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            pipeBottom.Left -= Settings.pipeSpeed;
            pipeTop.Left -= Settings.pipeSpeed;
            flappyBird.Top += Settings.gravity;
            scoreText.Text = Settings.score.ToString();


            // collision
            if (flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }

            else if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds))
            {
                endGame();
            }

            else if (flappyBird.Bounds.IntersectsWith(pipeTop.Bounds))
            {
                endGame();
            }


            // animations restart
            if (pipeBottom.Left < -80)
            {
                pipeBottom.Left = Settings.pipeBottomLoc;
                Settings.score += 1;
                endText2.Text = Settings.gameOverScore + Settings.score;
            }

            else if (pipeTop.Left < -95)
            {
                pipeTop.Left = Settings.pipeTopLoc;
                Settings.score += 1;
                endText2.Text = Settings.gameOverScore + Settings.score;
            }
        }

        private void GameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Settings.gravity = -5;
            }

            if (Settings.GameOver)
            {
                if (e.KeyCode == Keys.Space)
                {
                    new Settings();
                    pipeTop.Left = Settings.pipeTopLoc;
                    pipeBottom.Left = Settings.pipeBottomLoc;
                    Settings.score = 0;
                    endText1.Visible = Settings.endText1Vis;
                    endText2.Visible = Settings.endText2Vis;
                    Settings.GameOver = false;
                    gameTimer.Start();
                }
            }
        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Settings.gravity = 5;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            endText1.Text = Settings.score.ToString();
            //endText2.Text += Settings.score.ToString();
            endText1.Visible = true;
            endText2.Visible = true;
            Settings.GameOver = true;
        }
    }
}
