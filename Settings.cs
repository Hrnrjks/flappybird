using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    class Settings
    {
        public static string gameOver = "Game Over!";
        public static string gameOverScore = "Your final score is: ";

        public static int pipeSpeed = 5;
        public static int gravity = 5;
        public static int score = 0;

        //public static int pipeBottomLoc = 1050;
        public static int pipeBottomLoc = 1220;
        public static int pipeTopLoc = 1000;

        public static bool GameOver = false;

        public static bool endText1Vis = false;
        public static bool endText2Vis = false;
    }
}
