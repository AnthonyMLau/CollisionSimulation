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

        int x = 0;
        int y = 0;
        Rectangle r;


        public Graphics()
        {
            InitializeComponent();

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 1;
            y += 1;
            Invalidate();
        }

        private void Graphics_Paint(object sender, PaintEventArgs e)
        {
            r = new Rectangle(x, y, 20, 20);
            e.Graphics.FillRectangle(Brushes.Red, r);

            timer1.Interval = 100;
        }
    }
}
