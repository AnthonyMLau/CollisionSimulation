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
     *    -  a null, b not null:     collision with vertical wall
     *    -  a not null, b null:     collision with horizontal wall
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
        }

        public Event(double time)
        {
            this.time = time;
            this.a = new Particle();
            this.b = new Particle();
        }



    }
}
