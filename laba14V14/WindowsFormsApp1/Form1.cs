using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeComboBoxes();
            create_check();
        }

        private void InitializeComboBoxes()
        {
            comboBox1.Items.AddRange(new string[] { "Тольятти", "Самара", "Каменная чаша", "Дорогами С.Разина" });
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private bool CheckState()
        {
            return comboBox1.SelectedIndex != -1 &&
               comboBox2.SelectedIndex != -1 &&
               !string.IsNullOrWhiteSpace(textBox1.Text) &&
               !string.IsNullOrWhiteSpace(textBox2.Text) &&
               numericUpDown1.Value > 0 &&
               Compare_Date();
               
        }

        private bool Compare_Date()
        {
            DateTime startDate = monthCalendar1.SelectionEnd.Date;
            DateTime endDate = dateTimePicker1.Value.Date;
            return endDate>startDate;

        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            switch (comboBox1.SelectedItem?.ToString())
            {
                case "Тольятти":
                    comboBox2.Items.AddRange(new string[] { "Автобус", "Омик" });
                    break;
                case "Самара":
                    comboBox2.Items.AddRange(new string[] { "Автобус", "Омик" });
                    break;
                case "Каменная чаша":
                    comboBox2.Items.AddRange(new string[] { "Автобус", "Омик", "Лошади" });
                    break;
                case "Дорогами С.Разина":
                    comboBox2.Items.AddRange(new string[] { "Автобус", "Омик", "Лошади" });
                    break;
            }
            comboBox2.SelectedIndex = -1;
            Compare_Date();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            create_check();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            create_check();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            create_check();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            create_check();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            create_check();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string text = textBox2.Text;

            
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            
            if (text == "-")
            {
                return;
            }

            if (!double.TryParse(text, out _))
            {
                MessageBox.Show("Неверно введена цена билета! Вводятся только цифры!", "Ошибка!");
                textBox2.Clear();
            }
            create_check();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            create_check();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            double priceTicket = 0;
            if (!double.TryParse(textBox2.Text, out _))
            {
                MessageBox.Show("Неверно введена цена билета! Вводятся только цифры!", "Ошибка!");
            }
            else
            {
                priceTicket = Convert.ToInt32(textBox2.Text);
            }
                
               
            int countPeople = Convert.ToInt32(numericUpDown1.Value);

            double priceTravell = priceTicket * countPeople;
            double addWaterTransport = 0.2;
            double addHorse = 0.5;
            double DiscountMore30People = 0.05;

            if (comboBox2.SelectedItem?.ToString() == "Омик")
            {
                priceTravell += priceTravell * addWaterTransport;
            }    
            if ((comboBox2.SelectedItem?.ToString() == "Лошади"))
            {
                priceTravell += priceTravell * addHorse;
            }
            if (countPeople > 30)
            {
                priceTravell -= priceTravell * DiscountMore30People;
            }
            MessageBox.Show($"Итоговая стоимость: {priceTravell}\nТекст автоматически скопирован в буфера обмена!", "ИТОГ");
            Clipboard.SetText(priceTravell.ToString());
        }

        private void create_check()
        {
            
            button1.Enabled = CheckState();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Title = "Сохранить данные экскурсии";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.OverwritePrompt = true; 
            saveFileDialog.AddExtension = true;    

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                SaveInfoToFile(filePath);
            }
        }

        private void SaveInfoToFile(string filePath)
        {
            StringBuilder bigText = new StringBuilder();
            bigText.AppendLine($"Дата начала: {monthCalendar1.SelectionEnd:dd.MM.yyyy}");
            bigText.AppendLine($"Дата окончания: {dateTimePicker1.Value:dd.MM.yyyy}");
            bigText.AppendLine($"Маршрут: {comboBox1.SelectedItem}");
            bigText.AppendLine($"Транспорт: {comboBox2.SelectedItem}");
            bigText.AppendLine($"Количество человек: {numericUpDown1.Value}");
            bigText.AppendLine($"ФИО: {textBox1.Text}");
            bigText.AppendLine($"Стоимость билета: {textBox2.Text} руб.");

            string value = bigText.ToString();
            File.WriteAllText(filePath, value);
            
            
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Выберите файл с данными экскурсии";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Multiselect = false; 
            openFileDialog.CheckFileExists = true; 
            openFileDialog.CheckPathExists = true; 
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                OpenToFile(selectedFilePath);
            }
        }

        private void OpenToFile(string Filepath)
        {
            string value = File.ReadAllText(Filepath);
            string[] infoFromFile = value.Split('\n');
            int k = 0;
            foreach (string line in infoFromFile)
            {
                string[] findEl = line.Split();
                if (k == 0) monthCalendar1.SetDate(DateTime.Parse(findEl[2]));
                if (k == 1) dateTimePicker1.Value = DateTime.Parse(findEl[2]);
                if (k == 2) comboBox1.SelectedItem = findEl[1];
                if (k == 3) comboBox2.SelectedItem = findEl[1];
                if (k == 4) numericUpDown1.Value = decimal.Parse(findEl[2]);
                if (k == 5) textBox1.Text = findEl[1];
                if (k == 6) textBox2.Text = findEl[2];
                k++;
            }
        }


        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
