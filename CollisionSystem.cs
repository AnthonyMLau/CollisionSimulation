using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollisionSimulation
{
    class CollisionSystem
    {
        private readonly static double hz = 0.5;
        public double currentTime { get; private set; }
        public PriorityQueue pq { get; private set; }
        public Particle [] particles { get; private set; }


        public CollisionSystem (Particle[] particles)
        {
            this.particles = (Particle []) particles.Clone(); //shallow copy, new array references the parameter, does not create an extra copy
        }



        public void predict(Particle a, double timeLimit)
        {
            if (a == null) return;

            //particle particle collision
            for (int i = 0; i < particles.Length; i++)
            {
                double dt = a.timeToHit(particles[i]);
                if(currentTime + dt <= timeLimit)
                {
                    pq.insertEvent(new Event(currentTime + dt, a, particles[i]));

                }
            }

            //particle wall collisions
            double dtX = a.timeToHitVertWall();
            double dtY = a.timeToHitHorizontalWall();

            if(currentTime + dtX <= timeLimit)
            {
                pq.insertEvent(new Event(currentTime + dtX, a, null));  //vert wall
            }
            if(currentTime + dtY <= timeLimit)
            {
                pq.insertEvent(new Event(currentTime + dtY, null, a));  //horizontal wall
            }
        }




        //simulates the particles for a given amount of time
        public void simulate(double timeLimit, PaintEventArgs e)
        {
            pq = new PriorityQueue();
            for (int i = 0; i < particles.Length; i++)
            {
                predict(particles[i], timeLimit);
            }

            //main simulation loop
            while (pq.getNumItems() != 0)
            {
                Event impendingEvent = pq.delMin();   //get impending event, discard if invalidated
                if (!impendingEvent.isValid())
                {
                    continue;
                }

                Particle a = impendingEvent.getParticleA();
                Particle b = impendingEvent.getParticleB();

                for (int i = 0; i < particles.Length; i++)   // physical collision, so update positions and simulation clock
                {
                    particles[i].move(impendingEvent.time - currentTime);
                }
                currentTime = impendingEvent.time;

                //process events
                if (a != null && b != null) a.bounceOff(b);
                else if (a != null && b == null) a.bounceOffVertWall();
                else if (a == null && b != null) b.bounceOffHorizontalWall();
                //no null, null ??

                

                // update the priority queue with new collisions involving a or b
                predict(a, timeLimit);
                predict(b, timeLimit);
            }
        }




        /***************************************************************************

        *    -  a and b both null:      redraw event
        *    -  a not null, b null:     collision with vertical wall
        *    -  a null, b not null:     collision with horizontal wall
        *    -  a and b both not null:  binary collision between a and b
        *
        ***************************************************************************/


    }
}
