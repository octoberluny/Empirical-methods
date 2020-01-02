using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace home_work
{
    public partial class Histograma : Form
    {
        Result MyResults;
        const int Size = 30;
        object[] array1 = new object[Size];

        public Histograma(object[]arr, Result b)
        {
            InitializeComponent();
            array1 = arr;
            MyResults = b;
            diagr();
            textBox1.Text = Convert.ToString(MyResults.Min);
            textBox2.Text = Convert.ToString(MyResults.Max);
            textBox3.Text = Convert.ToString(MyResults.Interval);
            
        }
        private void func_min()
        {

            double min = (double)array1[0];

            for (int i = 0; i < Size; i++)
            {
                if ((double)array1[i] < min)
                {
                    min = (double)array1[i];
                }
            }
            MyResults.Min = min;

        }
        private void func_max()
        {

            double max = (double)array1[0];

            for (int i = 0; i < Size; i++)
            {
                if ((double)array1[i] > max)
                {
                    max = (double)array1[i];
                }
            }
            MyResults.Max = max;

        }
        private void func_interval()
        {
            double inter = (MyResults.Max - MyResults.Min) / (Math.Sqrt(30) - 1);
            MyResults.Interval = inter;
        }
        private void diagr()
        {
            string readPath = @"D:\Домаха ЕМПІ\h1.txt";
            string readPath1 = @"D:\Домаха ЕМПІ\h2.txt";
            string readPath2 = @"D:\Домаха ЕМПІ\h3.txt";
            string readPath3 = @"D:\Домаха ЕМПІ\h4.txt";
            string readPath4 = @"D:\Домаха ЕМПІ\h5.txt";
            string readPath5 = @"D:\Домаха ЕМПІ\h6.txt";

            StreamReader streamReader = new StreamReader(readPath, Encoding.Default);
            string ur = (streamReader.ReadLine());
            chart1.Series[0].Points.AddXY(ur, MyResults.Ch1);
            StreamReader streamReader1 = new StreamReader(readPath1, Encoding.Default);
            string ur1 = (streamReader1.ReadLine());
            chart1.Series[0].Points.AddXY(ur1, MyResults.Ch2);
            StreamReader streamReader2 = new StreamReader(readPath2, Encoding.Default);
            string ur2 = (streamReader2.ReadLine());
            chart1.Series[0].Points.AddXY(ur2, MyResults.Ch3);
            StreamReader streamReader3 = new StreamReader(readPath3,Encoding.Default);
            string ur3 = (streamReader3.ReadLine());
            chart1.Series[0].Points.AddXY(ur3, MyResults.Ch4);
            StreamReader streamReader4 = new StreamReader(readPath4, Encoding.Default);
            string ur4 = (streamReader4.ReadLine());
            chart1.Series[0].Points.AddXY(ur4, MyResults.Ch5);
            StreamReader streamReader5 = new StreamReader(readPath5, Encoding.Default);
            string ur5 = (streamReader5.ReadLine());
            chart1.Series[0].Points.AddXY(ur5, MyResults.Ch6);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
