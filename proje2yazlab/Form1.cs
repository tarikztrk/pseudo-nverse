using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje2yazlab
{
    public partial class Form1 : Form
    {
        double determinant;
        double[,] matris3;
        double[,] matris1;
        double[,] sonucMatrisi;
        int satir;
        int sutun;
        private TextBox[,] matris2;
        private TextBox[,] temp4;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            groupBox1.Controls.Clear();
            if (!int.TryParse(textBox1.Text, out satir))
            {
                MessageBox.Show("Satır sayısı boş bırakılamaz.");
                return;
            }
            if (!int.TryParse(textBox2.Text, out sutun))
            {
                MessageBox.Show("Sutun sayısı boş bırakılamaz.");
                return;
            }
           
            matris2 = new TextBox[satir, sutun];
            int boyut = groupBox1.Width / sutun;
            for (int i = 0; i < matris2.GetLength(0); i++)
            {
                for (int j = 0; j < matris2.GetLength(1); j++)
                {
                    matris2[i, j] = new TextBox();
                    matris2[i, j].Text = "0";
                    matris2[i, j].Top = (i * matris2[i, j].Height) + 20;
                    matris2[i, j].Left = j * boyut + 6;
                    matris2[i, j].Width = boyut;
                    groupBox1.Controls.Add(matris2[i, j]);
                }
            }

        }
        Random rastgele = new Random();
        private void button2_Click(object sender, EventArgs e)
        {

            groupBox1.Controls.Clear();
            if (!int.TryParse(textBox1.Text, out satir))
            {
                MessageBox.Show("Satır sayısı boş bırakılamaz.");
                return;
            }
            if (!int.TryParse(textBox2.Text, out sutun))
            {
                MessageBox.Show("Sutun sayısı boş bırakılamaz.");
                return;
            }
            
           matris2 = new TextBox[satir, sutun];
            int boyut = groupBox1.Width / sutun;
            for (int i = 0; i < matris2.GetLength(0); i++)
            {
                for (int j = 0; j < matris2.GetLength(1); j++)
                {
                    matris2[i, j] = new TextBox();
                    double sayi = rastgele.Next(9);
                    matris2[i, j].Text = sayi.ToString();
                    matris2[i, j].Top = (i * matris2[i, j].Height) + 20;
                    matris2[i, j].Left = j * boyut + 6;
                    matris2[i, j].Width = boyut;
                    groupBox1.Controls.Add(matris2[i, j]);
                    
                }
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double[,] ozdegerMatrisi = new double[matris2.GetLength(0), matris2.GetLength(1)];
            double[,] kofaktor = new double[matris2.GetLength(0), matris2.GetLength(1)];

            double[,] temp = new double[matris2.GetLength(0), matris2.GetLength(1)];
            for (int x = 0; x < matris2.GetLength(0); x++)
            {
                for (int y = 0; y < matris2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(matris2[x, y].Text, out n);
                    temp[x, y] = n;
                   
                }
            }
            double[,] sonuc = matematikselİslemler.transpoze(temp);
            double[,] temp2 = matematikselİslemler.carpma(sonuc, temp);

            

            ////double[,] temp = matematikselİslemler.carpma(matematikselİslemler.transpoze(matris1), matris1);
            if (temp2.GetLength(0) == 2 && temp2.GetLength(1) == 2)
            {
                determinant = matematikselİslemler.determinantAl2x2(temp2);
            }
            if (temp2.GetLength(0) == 3 && temp2.GetLength(1) == 3)
            {
                determinant = matematikselİslemler.determinantAl3x3(temp2);
            }

            if (temp2.GetLength(0) == 2 && temp2.GetLength(1) == 2)
            {
                kofaktor = matematikselİslemler.kofaktorAl2x2(temp2);
                ozdegerMatrisi = matematikselİslemler.transpoze(kofaktor);
            }
            if (temp2.GetLength(0) == 3 && temp2.GetLength(1) == 3)
            {
                kofaktor = matematikselİslemler.kofaktorAl3x3(temp2);
                ozdegerMatrisi = matematikselİslemler.transpoze(kofaktor);
            }



            double[,] temp3 = matematikselİslemler.tersAl(determinant,ozdegerMatrisi);

            double[,] tempMatris4 = matematikselİslemler.carpma(temp3, sonuc);

            ////sonucMatrisi = temp;
            temp4 = new TextBox[tempMatris4.GetLength(0), tempMatris4.GetLength(1)];
            int boyut = groupBox1.Width / temp4.GetLength(1);
            groupBox1.Controls.Clear();
            for (int i = 0; i < temp4.GetLength(0); i++)
            {
                for (int j = 0; j < temp4.GetLength(1); j++)
                {
                    temp4[i, j] = new TextBox();

                    temp4[i, j].Text = tempMatris4[i, j].ToString();
                    temp4[i, j].Top = (i * temp4[i, j].Height) + 20;
                    temp4[i, j].Left = j * boyut + 6;
                    temp4[i, j].Width = boyut;
                    groupBox1.Controls.Add(temp4[i, j]);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double[,] temp = new double[matris2.GetLength(0), matris2.GetLength(1)];
            for (int x = 0; x < matris2.GetLength(0); x++)
            {
                for (int y = 0; y < matris2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(matris2[x, y].Text, out n);
                    temp[x, y] = n;

                }
            }
            double[,] sonuc = matematikselİslemler.transpoze(temp);

            temp4 = new TextBox[sonuc.GetLength(0), sonuc.GetLength(1)];
            int boyut = groupBox1.Width / temp4.GetLength(1);
            groupBox1.Controls.Clear();
            for (int i = 0; i < temp4.GetLength(0); i++)
            {
                for (int j = 0; j < temp4.GetLength(1); j++)
                {
                    temp4[i, j] = new TextBox();

                    temp4[i, j].Text = sonuc[i, j].ToString();
                    temp4[i, j].Top = (i * temp4[i, j].Height) + 20;
                    temp4[i, j].Left = j * boyut + 6;
                    temp4[i, j].Width = boyut;
                    groupBox1.Controls.Add(temp4[i, j]);
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            double[,] temp = new double[matris2.GetLength(0), matris2.GetLength(1)];
            for (int x = 0; x < matris2.GetLength(0); x++)
            {
                for (int y = 0; y < matris2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(matris2[x, y].Text, out n);
                    temp[x, y] = n;

                }
            }
            double[,] sonuc = matematikselİslemler.transpoze(temp);
            double[,] temp2 = matematikselİslemler.carpma(sonuc, temp);


            temp4 = new TextBox[temp2.GetLength(0), temp2.GetLength(1)];
            int boyut = groupBox1.Width / temp4.GetLength(1);
            groupBox1.Controls.Clear();
            for (int i = 0; i < temp4.GetLength(0); i++)
            {
                for (int j = 0; j < temp4.GetLength(1); j++)
                {
                    temp4[i, j] = new TextBox();

                    temp4[i, j].Text = temp2[i, j].ToString();
                    temp4[i, j].Top = (i * temp4[i, j].Height) + 20;
                    temp4[i, j].Left = j * boyut + 6;
                    temp4[i, j].Width = boyut;
                    groupBox1.Controls.Add(temp4[i, j]);
                }
            }
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            double[,] ozdegerMatrisi = new double[matris2.GetLength(0), matris2.GetLength(1)];
            double[,] kofaktor = new double[matris2.GetLength(0), matris2.GetLength(1)];

            double[,] temp = new double[matris2.GetLength(0), matris2.GetLength(1)];
            for (int x = 0; x < matris2.GetLength(0); x++)
            {
                for (int y = 0; y < matris2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(matris2[x, y].Text, out n);
                    temp[x, y] = n;

                }
            }
            double[,] sonuc = matematikselİslemler.transpoze(temp);
            double[,] temp2 = matematikselİslemler.carpma(sonuc, temp);



            ////double[,] temp = matematikselİslemler.carpma(matematikselİslemler.transpoze(matris1), matris1);
            if (temp2.GetLength(0) == 2 && temp2.GetLength(1) == 2)
            {
                determinant = matematikselİslemler.determinantAl2x2(temp2);
            }
            if (temp2.GetLength(0) == 3 && temp2.GetLength(1) == 3)
            {
                determinant = matematikselİslemler.determinantAl3x3(temp2);
            }

            if (temp2.GetLength(0) == 2 && temp2.GetLength(1) == 2)
            {
                kofaktor = matematikselİslemler.kofaktorAl2x2(temp2);
                ozdegerMatrisi = matematikselİslemler.transpoze(kofaktor);
            }
            if (temp2.GetLength(0) == 3 && temp2.GetLength(1) == 3)
            {
                kofaktor = matematikselİslemler.kofaktorAl3x3(temp2);
                ozdegerMatrisi = matematikselİslemler.transpoze(kofaktor);
            }



            double[,] temp3 = matematikselİslemler.tersAl(determinant, ozdegerMatrisi);

            temp4 = new TextBox[temp3.GetLength(0), temp3.GetLength(1)];
            int boyut = groupBox1.Width / temp4.GetLength(1);
            groupBox1.Controls.Clear();
            for (int i = 0; i < temp4.GetLength(0); i++)
            {
                for (int j = 0; j < temp4.GetLength(1); j++)
                {
                    temp4[i, j] = new TextBox();

                    temp4[i, j].Text = temp3[i, j].ToString();
                    temp4[i, j].Top = (i * temp4[i, j].Height) + 20;
                    temp4[i, j].Left = j * boyut + 6;
                    temp4[i, j].Width = boyut;
                    groupBox1.Controls.Add(temp4[i, j]);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {double[,] ozdegerMatrisi = new double[matris2.GetLength(0), matris2.GetLength(1)];
            double[,] kofaktor = new double[matris2.GetLength(0), matris2.GetLength(1)];
            double[,] temp = new double[matris2.GetLength(0), matris2.GetLength(1)];
            for (int x = 0; x < matris2.GetLength(0); x++)
            {
                for (int y = 0; y < matris2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(matris2[x, y].Text, out n);
                    temp[x, y] = n;

                }
            }
            double[,] sonuc = matematikselİslemler.transpoze(temp);
            double[,] temp2 = matematikselİslemler.carpma(sonuc, temp);



            ////double[,] temp = matematikselİslemler.carpma(matematikselİslemler.transpoze(matris1), matris1);
            if (temp2.GetLength(0) == 2 && temp2.GetLength(1) == 2)
            {
                determinant = matematikselİslemler.determinantAl2x2(temp2);
            }
            if (temp2.GetLength(0) == 3 && temp2.GetLength(1) == 3)
            {
                determinant = matematikselİslemler.determinantAl3x3(temp2);
            }

            if (temp2.GetLength(0) == 2 && temp2.GetLength(1) == 2)
            {
                kofaktor = matematikselİslemler.kofaktorAl2x2(temp2);
                ozdegerMatrisi = matematikselİslemler.transpoze(kofaktor);
            }
            if (temp2.GetLength(0) == 3 && temp2.GetLength(1) == 3)
            {
                kofaktor = matematikselİslemler.kofaktorAl3x3(temp2);
                ozdegerMatrisi = matematikselİslemler.transpoze(kofaktor);
            }



            double[,] temp3 = matematikselİslemler.tersAl(determinant, ozdegerMatrisi);

            double[,] tempMatris4 = matematikselİslemler.carpma(temp3, sonuc);

            temp4 = new TextBox[tempMatris4.GetLength(0), tempMatris4.GetLength(1)];
            int boyut = groupBox1.Width / temp4.GetLength(1);
            groupBox1.Controls.Clear();
            for (int i = 0; i < temp4.GetLength(0); i++)
            {
                for (int j = 0; j < temp4.GetLength(1); j++)
                {
                    temp4[i, j] = new TextBox();

                    temp4[i, j].Text = tempMatris4[i, j].ToString();
                    temp4[i, j].Top = (i * temp4[i, j].Height) + 20;
                    temp4[i, j].Left = j * boyut + 6;
                    temp4[i, j].Width = boyut;
                    groupBox1.Controls.Add(temp4[i, j]);
                }
            }
        }
    }
}
