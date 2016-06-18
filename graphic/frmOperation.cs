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
    public partial class frmOperation : Form
    {
        int allx, ally, dingx, dingy;
        public frmOperation(int width, int height, int dingx, int dingy)
        {
            InitializeComponent();
            allx = width; ally = height;
            this.dingx = dingx; this.dingy = dingy;
        }

        public Matrix matrix;

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Matrix m1 = new Matrix(), m2 = new Matrix(), m3 = new Matrix();

            if (rdbX.Checked)
            {
                m1.set3x3(1, 0, 0, 0, 1, 0, 0, -ally / 2, 1);
                m2.set3x3(1, 0, 0, 0, -1, 0, 0, 0, 1);
                m3.set3x3(1, 0, 0, 0, 1, 0, 0, ally / 2, 1);
                matrix = m1.Multiply(m2).Multiply(m3);
            }
            else if (rdbY.Checked)
            {
                m1.set3x3(1, 0, 0, 0, 1, 0, -allx / 2, 0, 1);
                m2.set3x3(-1, 0, 0, 0, 1, 0, 0, 0, 1);
                m3.set3x3(1, 0, 0, 0, 1, 0, allx / 2, 0, 1);
                matrix = m1.Multiply(m2).Multiply(m3);
            }
            else if (rdbO.Checked)
            {
                m1.set3x3(1, 0, 0, 0, 1, 0, -allx / 2, -ally / 2, 1);
                m2.set3x3(-1, 0, 0, 0, -1, 0, 0, 0, 1);
                m3.set3x3(1, 0, 0, 0, 1, 0, allx / 2, ally / 2, 1);
                matrix = m1.Multiply(m2).Multiply(m3);
            }
            else if (rdbMove.Checked)
            {
                int mx = int.Parse(txtMoveX.Text), my = int.Parse(txtMoveY.Text);
                matrix = new Matrix();
                matrix.set3x3(1, 0, 0, 0, 1, 0, mx, my, 1);
            }
            else if (rdbRotate.Checked)
            {
                double radio = double.Parse(txtRotate.Text) * Math.PI / 180.0;
                double sinx = Math.Sin(radio), cosx = Math.Cos(radio);
                m1.set3x3(1, 0, 0, 0, 1, 0, -dingx, -dingy, 1);
                m2.set3x3(cosx, sinx, 0, -sinx, cosx, 0, 0, 0, 1);
                m3.set3x3(1, 0, 0, 0, 1, 0, dingx, dingy, 1);
                matrix = m1.Multiply(m2).Multiply(m3);
            }
            else if (rdbRatio.Checked)
            {
                double rx = double.Parse(txtRatioX.Text), ry = double.Parse(txtRatioY.Text);
                m1.set3x3(1, 0, 0, 0, 1, 0, -dingx, -dingy, 1);
                m2.set3x3(rx, 0, 0, 0, ry, 0, 0, 0, 1);
                m3.set3x3(1, 0, 0, 0, 1, 0, dingx, dingy, 1);
                matrix = m1.Multiply(m2).Multiply(m3);
            }
            return;
        }
    }
}
