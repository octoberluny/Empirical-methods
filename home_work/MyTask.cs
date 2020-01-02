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
    
    public partial class MyTask : Form
    {
        public Result MyResults = new Result();
        const int Size = 30;
        object[] array1 = new object[Size];
        object[] array2 = new object[Size];
        


        public MyTask()
        {
            InitializeComponent(); 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                int i = 0;             
                while (!streamReader.EndOfStream)
                {
                    array1[i] = Convert.ToDouble(streamReader.ReadLine());
                    
                    i++;
                }
                

            }
            
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
        private void func_mat_spod()
        {

            double sum = 0;
            for (int i = 0; i < Size; i++)
            {
                sum+=(double)array1[i];
            }
            double mat_s = sum / Size;
            MyResults.Mat_s = mat_s;
        }
        private void dispersiya()
        {
            double  sum1 = 0;
            for (int i = 0; i < Size; i++)
            {
                
                sum1 += Math.Pow(((double)array1[i]- MyResults.Mat_s), 2.0);
            }
            double dus = sum1/ Size-1;
            MyResults.Dispersi9 = dus;
                
        }
        private void kv_vidhul()
        {
            double ser_k = Math.Sqrt(MyResults.Dispersi9);
            MyResults.Ser_Kv_Vidh = ser_k;

        }
        private void exces()
        {
            double kof_e =0;
            double sum2 = 0;
            int k = 1;
            for (int i = 0; i < Size; i++)
            {
               
                sum2 += (Math.Pow(((double)array1[i] - MyResults.Mat_s), 4.0));
                k = k + 1;
            }
            kof_e =sum2 / (Size * (double)Math.Pow(MyResults.Ser_Kv_Vidh,4.0));
            MyResults.Koef_e = kof_e;


        }
        private void asimetr()
        {
            double kof_a = 0;
            double sum3 = 0;
            
            for (int i = 0; i < Size; i++)
            {
                
                sum3 += (Math.Pow(((double)array1[i] - MyResults.Mat_s), 3.0));
                
            }
            kof_a = sum3 / (Size * (double)Math.Pow(MyResults.Ser_Kv_Vidh, 3.0));
            MyResults.Koef_a = kof_a;

        }
        private void Chastot1()
        {
            
            double val = MyResults.Min + MyResults.Interval;
            int j = 0;
            for (int i = 0; i < Size; i++)
            {
                if (((double)array1[i] >= MyResults.Min) && ((double)array1[i] < val))
                {
                    j++;
                }

            }
            MyResults.Ch1 = j;
            MyResults.Vu1 = val;

            double val1 =val+ MyResults.Interval;
            int r = 0;
            for (int i = 0; i < Size; i++)
            {
                if (((double)array1[i] >= val) && ((double)array1[i] < val1))
                {
                    r++;
                }

            }
            MyResults.Ch2 = r;
            MyResults.Vu2 = val1;
            double val2 = val1 + MyResults.Interval;
            int q = 0;
            for (int i = 0; i < Size; i++)
            {
                if (((double)array1[i] >= val1) && ((double)array1[i] < val2))
                {
                    q++;
                }

            }
            MyResults.Ch3 = q;
            MyResults.Vu3 = val2;
            double val3 = val2 + MyResults.Interval;
            int t = 0;
            for (int i = 0; i < Size; i++)
            {
                if (((double)array1[i] >= val2) && ((double)array1[i] < val3))
                {
                    t++;
                }

            }
            MyResults.Ch4 = t;
            MyResults.Vu4 = val3;
            double val4 = val3 + MyResults.Interval;
            int tt = 0;
            for (int i = 0; i < Size; i++)
            {
                if (((double)array1[i] >= val2) && ((double)array1[i] < val3))
                {
                    tt++;
                }

            }
            MyResults.Ch5 = tt;
            MyResults.Vu5 = val4;
            double val5 = val4 + MyResults.Interval;
            int ttt = 0;
            for (int i = 0; i < Size; i++)
            {
                if (((double)array1[i] >= val2) && ((double)array1[i] < val3))
                {
                    ttt++;
                }

            }
            MyResults.Ch6 = ttt;
            MyResults.Vu6 = val5;




        }

        private void save()
        {
           
            string writePath = @"D:\Домаха ЕМПІ\h1.txt";
            string writePath1 = @"D:\Домаха ЕМПІ\h2.txt";
            string writePath2 = @"D:\Домаха ЕМПІ\h3.txt";
            string writePath3 = @"D:\Домаха ЕМПІ\h4.txt";
            string writePath4 = @"D:\Домаха ЕМПІ\h5.txt";
            string writePath5 = @"D:\Домаха ЕМПІ\h6.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Default))
                {
                    sw.WriteLine(MyResults.Min + "-" + MyResults.Vu1);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath1, false, Encoding.Default))
                {
                    sw.WriteLine(MyResults.Vu1 + "-" + MyResults.Vu2);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath2, false, Encoding.Default))
                {
                    sw.WriteLine(MyResults.Vu2 + "-" + MyResults.Vu3);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath3, false, Encoding.Default))
                {
                    sw.WriteLine(MyResults.Vu3 + "-" + MyResults.Vu4);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath4, false, Encoding.Default))
                {
                    sw.WriteLine(MyResults.Vu4 + "-" + MyResults.Vu5);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath5, false, Encoding.Default))
                {
                    sw.WriteLine(MyResults.Vu5 + "-" + MyResults.Vu6);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                int i = 0;
                while (!streamReader.EndOfStream)
                {
                    array2[i] = Convert.ToDouble(streamReader.ReadLine());
                    i++;
                }

            }
        }
    
        private void korel()
        {
            double SumD=0;
            int R1;
            int R2;
            for (int i =0;i<Size;i++)
            {
                R1 = Rang(i, array1);
                R2 = Rang(i, array2);
                SumD +=Math.Pow(Math.Abs(R1 - R2), 2);

            }
            MyResults.Koef_Sp =1-(6*SumD) / 26970;

        }


    
      
        private int Rang(int i, object[] mas)
        {
            int Rang = 0;
            for (int k = i; k < mas.Length; k++)
            {
                if ((double)mas[i] < (double)mas[k])
                {
                    Rang += 1;
                }
                   
            }
            return Rang;
        }

 

        private void button2_Click_1(object sender, EventArgs e)
        {
            func_min();
            func_max();
            func_interval();
            func_mat_spod();
            dispersiya();
            kv_vidhul();
            exces();
            Chastot1();
            save();
            korel();
            asimetr();
            

            
            textBox4.Text = Convert.ToString(MyResults.Mat_s);
            textBox5.Text = Convert.ToString(MyResults.Dispersi9);
            textBox6.Text = Convert.ToString(MyResults.Ser_Kv_Vidh);
            textBox7.Text = Convert.ToString(MyResults.Koef_e);
            textBox8.Text = Convert.ToString(MyResults.Koef_Sp);
            textBox9.Text = Convert.ToString(MyResults.Koef_a);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Histograma Hist = new Histograma(array1, MyResults);
            Hist.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Regreci9 Reg = new Regreci9(array1, array2, MyResults);
            Reg.ShowDialog();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }


}
