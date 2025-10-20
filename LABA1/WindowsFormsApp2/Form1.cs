using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            List<string> mas_value = value.Split(' ').ToList();
            string rez = "";


            for (int i = 0; i < mas_value.Count - 1; i++)
            {
                for (int j = 0; j < mas_value.Count - 1 - i; j++)
                {
                    if (mas_value[j].Length > mas_value[j + 1].Length)
                    {
                        string t1 = mas_value[j];
                        mas_value[j] = mas_value[j + 1];
                        mas_value[j + 1] = t1;
                    }
                }
            }

            for (int i = 0; i<mas_value.Count-1; i++)
            {
                if (mas_value[i].Length == mas_value[i+1].Length)
                {
                    int result = string.Compare(mas_value[i], mas_value[i + 1], StringComparison.Ordinal);
                    if (result > 0)
                    {
                        string t1 = mas_value[i];
                        mas_value[i] = mas_value[i + 1];
                        mas_value[i + 1] = t1;
                    }    
                }
            }

            foreach (string a in  mas_value)
            {
                rez += " " + a;
            }
            label3.Text = rez;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            int k = Convert.ToInt32(textBox2.Text);
            List<string> mas_value = value.Split(' ').ToList();
            List<string> mas_rez = new List<string>();
            string rez = "";

            for (int i = 0; i<mas_value.Count;i++)
            {
                if (mas_value[i].Length == k)
                {
                    if (char.IsDigit(mas_value[i][k-1]))
                    {
                        mas_rez.Add(mas_value[i]);
                    }
                }
            }
            mas_rez.Sort();
            foreach (string a in mas_rez)
            {
                rez += " " + a;
            }
            label6.Text = rez;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            List<string> mas_value = value.Split(' ').ToList();
            HashSet<int> mn_ends = new HashSet<int>();
            List<string> mas_rez = new List<string>();
            string rez = "";

            foreach (string ends in mas_value)
            {
                mn_ends.Add((int)ends[0]);
            }
            List<int> mas_ends = mn_ends.ToList();
            mas_value.Sort();
            int maxi = -1;
            foreach (int end in mas_ends)
            {
                string t = "";
                for (int i = 0; i < mas_value.Count; i++)
                {
                    if (end == (int)mas_value[i][0])
                    {
                        if (maxi < mas_value[i].Length)
                        {
                            maxi = mas_value[i].Length;
                            t = mas_value[i];
                        }
                    }
                }
                mas_rez.Add(t);
                maxi = -1;
            }
            foreach (string a in mas_rez)
            {
                rez += " " + a;
            }
            label8.Text = rez;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            List<string> mas_value = value.Split(' ').ToList();
            HashSet<int> mn_l_mass = new HashSet<int>();
            List<string> mas_rez = new List<string>();
            string rez = "";

            foreach (string i in  mas_value)
            {
                mn_l_mass.Add(i.Length);  
            }
            List<int> mas_l_mass = mn_l_mass.ToList();
            mas_l_mass.Sort();
            mas_l_mass.Reverse();
            List<string> t = new List<string>();
            foreach (int l in mas_l_mass)
            {
                foreach (string str in mas_value)
                {
                    if (str.Length == l)
                    {
                        t.Add(str);
                    }
                }
                t.Sort();
                mas_rez.Add(t[0]);
                t.Clear();
            }
            foreach (string a in mas_rez)
            {
                rez += " " + a;
            }
            label10.Text = rez;
        }
    }
}
