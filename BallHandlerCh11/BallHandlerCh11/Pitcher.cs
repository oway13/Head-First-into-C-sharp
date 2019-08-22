using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallHandlerCh11
{
    class Pitcher
    {
        public Pitcher(Ball ball)
        {
            ball.BallInPlay += new EventHandler(Ball_BallInPlay);
        }

        private void Ball_BallInPlay(object sender, EventArgs e)
        {
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if ((ballEventArgs.Distance < 95) && ballEventArgs.Trajectory < 60)
                    CatchBall();
                else
                    CoverFirstBase();
            }
        }

        public void CatchBall()
        {
            Console.WriteLine("The pitcher caught the ball");
        }

        public void CoverFirstBase()
        {
            Console.WriteLine("The pitcher ran to first base");
        }
    }
}
