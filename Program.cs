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

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Graphics());


            Particle a = new Particle(1, 0, 10, 0, 1, 1);
            Particle b = new Particle(20, 0, 5, 0, 1, 1);
            Particle c = new Particle(40, 0, -10, 0, 1, 1);

            Console.WriteLine(a.timeToHitVertWall());
            Console.WriteLine(b.timeToHitVertWall());
            Console.WriteLine(c.timeToHitVertWall());




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
