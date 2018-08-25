using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.particles = (Particle []) particles.Clone(); //shallow copy, new array references the parameter !!!
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
                pq.insertEvent(new Event(currentTime + dtX, a, null));
            }
            if(currentTime + dtY <= timeLimit)
            {
                pq.insertEvent(new Event(currentTime + dtY, null, a));
            }
        }

    }
}
