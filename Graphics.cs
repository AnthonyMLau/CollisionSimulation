using System.Drawing;
using System.Windows.Forms;

namespace CollisionSimulation
{
    public partial class Graphics : Form
    {
        //public Particle[] particles=null;
        public PaintEventArgs args;

        //private CollisionSystem s;

        public Graphics()
        {

            //Particle[] particles = new Particle[20];
            //for (int i = 0; i < 20; i++)
            //{
            //    particles[i] = new Particle();
            //}
            //s = new CollisionSystem(particles, 500, 500);
            


            InitializeComponent();
            
        }


        public virtual void Graphics_Paint(object sender, PaintEventArgs e)
        {
            this.args = e;
            args.Graphics.FillRectangle(Brushes.Blue, 10, 10, 50, 50);

        }

        public virtual void invalidate()
        {
            this.Invalidate();
        }




        //public void setWindowSize (int windowWidth, int windowHeight)
        //{
        //    this.Width = windowWidth;
        //    this.Height = windowHeight;
        //}
    }
}
