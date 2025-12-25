using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void print(int len_mas, int[] numbs)
        {
            for (int i = 0; i < len_mas; i++)
            {
                Console.WriteLine(numbs[i]);    
            }
        }

        private bool CheckArifmMass(int len_mas, int[] numbs)
        {
            int k = 0;
            int d = numbs[1]-numbs[0];
            for (int i = 1; i < len_mas-1; i++)
            {
                if (numbs[i+1] - numbs[i] == d)
                {
                    k++;
                }
                
                else return false; 
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text.TrimEnd();
            int numb;
            string[] value_mas = value.Split();
            int len_mas = value_mas.Length;
            int[] numbs = new int[len_mas];

            for (int i = 0; i<len_mas;i++)
            {
                if (int.TryParse(value_mas[i], out numb))
                {
                    numbs[i] = numb;
                }
            }

            if (CheckArifmMass(len_mas, numbs)) label2.Text = "True";
            else label2.Text = "False"; 
        }

        private int ChecklocalMin(int len_mas, int[] numbs)
        {
            for (int i = 1; i < len_mas-1; i++)
            {
                if (numbs[i] < numbs[i-1] && numbs[i] < numbs[i+1])
                {
                    return i; 
                }
            }
            return -1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text.TrimEnd();
            int numb;
            string[] value_mas = value.Split();
            int len_mas = value_mas.Length;
            int[] numbs = new int[len_mas];

            for (int i = 0; i < len_mas; i++)
            {
                if (int.TryParse(value_mas[i], out numb))
                {
                    numbs[i] = numb;
                }
            }

            int rez = ChecklocalMin(len_mas, numbs);
            if (rez != -1) label3.Text = "s: " + rez.ToString() + " | " + "p: " + (rez+1).ToString();
            else label3.Text = "Error, not found";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text.TrimEnd();
            string[] value_mas = value.Split();
            var set_numbs = value_mas.Distinct();
            int len_set = set_numbs.Count();
            label4.Text = len_set.ToString();    
        }

        private int CheckPerStatus(int len_mas, int[] numbs)
        {
            int k = 0;
            int max = numbs.Max();
            if (max == len_mas)
            {
                for (int i = 0; i < len_mas; i++)
                {
                    if (numbs[i] <= len_mas)
                    {
                        k++;
                    }
                }
            }
            else return Array.IndexOf(numbs, max);
            if (k == len_mas) return 0;
            else return -5;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text.TrimEnd();
            int numb;
            string[] value_mas = value.Split();
            int len_mas = value_mas.Length;
            int[] numbs = new int[len_mas];

            for (int i = 0; i < len_mas; i++)
            {
                if (int.TryParse(value_mas[i], out numb))
                {
                    numbs[i] = numb;
                }
            }
            int rez = CheckPerStatus(len_mas, numbs);
            if (rez == 0) label5.Text = "0";
            else label5.Text = "s: "+rez.ToString()+" | p: "+(rez+1).ToString();
        }
    }
}
