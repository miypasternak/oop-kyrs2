using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComplexNumbers;

namespace classiiii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public ComplexNumber complex = new ComplexNumber();
        private bool CheckDouble(string[] valueMas)
        {
            int k = 0;
            foreach (string s in valueMas)
            {
                if (double.TryParse(s,out _))
                {
                    k++;
                }
                else
                    return false;
            }
            if (k == valueMas.Length)
                return true;
            return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] valueMas = textBox1.Text.Split();
            if (valueMas.Length < 3 )
            {
                if (valueMas.Length == 2)
                { 
                    if (CheckDouble(valueMas))
                    {
                        complex.Input(Convert.ToDouble(valueMas[0]), Convert.ToDouble(valueMas[1]));
                        label4.Text = complex.CreateStringNumber();
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Ошибка, введено больше 2 символов");
                textBox1.Clear();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strDegree = textBox2.Text;
            int degree;
            if (int.TryParse(textBox2.Text,out degree))
            {
                if (degree > 0)
                {
                    ComplexNumber rez_complex = complex.Power(degree);
                    label5.Text = rez_complex.CreateStringNumber();
                }
            }
        }
    }
}
