using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;


namespace LAB4.alt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            int n = int.Parse(textBox1.Text);
            
            int chs;
            int k = 0;
            Random rnd = new Random();
            int[,] A = new int[n, n];
                  //Console.WriteLine("1.Ввід графа вручну.\n2.Створити граф випадковим чином.\nВибір:");
               
                        for (int i = 0; i < n-1; ++i)
                        {
                            while (k==0)
                            for (int j = i+1; j < n; ++j)
                            {
                                if (k == 3) break;
                                A[i, j] = rnd.Next(0, 2);
                                 if (A[i, j] == 1)
                                    {
                                    ++k;
                                    }
                             
                            }
                            k = 0;
                        }
                    
            kola(n,A);
            string Q="";
             for(int i=0;i<n;++i)
            {
                for(int j=0;j<n;++j)
                {
                    Q += A[i, j].ToString() + '\t';
                }
                Q += '\n';
            }

            Q += '\n';
            Q += '\n';

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    Q += recursia(i, j, A).ToString() + '\t';
                }
                Q += '\n';
            }
            richTextBox1.Text = Q;
        }

        private void kola(int n,int [,]A)
        {

            System.Drawing.Graphics formGraphics = this.CreateGraphics();

            System.Drawing.Graphics formGraphics1 = this.CreateGraphics();
            formGraphics.Clear(System.Drawing.Color.White);
            System.Drawing.Pen myPen;
            System.Drawing.Pen myPen1;
            myPen = new System.Drawing.Pen(System.Drawing.Color.Black);
            myPen1 = new System.Drawing.Pen(System.Drawing.Color.Red);
            int[] a = new int[2];
            a[0] = 20;
            a[1] = 100;
            int[] b = new int[2];
            b[0] = 70;
            b[1] = 50;
            int[] c = new int[2];
            c[0] = 70;
            c[1] = 150;
            int []L = new int[2 * n];
            int k = 0;
            System.Drawing.Font drawFont = new System.Drawing.Font(
        "Arial", 16);
            System.Drawing.SolidBrush drawBrush = new
                System.Drawing.SolidBrush(System.Drawing.Color.Black);
            string txt;
            
            for (int i=0;i<n;i+=0)
            {
                if(i==0 || i==n-1)
                {
                    formGraphics.DrawEllipse(myPen, a[0], a[1], 30, 30);
                    ++i;
                    txt = i.ToString();
                    formGraphics.DrawString(txt, drawFont, drawBrush, a[0], a[1]);
                    L[k] = a[0];
                    L[k+1] = a[1];
                    k += 2;
                }
                else
                {
                    formGraphics.DrawEllipse(myPen, b[0], b[1], 30, 30);
                    ++i;
                    txt = i.ToString();
                    formGraphics.DrawString(txt, drawFont, drawBrush, b[0], b[1]);
                    L[k] = b[0];
                    L[k + 1] = b[1];
                    k += 2;
                    formGraphics.DrawEllipse(myPen, c[0], c[1], 30, 30);
                    ++i;
                    txt = i.ToString();
                    formGraphics.DrawString(txt, drawFont, drawBrush, c[0], c[1]);
                    L[k] = c[0];
                    L[k + 1] = c[1];
                    k += 2;
                    a[0] += 100;
                    b[0] += 100;
                    c[0] += 100;
                }
            }
            drawFont.Dispose();
            drawBrush.Dispose();
            for(int i=0;i<n;i+=2)
            {
                Parallel.Invoke(
          () =>
          {
              for (int j = 0; j < n; ++j)
              {
                  if (i == j)
                  {
                      continue;
                  }
                  if (A[i, j] == 1)
                  {
                      formGraphics.DrawLine(myPen, L[2 * i] + 15, L[2 * i + 1] + 15, L[2 * j] + 15, L[2 * j + 1] + 15) ;
                  }
              }

          },
          () =>
          {
              for (int j = 0; j < n; ++j)
              {
                  if (i == j)
                  {
                      continue;
                  }
                  if (A[i, j] == 1)
                  {
                      formGraphics1.DrawLine(myPen1, L[2 * (i + 1)] + 15, L[2 * (i + 1) + 1] + 15, L[2 * j] + 15, L[2 * j + 1] + 15);
                  }
              }

          }
          );
            }
           

            myPen.Dispose();
            myPen1.Dispose();

            formGraphics.Dispose();
            formGraphics1.Dispose();
            

        }
        private int recursia(int a, int b, int[,] A)
        {
            int t = 0;
            for (int i = a; i <= b; ++i)
            {
                if (A[a, i] == 1)
                    if (i == b)
                        return 1;
                    else t+=recursia(i, b, A);
            }
            if (t>0)
            {
                return 1;
            }
            return 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
    
}
