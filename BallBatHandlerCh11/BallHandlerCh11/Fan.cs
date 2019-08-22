using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallHandlerCh11
{
    class Fan
    {
        public Fan(Ball ball)
        {
            ball.BallInPlay += new EventHandler(Ball_BallInPlay);
        }

        private void Ball_BallInPlay(object sender, EventArgs e)
        {
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if ((ballEventArgs.Distance > 400) && ballEventArgs.Trajectory > 30)
                    GrabGlove();
                else
                    Yell();
            }
        }

        public void GrabGlove()
        {
            Console.WriteLine("The fan yells 'i'm going for the ball!' and runs to grab a glove");
        }

        public void Yell()
        {
            Console.WriteLine("The fan yells 'Woo-hoo! Yeah!', but is secretly disappointed that the ball is not within reach");
        }
    }
}
