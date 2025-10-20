using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
// РЕШЕНИЕ ЗАДАЧ НОМЕР: 18, 19, 20, 57
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.TextChanged += textBox1_TextChanged;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Text = textBox1.Text;
            string value = textBox1.Text;
            string rez = "";
        
            List<string> numbs = value.Split(' ').ToList();
            for (int i = 0; i < numbs.Count; i++)
            {
                if (int.TryParse(numbs[i], out int number))
                {
                    if (number % 2 == 0 && number < 0)
                    {
                        rez += " " + numbs[i];
                    }


                }
            }


            label6.Text= rez;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = textBox2.Text;
            string value = textBox1.Text;
            string rez = "";

            List<string> numbs = value.Split(' ').ToList();
            List<int> values = new List<int>();

            for (int i = 0; i<numbs.Count;i++ )
            {
                if (int.TryParse(numbs[i],out int n))
                {
                    if (n%10==Convert.ToInt32(number) && n>0)
                    {
                        while(values.IndexOf(n) != -1)
                        {
                            values.Remove(n);
                        }
                        values.Add(n);
                        
                    }    
                }
            }
            
            foreach (int i in values)
            {
                rez += " " + Convert.ToString(i);
            }
            label9.Text= rez;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            string rez = "";

            List<string> numbs = value.Split(' ').ToList();
            List<int> values = new List<int>();
            for (int i = 0; i < numbs.Count; i++)
            {
                if (int.TryParse(numbs[i], out int n))
                {
                    if (n >= 10 && n <= 99)
                    {
                        values.Add(n);
                    }

                }
            }
            values.Sort();
            foreach (int i in values)
            {
                rez += " " + Convert.ToString(i);
            }
            label11.Text= rez; 
    }

        private void button3_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            string rez = "";
            // 22 34 32 56
            List<string> numbs = value.Split(' ').ToList();
            List<int> values = new List<int>();
            List<int> ends = new List<int>();

            foreach (string i in numbs)
            {
                if (int.TryParse(i, out int n))
                {
                    while (ends.IndexOf(n%10) != -1)
                    {
                        ends.Remove(n%10);
                    }
                    ends.Add(n % 10);
                }
            }
            int maxi = -10000000;

            foreach (int end  in ends)
            {
                foreach (string i in numbs)
                {
                    if (int.TryParse(i, out int n))
                    {
                        if (n%10== end)
                        {
                            if (maxi < n) maxi = n;
                        }    
                    }
                }
                values.Add(maxi);
                maxi = -10000000;
            }
            ends.Sort();
            foreach (int i in values)
            {
                rez += " " + Convert.ToString(i);
            }
            label13.Text = rez;
        }

    }
}
