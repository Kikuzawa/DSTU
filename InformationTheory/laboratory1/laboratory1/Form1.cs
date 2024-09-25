using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace laboratory1
{
    public partial class Form1 : Form
    {
        private string inputText;
        private HashSet<char> allowedChars;
        
        

        public Form1()
        {
            InitializeComponent();
            allowedChars = new HashSet<char>(
               " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-().,".ToCharArray() +
               " абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789!\"\'`?.,"
           );
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "TXT files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    inputNameFileBox.Text = fileName;
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            inputBox.Enabled = false;
            inputNameFileBox.Enabled = true;
            uploadButton.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            inputNameFileBox.Enabled = false;
            uploadButton.Enabled = false;
            inputBox.Enabled = true;

        }

        private void runButton_Click(object sender, EventArgs e)

        {
            


            if (radioButton1.Checked)
            {
                inputText = inputBox.Text;
            }
            else if (radioButton2.Checked)
            {
                if (!string.IsNullOrEmpty(inputNameFileBox.Text))
                {
                    using (StreamReader reader = new StreamReader(inputNameFileBox.Text))
                    {
                        inputText = reader.ReadToEnd();
                    }

                }
                else
                {
                    MessageBox.Show("Please select a file or enter a filename.", "Error");
                    return;
                }
            }




            if (!string.IsNullOrEmpty(inputText))
            {
                var charFrequencies = inputText.ToLower().Where(c => allowedChars.Contains(c))
                    .GroupBy(c => c)
                    .OrderBy(g => g.Key)
                    .Select(g => new { Character = g.Key, Frequency = g.Count() })
                    .ToList();

                // Расчет энтропии
                double entropy = CalculateEntropy(charFrequencies.Select(f => (f.Character, f.Frequency)).ToList());
                double kol_info = entropy * inputText.Length / 8 / 1024;

                // Отображение результатов
                dataGridView.DataSource = charFrequencies;
                dataGridView.Columns["Character"].HeaderText = "Character";
                dataGridView.Columns["Frequency"].HeaderText = "Frequency";

                // Отображение энтропии
                HresultLabel.Text = entropy.ToString();
                IResultLabel.Text = kol_info.ToString() + " KB or " + (kol_info / 1024).ToString() + " MB";

                CreateHistogram();

            }
            else
            {
                MessageBox.Show("No text entered or selected.", "Error");
            }




        }

        private double CalculateEntropy(List<(char Character, int Frequency)> frequencies)
        {
            double entropy = 0;
            
            foreach (var (character, frequency) in frequencies)
            {
                double probability = (double)frequency / inputText.Length;
                entropy -= probability * Math.Log(probability, 2);
            }
            return entropy;
        }


        private void CreateHistogram()
        {
            

            chart.Series.Clear();


          
 
                Series series = new Series("Character Frequencies");
           

            // Очищаем существующую серию от всех точек данных
            series.Points.Clear();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string character = row.Cells["Character"].Value?.ToString() ?? "";
                int frequency = Convert.ToInt32(row.Cells["Frequency"].Value);

                series.Points.AddXY(character, frequency);
            }

            chart.Series.Add(series);

            // Настройка осей и шкафа
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // Горизонтальные метки
            chart.ChartAreas[0].AxisX.Interval = 1; // Интервал между метками
            chart.Legends[0].Enabled = true; // Включение легенды

            
            
        }

        private void chart_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}

