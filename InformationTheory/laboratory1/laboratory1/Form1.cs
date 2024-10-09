using DocumentFormat.OpenXml.Packaging;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

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

                var charFrequencies = inputText.ToLower().Where(c => allowedChars.Contains(c))
                            .GroupBy(c => c)
                            .OrderBy(g => g.Key)
                            .Select(g => new { Character = g.Key, Frequency = g.Count() })
                            .ToList();

                double entropy = CalculateEntropy(charFrequencies.Select(f => (f.Character, f.Frequency)).ToList());
                double kol_info = entropy * inputText.Length / 8 / 1024;

                dataGridView1.DataSource = charFrequencies;
                dataGridView1.Columns["Character"].HeaderText = "Character";
                dataGridView1.Columns["Frequency"].HeaderText = "Frequency";

                HresultLabel1.Text = entropy.ToString();
                IResultLabel1.Text = kol_info.ToString() + " KB or " + (kol_info / 1024).ToString() + " MB";

                CreateHistogramForText();
                ClearDataGridView(dataGridView);
                ClearChart(chart);
                HresultLabel.Text = "None";
                IResultLabel.Text = "None";
            }
            else if (radioButton2.Checked)
            {
                if (!string.IsNullOrEmpty(inputNameFileBox.Text))
                {
                    string filePath = inputNameFileBox.Text;

                    if (IsWordFile(inputNameFileBox.Text))
                    {
                        inputText = ReadTextFromDocx(filePath);
                    }
                    else if (IsOdtFile(inputNameFileBox.Text))
                    {
                        inputText = ReadTextFromOdt(filePath);
                    }
                    else if (IsPdfFile(inputNameFileBox.Text))
                    {
                        inputText = ReadTextFromPdf(filePath);
                    }
                    else {
                        using (StreamReader reader = new StreamReader(inputNameFileBox.Text))
                        {
                            inputText = reader.ReadToEnd();
                        }
                    }

                    Boolean flag = IsTextFile(inputNameFileBox.Text);

                    if (flag)
                    {

                        byte[] fileBytes = GetByteArrayFromFile(inputNameFileBox.Text);

                        var byteFrequencies = fileBytes
                        .GroupBy(b => b)
                        .OrderBy(g => g.Key)
                        .Select(g => new { ByteValue = g.Key, Frequency = g.Count() })
                        .ToList();

                        double entropy = CalculateEntropy(byteFrequencies.Select(f => (f.ByteValue, f.Frequency)).ToList());
                        double kol_info = entropy * inputText.Length / 8 / 1024;



                        dataGridView.DataSource = byteFrequencies;
                        dataGridView.Columns["ByteValue"].HeaderText = "Character";
                        dataGridView.Columns["Frequency"].HeaderText = "Frequency";

                        HresultLabel.Text = entropy.ToString();
                        IResultLabel.Text = kol_info.ToString() + " KB or " + (kol_info / 1024).ToString() + " MB";




                        var charFrequencies = inputText.ToLower().Where(c => allowedChars.Contains(c))
                            .GroupBy(c => c)
                            .OrderBy(g => g.Key)
                            .Select(g => new { Character = g.Key, Frequency = g.Count() })
                            .ToList();

                        
                        double entropy1 = CalculateEntropy(charFrequencies.Select(f => (f.Character, f.Frequency)).ToList());
                        double kol_info1 = entropy1 * inputText.Length / 8 / 1024;

                        dataGridView1.DataSource = charFrequencies;
                        dataGridView1.Columns["Character"].HeaderText = "Character";
                        dataGridView1.Columns["Frequency"].HeaderText = "Frequency";

                        HresultLabel1.Text = entropy1.ToString();
                        IResultLabel1.Text = kol_info1.ToString() + " KB or " + (kol_info1 / 1024).ToString() + " MB";


                        CreateHistogramForText();
                        CreateHistogramForFile();

                        
                    }
                    else
                    {

                        byte[] fileBytes = GetByteArrayFromFile(inputNameFileBox.Text);

                        var byteFrequencies = fileBytes
                        .GroupBy(b => b)
                        .OrderBy(g => g.Key)
                        .Select(g => new { ByteValue = g.Key, Frequency = g.Count() })
                        .ToList();

                        double entropy = CalculateEntropy(byteFrequencies.Select(f => (f.ByteValue, f.Frequency)).ToList());
                        double kol_info = entropy * inputText.Length / 8 / 1024;



                        dataGridView.DataSource = byteFrequencies;
                        dataGridView.Columns["ByteValue"].HeaderText = "Character";
                        dataGridView.Columns["Frequency"].HeaderText = "Frequency";

                        HresultLabel.Text = entropy.ToString();
                        IResultLabel.Text = kol_info.ToString() + " KB or " + (kol_info / 1024).ToString() + " MB";

                        CreateHistogramForFile();
                        ClearDataGridView(dataGridView1);
                        ClearChart(chart1);
                        HresultLabel1.Text = "None";
                        IResultLabel1.Text = "None";

                    }
                }
                else
                {
                    textBox1.Text = "Please select a file.";
                    return;
                }
            }

            
        }

        private string ReadTextFromDocx(string filePath)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(filePath, true))
            {
                MainDocumentPart mainPart = wordDocument.MainDocumentPart;

                if (mainPart != null)
                {
                    string text = mainPart.Document.Body.InnerText;
                    return text;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private string ReadTextFromPdf(string filePath)
        {
            using (var pdfReader = new PdfReader(filePath))
            {
                var text = string.Empty;
                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    text += PdfTextExtractor.GetTextFromPage(pdfReader, page);
                }
                return text;
            }
        }



        public static byte[] GetByteArrayFromFile(string filePath)
        {
            byte[] fileBytes;

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                fileBytes = new byte[fileStream.Length];
                fileStream.Read(fileBytes, 0, fileBytes.Length);
            }

            return fileBytes;
        }


        private bool IsTextFile(string filePath)
        {
            string fileExtension = System.IO.Path.GetExtension(filePath);
            string[] textFileExtensions = {
        ".txt", ".csv", ".xml", ".json", ".log", ".md", ".markdown", ".rst", ".ini", ".cfg", ".conf",
        ".bat", ".cmd", ".sh", ".bash", ".zsh", ".ps1", ".sql", ".css", ".less", ".sass", ".scss",
        ".html", ".htm", ".xhtml", ".php", ".asp", ".aspx", ".jsp", ".jspx", ".jsf", ".jspx",
        ".tex", ".latex", ".bib", ".doc", ".docx", ".odt", ".rtf", ".wps", ".wpd",
        ".yaml", ".yml", ".toml", ".properties", ".props", ".env", ".pdf"
    }; // add more extensions as needed

            return textFileExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase);
        }

        private bool IsWordFile(string filePath)
        {
            string fileExtension = System.IO.Path.GetExtension(filePath);
            string[] textFileExtensions = {
        ".doc", ".docx"
    }; 



            return textFileExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase);
        }

        private bool IsOdtFile(string filePath)
        {
            string fileExtension = System.IO.Path.GetExtension(filePath);
            string[] textFileExtensions = {
        ".odt"
    };

            



                return textFileExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase);
        }

        private bool IsPdfFile(string filePath)
        {
            string fileExtension = System.IO.Path.GetExtension(filePath);
            string[] textFileExtensions = {
        ".pdf"
    };
            return textFileExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase);
        }

        private string ReadTextFromOdt(string filePath)
        {
            using (ZipArchive archive = ZipFile.OpenRead(filePath))
            {
                var entry = archive.GetEntry("content.xml");
                if (entry != null)
                {
                    using (var stream = entry.Open())
                    {
                        var xmlDoc = new XmlDocument();
                        xmlDoc.Load(stream);

                        var text = xmlDoc.InnerText;
                        return text;
                    }
                }
            }
            return string.Empty;
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

        private double CalculateEntropy(List<(byte ByteValue, int Frequency)> frequencies)
        {
            double entropy = 0;
            int totalBytes = frequencies.Sum(f => f.Frequency);

            foreach (var (byteValue, frequency) in frequencies)
            {
                double probability = (double)frequency / totalBytes;
                entropy -= probability * Math.Log(probability, 2);
            }
            return entropy;
        }

        private void CreateHistogramForFile()
        {
            chart.Series.Clear();

            Series series = new Series("Файл");


            // Очищаем существующую серию от всех точек данных
            series.Points.Clear();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string character = row.Cells["ByteValue"].Value?.ToString() ?? "";
                int frequency = Convert.ToInt32(row.Cells["Frequency"].Value);

                series.Points.AddXY(character, frequency);
            }

            chart.Series.Add(series);

            // Настройка осей и шкафа
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -90; // Горизонтальные метки
            chart.ChartAreas[0].AxisX.Interval = 1; // Интервал между метками (every 6 elements)
            chart.ChartAreas[0].AxisX.LabelStyle.Interval = 6; // Show labels every 6 elements
            chart.Legends[0].Enabled = false; // Включение легенды
        }


        private void CreateHistogramForText()
        {
            chart1.Series.Clear();

            Series series = new Series("Текст");


            // Очищаем существующую серию от всех точек данных
            series.Points.Clear();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string character = row.Cells["Character"].Value?.ToString() ?? "";
                int frequency = Convert.ToInt32(row.Cells["Frequency"].Value);

                series.Points.AddXY(character, frequency);
            }

            chart1.Series.Add(series);

            // Настройка осей и шкафа
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // Горизонтальные метки
            chart1.ChartAreas[0].AxisX.Interval = 1; // Интервал между метками
            chart1.Legends[0].Enabled = true; // Включение легенды
        }


        private void chart_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ClearDataGridView(DataGridView dataGridView)
        {
            dataGridView.DataSource = null;
            dataGridView.Columns.Clear();
        }

        private void ClearChart(Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas[0].AxisX.LabelStyle.Interval = 0;
            chart.ChartAreas[0].AxisX.Interval = 0;
            chart.Legends[0].Enabled = false;
        }
    }



}

