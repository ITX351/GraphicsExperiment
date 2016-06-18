using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphic
{
    public partial class frmFlash : Form
    {
        public frmFlash()
        {
            InitializeComponent();

            R = 50;
            dx = 3;
            dy = 3;
        }

        int cx, cy, R, dx, dy, ax, ay;
        Graphics g;

        private void frmFlash_Load(object sender, EventArgs e)
        {
            cx = this.Size.Width / 2;
            cy = this.Size.Height / 2;
            ax = this.Size.Width - 20;
            ay = this.Size.Height - 43;
            g = this.CreateGraphics();
            g.DrawRectangle(new Pen(Brushes.Black, 2),
                new Rectangle(new System.Drawing.Point(0, 0), new Size(ax, ay)));
        }

        private void tmrAuto_Tick(object sender, EventArgs e)
        {
            if (cx - R < 0 || cx + R > ax)
                dx = -dx;
            if (cy - R < 0 || cy + R > ay)
                dy = -dy;

            cx += dx; cy += dy;

            g.Clear(this.BackColor);
            g.DrawEllipse(new Pen(Brushes.Blue, 2), cx - R, cy - R, 2 * R, 2 * R);
            g.DrawRectangle(new Pen(Brushes.Red, 2),
                new Rectangle(new System.Drawing.Point(cx, cy), new Size(1, 1)));
        }
    }
}
