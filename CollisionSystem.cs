using System.Drawing;
using System.Windows.Forms;

namespace CollisionSimulation
{
    public class CollisionSystem: Graphics
    {
        private readonly static double hz = 0.5;
        public double currentTime { get; private set; }
        public PriorityQueue pq { get; private set; }
        public Particle[] particles;// { get; private set; }

        //Graphics g = new Graphics();
        private int windowWidth, windowHeight;

        private Pen p = new Pen(Color.Red, 2);

        public CollisionSystem (Particle[] particles, int windowWidth, int windowHeight)
        {
            this.particles = (Particle []) particles.Clone(); //shallow copy, new array references the parameter, does not create an extra copy
            this.windowHeight = windowHeight;
            this.windowWidth = windowWidth;
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

            if (currentTime + dtX <= timeLimit)
            {
                pq.insertEvent(new Event(currentTime + dtX, a, null));  //vert wall
            }
            if(currentTime + dtY <= timeLimit)
            {
                pq.insertEvent(new Event(currentTime + dtY, null, a));  //horizontal wall
            }
        }




        //simulates the particles for a given amount of time
        public void simulate(double timeLimit)
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
                if (!impendingEvent.isValid(currentTime))
                {
                    continue;
                }

                System.Console.WriteLine(impendingEvent.getParticleA());
                System.Console.WriteLine(impendingEvent.getParticleB());

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
                //no null, null 



                args.Graphics.Clear(Color.Transparent);
                drawParticles(particles);



                // update the priority queue with new collisions involving a or b
                predict(a, timeLimit);
                predict(b, timeLimit);


                
            }   
        }

        public override void Graphics_Paint(object sender, PaintEventArgs e)
        {
            this.args = e;
            //this.Height = windowHeight;
            //this.Width = windowWidth;
            this.Height = 1000;
            this.Width = 1000;

            e.Graphics.DrawRectangle(p, 0, 0, 500, 500);

            simulate(10000);
        }

        public void drawParticles(Particle[] particles)
        {
            Invalidate();
            for (int i = 0; i < particles.Length; i++)
            {
                int x = particles[i].centerX - particles[i].radius;
                int y = particles[i].centerY - particles[i].radius;
                int size = (int)particles[i].radius * 2;

                args.Graphics.DrawEllipse(p, x, y, size, size);

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
