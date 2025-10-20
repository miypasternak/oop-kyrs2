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
    }
}
