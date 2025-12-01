using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string ToBin(int n)
        {
            string t = "";
            while (n>0)
            {
                t += (n % 2).ToString();
                n/=2; 
            }
            string rez = "";
            for (int i = t.Length-1; i>=0;i--)
            {
                rez += t[i];
            }
            return rez;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            label3.Text = str.ToUpper();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            int number;
            

            if (int.TryParse(str, out number))
            {
                str = ToBin(number);
                label5.Text = str;
            }
            else
            {
                label5.Text = "ОШИБКА, ВВЕДЕНЫ НЕ ЦИФРЫ";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string looking = textBox1.Text;
            string what_looking = textBox2.Text;
            
            int n = (looking.Length -looking.Replace(what_looking, "").Length) / what_looking.Length;
            label7.Text = n.ToString();
        }
    }
}
