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

            public Point getXGreater()
            {
                if (a.X > b.X)
                    return a;
                return b;
            }

            public Point getXLess()
            {
                if (a.X < b.X)
                    return a;
                return b;
            }

            public Point getYGreater()
            {
                if (a.Y > b.Y)
                    return a;
                return b;
            }

            public Point getYLess()
            {
                if (a.Y < b.Y)
                    return a;
                return b;
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
                    drawSegment((Segment)segments[0], Brushes.Black);
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

            if (mouseDown)
            {
                _drawPoint(x1, y1, Brushes.Red);
            }
        }

        private void _drawPoint(int x, int y, Brush color)
        {
            g.DrawRectangle(new Pen(color, 2),
                new Rectangle(new System.Drawing.Point(x - 1, y - 1), new Size(1, 1)));
        }

        private void drawPoint(int _x, int _y, Brush color, int[] m = null)
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
            _drawPoint(x, y, color);
        }

        private void drawSegment(Segment seg, Brush color)
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
                    drawPoint(p1.X, y, color);
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
                    drawPoint(x, p1.Y, color);
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
                    drawPoint(x, y, color, m);
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
                drawSegment(seg, Brushes.Black);

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
                        drawPoint(x, y, Brushes.Black);
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
                    drawPoint((int)after.M[i][0], (int)after.M[i][1], Brushes.Black);
            }
        }

        private bool mouseDown;
        private int x1, y1, x2, y2;
        private void frmDraw_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            x1 = e.X; y1 = e.Y;
        }

        private void frmDraw_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            x2 = e.X; y2 = e.Y;

            if (x1 == x2 && y1 == y2)
                return;

            _drawPoint(x2, y2, Brushes.Red);

            if (x1 > x2)
            {
                int tmp = x2;
                x2 = x1;
                x1 = tmp;
            }
            if (y1 > y2)
            {
                int tmp = y2;
                y2 = y1;
                y1 = tmp;
            }

            g.DrawRectangle(new Pen(Brushes.Purple, 2),
                new Rectangle(new System.Drawing.Point(x1, y1), new Size(x2 - x1, y2 - y1)));

            if (segments.Count == 0)
                return;

            Segment seg = (Segment)segments[0];
            Point p1 = seg.a, p2 = seg.b;
            int c1 = getCode(p1), c2 = getCode(p2);

            if (c1 == 0 && c2 == 0) // 都在窗口内
            {
                drawSegment(seg, Brushes.Blue);
                return;
            }
            if ((c1 & c2) > 0)
            {
                return;
            }

            Point cx1 = calculateCross(seg, x1, -1),
                cx2 = calculateCross(seg, x2, -1),
                cy1 = calculateCross(seg, -1, y1),
                cy2 = calculateCross(seg, -1, y2);
            Segment nseg;

            if (cx1 == null && cx2 == null && cy1 == null && cy2 == null)
                return;
            else if (cx1 != null && cx2 == null && cy1 == null && cy2 == null)
                nseg = new Segment(cx1, seg.getXGreater());
            else if (cx1 == null && cx2 != null && cy1 == null && cy2 == null)
                nseg = new Segment(cx2, seg.getXLess());
            else if (cx1 == null && cx2 == null && cy1 != null && cy2 == null)
                nseg = new Segment(cy1, seg.getYGreater());
            else if (cx1 == null && cx2 == null && cy1 == null && cy2 != null)
                nseg = new Segment(cy2, seg.getYLess());
            else
            {
                Point np1 = null, np2 = null;
                if (cx1 != null)
                {
                    np1 = cx1;
                }
                if (cx2 != null)
                {
                    if (np1 == null)
                        np1 = cx2;
                    else
                        np2 = cx2;
                }
                if (cy1 != null)
                {
                    if (np1 == null)
                        np1 = cy1;
                    else
                        np2 = cy1;
                }
                if (cy2 != null)
                {
                    if (np1 == null)
                        np1 = cy2;
                    else
                        np2 = cy2;
                }
                nseg = new Segment(np1, np2);
            }
            drawSegment(nseg, Brushes.Blue);
        }

        private int getCode(Point point)
        {
            int ret = 0;
            if (point.X < x1)
                ret |= 1;
            if (point.X > x2)
                ret |= 2;
            if (point.Y > y2)
                ret |= 4;
            if (point.Y < y1)
                ret |= 8;
            return ret;
        }

        private Point calculateCross(Segment seg, int X, int Y)
        {
            Point ret = null;

            Point p1 = seg.a, p2 = seg.b;
            int a = p1.X, b = p1.Y, c = p2.X, d = p2.Y;

            int nx = -1, ny = -1;

            if (X >= 0)
            {
                nx = X;
                ny = (int)(1.0 * (X - a) * (d - b) / (c - a) + b + .5);
            }
            else if (Y >= 0)
            {
                nx = (int)(1.0 * (Y - b) * (c - a) / (d - b) + a + .5);
                ny = Y;
            }

            if (a > c)
            {
                int tmp = a;
                a = c;
                c = tmp;
            }

            if (b > d)
            {
                int tmp = b;
                b = d;
                d = tmp;
            }

            if (nx >= a && nx <= c && ny >= b && ny <= d && 
                nx >= x1 - 1 && nx <= x2 + 1 && ny >= y1 - 1 && ny <= y2 + 1)
                ret = new Point(nx, ny);
            return ret;
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(this.BackColor);

            points.Clear();
            segments.Clear();
            lastGraphic.Clear();
            mouseDown = false;
        }
    }
}
