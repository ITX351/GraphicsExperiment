using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace graphic
{
    public partial class frmDraw : Form
    {
        class Point
        {
            public int X, Y;
            public Point(int x, int y) 
            {
                this.X = x; 
                this.Y = y;
            }

            public Point(Point p)
            {
                this.X = p.X;
                this.Y = p.Y;
            }

            public override string ToString()
            {
                return "(" + X.ToString() + ", " + Y.ToString() + ")";
            }

            public void swapxy()
            {
                int tmp = X; X = Y; Y = tmp;
            }
        }

        class Segment
        {
            public Point a, b;
            public Segment(Point a, Point b)
            {
                this.a = a;
                this.b = b;
            }

            public override string ToString()
            {
                return "[" + a.ToString() + "-" + b.ToString() + "]";
            }

            public void keep()
            {
                if (a.Y > b.Y)
                {
                    Point tmp = a;
                    a = b;
                    b = tmp;
                }
            }
        }

        class Node
        {
            public double x0, dx; 
            public int ymax;
            public Node next;

            public Node(double _x0, double _dx, int _ymax, Node _next)
            {
                x0 = _x0; dx = _dx; ymax = _ymax; next = _next;
            }
        }
        Node[] NET;

        ArrayList points;
        ArrayList segments;
        Graphics g;

        ArrayList lastGraphic;

        private void insert(Node[] table, double x0, double dx, int ymax, int y)
        {
            table[y] = new Node(x0, dx, ymax, table[y]);
        }

        public frmDraw()
        {
            InitializeComponent();
            points = new ArrayList();
            segments = new ArrayList();
            lastGraphic = new ArrayList();
            mouseDown = false;
        }

        private void frmDraw_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
        }

        private void frmDraw_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                points.Add(new Point(e.X, e.Y));
            }
            else
            {
                segments.Clear();
                lastGraphic.Clear();
                if (points.Count == 2)
                {
                    segments.Add(new Segment((Point)points[0], (Point)points[1]));
                    points.Clear();
                }
                else if (points.Count >= 3)
                {
                    for (int i = 1; i < points.Count; i++)
                        segments.Add(new Segment((Point)points[i - 1], (Point)points[i]));
                    segments.Add(new Segment((Point)points[0], (Point)points[points.Count - 1]));
                    points.Clear();
                    drawPolygon(segments);
                }
            }
        }

        private void frmDraw_MouseMove(object sender, MouseEventArgs e)
        {
            lblX.Text = "X: " + e.X.ToString();
            lblY.Text = "Y: " + e.Y.ToString();
        }

        private void drawPoint(int _x, int _y, int[] m = null)
        {
            int x, y;
            if (m == null)
            {
                x = _x; y = _y;
            }
            else
            {
                x = _x * m[0] + _y * m[2]; y = _x * m[1] + _y * m[3];
            }
            lastGraphic.Add(new Point(x, y));

            g.DrawRectangle(new Pen(Brushes.Black, 2), 
                new Rectangle(new System.Drawing.Point(x - 1, y - 1), new Size(1, 1)));
        }

        private void drawSegment(Segment seg)
        {
            Point p1 = new Point(seg.a), p2 = new Point(seg.b);

            if (p1.X == p2.X)
            {
                if (p1.Y > p2.Y)
                {
                    Point tmp = p1;
                    p1 = p2;
                    p2 = tmp;
                }

                for (int y = p1.Y; y <= p2.Y; y++)
                    drawPoint(p1.X, y);
            }
            else if (p1.Y == p2.Y)
            {
                if (p1.X > p2.X)
                {
                    Point tmp = p1;
                    p1 = p2;
                    p2 = tmp;
                }

                for (int x = p1.X; x <= p2.X; x++)
                    drawPoint(x, p1.Y);
            }
            else
            {
                double k = (double)(p2.Y - p1.Y) / (p2.X - p1.X);
                
                int []m = new int[4];

                if (k >= 0 && k <= 1)
                {
                    m[0] = 1; m[1] = 0; m[2] = 0; m[3] = 1;
                }
                else if (k > 1)
                {
                    m[0] = 0; m[1] = 1; m[2] = 1; m[3] = 0;
                    p1.swapxy(); p2.swapxy();
                }
                else if (k < 0 && k >= -1)
                {
                    m[0] = -1; m[1] = 0; m[2] = 0; m[3] = 1;
                    p1.X = -p1.X; p2.X = -p2.X;
                }
                else
                {
                    m[0] = 0; m[1] = 1; m[2] = -1; m[3] = 0;
                    p1.X = -p1.X; p2.X = -p2.X;
                    p1.swapxy(); p2.swapxy();
                }

                if (p1.X > p2.X)
                {
                    Point tmp = p1;
                    p1 = p2;
                    p2 = tmp;
                }

                int a = p1.Y - p2.Y, b = p2.X - p1.X, d = a + a + b, 
                    deta1 = a + a, deta2 = 2 * (a + b);
                int y = p1.Y;

                for (int x = p1.X; x <= p2.X; x++)
                {
                    drawPoint(x, y, m);
                    if (d < 0)
                    {
                        y++; d += deta2;
                    }
                    else
                        d += deta1;
                }
            }
        }

        private void drawPolygon(ArrayList segments)
        {
            foreach (Segment seg in segments)
                drawSegment(seg);

            System.Threading.Thread.Sleep(500);

            int h = this.Size.Height;
            NET = new Node[h];
            foreach (Segment seg in segments)
            {
                seg.keep();
                insert(NET, seg.a.X, ((double)(seg.b.X - seg.a.X)) 
                    / (seg.b.Y - seg.a.Y), seg.b.Y, seg.a.Y);
            }

            Node AET = null;
            for (int y = 0; y < h; y++)
            {
                Node last = null;
                for (Node now = AET; now != null; now = now.next)
                {
                    if (y >= now.ymax)
                    {
                        if (last == null)
                            AET = now.next;
                        else
                            last.next = now.next;
                    }
                    else
                    {
                        last = now;
                        now.x0 += now.dx;
                    }
                }

                for (Node p = NET[y]; p != null; p = p.next)
                {
                    last = null;
                    Node now;

                    for (now = AET; now != null; now = now.next)
                    {
                        if (now.x0 > p.x0 || (now.x0 == p.x0 && now.dx > p.dx))
                            break;
                        last = now;
                    }
                    Node newNode = new Node(p.x0, p.dx, p.ymax, now);
                    if (last != null)
                        last.next = newNode;
                    else
                        AET = newNode;
                }

                for (Node now = AET; now != null; now = now.next.next)
                {
                    if (now.next == null)
                    {
                        MessageBox.Show("ERROR");
                        return;
                    }

                    for (int x = (int)now.x0; x < now.next.x0; x++)
                        drawPoint(x, y);
                }
            }
        }

        private void OperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int dingx = ((Point)lastGraphic[0]).X, dingy = ((Point)lastGraphic[0]).Y;
            frmOperation op = new frmOperation(this.Size.Width, this.Size.Height, dingx, dingy);
            op.ShowDialog();

            if (op.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Matrix origin = new Matrix(lastGraphic.Count, 3);
                for (int i = 0; i < lastGraphic.Count; i++)
                {
                    origin.M[i][0] = ((Point)lastGraphic[i]).X;
                    origin.M[i][1] = ((Point)lastGraphic[i]).Y;
                    origin.M[i][2] = 1;
                }

                Matrix after = origin.Multiply(op.matrix);
                lastGraphic.Clear();
                for (int i = 0; i < after.x; i++)
                {
                    drawPoint((int)after.M[i][0], (int)after.M[i][1]);
                }
            }
        }

        private bool mouseDown;
        private void frmDraw_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;

            
        }

        private void frmDraw_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
