using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollisionSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        public static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int num = 100;
            int x = 1200;
            int y = 900;

            Particle[] particles = new Particle[num];
            for (int i = 0; i < num; i++)
            {
                particles[i] = new Particle(x,y);
                Console.WriteLine(particles[i]);
            }
            Console.WriteLine("=======================================================================");
            CollisionSystem c = new CollisionSystem(particles, x, y);

            //Particle a = new Particle(20, 20, 1, 1, 10, 5);
            //Particle b = new Particle(22, 22, -1, -1, 10, 5);
            //Console.WriteLine(a.timeToHit(b)+"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");


            Application.Run(c);















            //PriorityQueue pq = null;
            //Random rand = new Random();


            //Event[] initial = new Event[10];
            //for (int i = 9; i >= 0; i--)
            //{
            //    initial[9-i] = new Event((double)i);

            //}

            //pq = new PriorityQueue(initial);



            ////Event [] temp = pq.getPQCopy();

            ////for (int i = 0; i <= pq.getNumItems(); i++)
            ////{
            ////    Console.Write("inital:" + temp[i].time + ",\t");    //*******
            ////}

            //Console.WriteLine("");

            //pq.insertEvent(new Event(20.6));

            //int a = pq.getNumItems();
            //for (int i = 1; i <= a; i++)
            //{
            //    double d = pq.delMin().time;
            //    Console.Write("Min: " + d + ",\t");
            //}
            //Console.WriteLine("----------------------------");
        }
    }
}
