using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionSimulation
{
    public class Particle
    {
        public int centerX { get; private set; }
        public int centerY { get; private set; }
        public double velX { get; private set; }
        public double velY { get; private set; }
        public int radius { get; private set; }
        public double mass { get; private set; }
        public int count { get; private set; }

        public int windowWidth;
        public int windowHeight;

        static Random rand = new Random();



        public Particle(int windowHeight, int windowWidth)
        {
            this.radius = 7;
            this.mass = 5;
            this.count = 0;

            this.windowHeight = windowHeight;
            this.windowWidth = windowWidth;

            this.centerX = rand.Next((int) radius+5, windowWidth-(int) radius-5);
            this.centerY = rand.Next((int)radius + 5, windowWidth - (int)radius - 5);
            this.velX = rand.Next(5,10);   
            this.velY = rand.Next(5,10);

        }

        public Particle(int centerX, int centerY, double velX, double velY, int radius, double mass)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.velX = velX;
            this.velY = velY;
            this.radius = radius;
            this.mass = mass;
            this.count = 0;
        }

        public void move(double dt)
        {
            centerX += (int)(velX * dt);
            centerY += (int)(velY * dt);
        }

        public int getCount()
        {
            return count;
        }


        //returns time for particle to hit specified particle assuming particles do not collide with anything else before
        public double timeToHit (Particle that) 
        {
            if(this == that)
            {
                return double.PositiveInfinity;
            }

            double dx = that.centerX - this.centerX;
            double dy = that.centerY - this.centerY;
            double dvx = that.velX - this.velX;
            double dvy = that.velY - this.velY;

            double dvdr = dx * dvx + dy * dvy;

            if (dvdr > 0) return double.PositiveInfinity;

            double dvdv = dvx * dvx + dvy * dvy;
            double drdr = dx * dx + dy * dy;
            double sigma = this.radius + that.radius;
            double d = (dvdr * dvdr) - dvdv * (drdr - sigma * sigma);

            // if (drdr < sigma*sigma) StdOut.println("overlapping particles");
            if (d < 0) return double.PositiveInfinity;

            return -(dvdr + Math.Sqrt(d)) / dvdv;

        }


        //returns time for particle to hit vertical wall assuming no intervening collisions
        public double timeToHitVertWall()
        {
            if (centerX > 0) return (windowWidth-centerX-radius) / velX;
            else if (centerX < 0) return (radius - centerX) / velX;
            else return double.PositiveInfinity;
        }

        //returns time for particle to hit horizontal wall assuming no intervening collisions
        public double timeToHitHorizontalWall()
        {
            if (centerY > 0) return (windowWidth - centerX - radius) / velY;
            else if (centerY < 0) return (radius - centerY) / velY;
            else return double.PositiveInfinity;
        }

        //updates particle velocities of colliding particles using elastic collisions, instant collisions, no impulse/compression of particles
        public void bounceOff(Particle that)
        {
            double dx = that.centerX - this.centerX;
            double dy = that.centerY - this.centerY;
            double dvx = that.velX - this.velX;
            double dvy = that.velY - this.velY;
            double dvdr = dx * dvx + dy * dvy;             // dv dot dr
            double dist = this.radius + that.radius;   // distance between particle centers at collison

            //magnitude of normal force
            double magnitude = 2 * this.mass * that.mass * dvdr / ((this.mass + that.mass) * dist);

            // normal force, and in x and y directions
            double fx = magnitude * dx / dist;
            double fy = magnitude * dy / dist;

            // update velocities according to normal force
            this.velX += fx / this.mass;
            this.velY += fy / this.mass;
            that.velX -= fx / that.mass;
            that.velY -= fy / that.mass;

            // update collision counts
            this.count++;
            that.count++;
        }

        //updates velocity of particle upon collision with horizontal wall; reflects y velocity
        public void bounceOffHorizontalWall()
        {
            velY = -velY;
            count++;
        }

        //updates velocity of particle upon collision with vertical wall; reflects x velocity
        public void bounceOffVertWall()
        {
            velX = -velX;
            count++;
        }

        //returns kinetic energy of particle 
        public double kineticEnergy()
        {
            return 0.5 * mass * (velX * velX + velY * velY);
        }

        public override string ToString()
        {
            return ("cXY:" + centerX + ", " + centerY + "\t vXY: " + velX + ", " + velY + "\t Radius: "+ radius + "\t Mass: "+ mass);
        }


    }
}
