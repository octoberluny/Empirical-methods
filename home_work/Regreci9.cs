using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace home_work
{
    public partial class Regreci9 : Form
    {
        public Result MyResults = new Result();
        const int Size = 30;
        object[] array1 = new object[Size];
        object[] array2 = new object[Size];
        public Regreci9(object[]a,object[]b,Result R)
        {
            InitializeComponent();
            array1 = a;
            array2 = b;
            MyResults = R;
            diagr_kor();
        }
        private void diagr_kor()
        {
            double[] x = new double[30];
            for (int c = 0; c < Size; c++)
            {
                x[c] = Convert.ToDouble(array2[c]);

            }
            Sort(x);


            for (int i = 0; i < Size; i++)

            {
                double ls = Convert.ToDouble(array1[i]);
                chart2.Series[0].Points.AddXY(ls, i);
            }
            for (int i = 0; i < Size; i++)

            {
                double lsw = x[i];
                chart2.Series[1].Points.AddXY(lsw, i);
            }






        }
        private void chart2_Click(object sender, EventArgs e)
        {

        }
        void Sort(double[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A.Length - i - 1; j++)
                {
                    if (A[j] > A[j + 1])
                    {
                        double temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                    }
                }
            }
        }
    }
}
