using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionSimulation
{
    class Event
    {

        /***************************************************************************

        *    -  a and b both null:      redraw event
        *    -  a not null, b null:     collision with vertical wall
        *    -  a null, b not null:     collision with horizontal wall
        *    -  a and b both not null:  binary collision between a and b
        *
        ***************************************************************************/

        private Particle a, b;
        private int countA, countB;
        public double time { get; private set; }

        

        public Event(double time, Particle a, Particle b)
        {
            this.a = a;
            this.b = b;
            this.time = time;

            if (a != null) countA = a.getCount();
            else countA = -1;

            if (b != null) countA = b.getCount();
            else countB = -1;


        }

        public Event(double time)
        {
            this.time = time;
            this.a = new Particle();
            this.b = new Particle();
        }

        public Boolean isValid()
        {
            if (a != null && a.getCount() != countA) return false;
            if (b != null && b.getCount() != countB) return false;
            return false; //lesson put as true??
        }

        public Particle getParticleA()
        {
            return a;
        }

        public Particle getParticleB()
        {
            return b;
        }
    }
}
