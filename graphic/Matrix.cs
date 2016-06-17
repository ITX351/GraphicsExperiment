using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphic
{
    public class Matrix
    {
        public int x, y;
        public Matrix(int x = 3, int y = 3)
        {
            this.x = x; this.y = y;
            M = new double[x][];
            for (int i = 0; i < x; i++)
                M[i] = new double[y];
        }

        public double[][] M;

        public void set3x3(double v0, double v1, double v2, double v3, double v4, 
            double v5, double v6, double v7, double v8)
        {
            M[0][0] = v0;
            M[0][1] = v1;
            M[0][2] = v2;
            M[1][0] = v3;
            M[1][1] = v4;
            M[1][2] = v5;
            M[2][0] = v6;
            M[2][1] = v7;
            M[2][2] = v8;
        }

        public Matrix Multiply(Matrix b)
        {
            if (y != b.x)
            {
                throw new Exception("Matrix multiply exception");
            }

            Matrix ret = new Matrix(x, b.y);

            for (int i = 0; i < x; i++ )
            {
                for (int j = 0; j < b.y; j++)
                {
                    ret.M[i][j] = 0;
                    for (int k = 0; k < y; k++)
                        ret.M[i][j] += M[i][k] * b.M[k][j];
                }
            }
            return ret;
        }
    }
}
