using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollisionSimulation
{
    public partial class Graphics : Form
    {

        Particle[] particles;
        int windowHeight = 500;
        int windowWidth = 500;

        public Graphics()
        {
            InitializeComponent();

            particles = new Particle[10];
            for (int i = 0; i < 10; i++)
            {
                particles[i] = new Particle();
            }

        }


        private void Graphics_Paint(object sender, PaintEventArgs e)
        {
            this.Height = windowHeight;
            this.Width = windowWidth;

            drawParticles(e);
        }

        public void drawParticles(PaintEventArgs e)
        {
            for (int i = 0; i < particles.Length; i++)
            {
                double x = (particles[i].centerX * windowWidth) - particles[i].radius;
                double y = (particles[i].centerY * windowHeight) - particles[i].radius;
                int size = (int)particles[i].radius * 2;


                e.Graphics.FillRectangle(Brushes.Red, (int)x, (int)y, size, size);

            }
        }
    }
}
