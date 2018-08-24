using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionSimulation
{
    class Event
    {
        private Particle a;    //change to custom object
        private Particle b;
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
