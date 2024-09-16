using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThirdLaboratory
{
    public partial class Form1 : Form
    {
        private int m;
        private int n;
        public Form1()
        {
            InitializeComponent();
            
            this.ClientSize = new System.Drawing.Size(500, 500); // Устанавливаем стартовые размеры формы
            

            // Добавляем обработчик события Resize для формы
            this.Resize += new EventHandler(Form1_Resize);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            dataGridView1.Size = new System.Drawing.Size(this.ClientSize.Width - 300, this.ClientSize.Height - 100); // Устанавливаем новые размеры dataGridView1 пропорционально размеру формы
        }

        private void createMatrixButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(mLinesBox.Text, out m) || !int.TryParse(nLinesBox.Text, out n))
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для m и n.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Добавляем столбцы в dataGridView1
            for (int j = 0; j < n; j++)
            {
                string columnName = $"Column{j + 1}";
                dataGridView1.Columns.Add(columnName, columnName);
            }

            // Добавляем строки в dataGridView1
            for (int i = 0; i < m; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);

                // Устанавливаем название строки
                row.HeaderCell.Value = $"Row{i + 1}";

                // Устанавливаем высоту строки
                row.Height = 60;

                // Добавляем новую строку в DataGridView
                dataGridView1.Rows.Add(row);
            }

            // Настройка размеров столбцов
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 60;
            }

            // Устанавливаем ширину заголовков
            dataGridView1.RowHeadersWidth = 100;

            // Устанавливаем стиль ячеек для выравнивания текста по центру
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Разрешаем редактирование ячеек в dataGridView1
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = false;
        }

        private void randowButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    int randomNumber = rand.Next(-10, 11); // Генерирует случайное число от -10 до 10
                    dataGridView1.Rows[i].Cells[j].Value = randomNumber;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void plusSizeButton_Click(object sender, EventArgs e)
        {
            float currentSize = dataGridView1.DefaultCellStyle.Font.Size;
            dataGridView1.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font.FontFamily, currentSize + 3);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, currentSize + 3);

            // Увеличиваем ширину и высоту ячеек
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width += 3;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height += 3;
            }
        }

        private void minusSizeButton_Click(object sender, EventArgs e)
        {
            float currentSize = dataGridView1.DefaultCellStyle.Font.Size;
            dataGridView1.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font.FontFamily, currentSize - 3);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, currentSize - 3);

            // Увеличиваем ширину и высоту ячеек
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width -= 3;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height -= 3;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            if (!int.TryParse(textBox1.Text, out n) || n <= 0 || n > dataGridView1.Columns.Count)
            {
                MessageBox.Show("Пожалуйста, введите корректный номер столбца (от 1 до " + dataGridView1.Columns.Count + ").", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int lastPositiveColumnIndex = FindLastPositiveColumn();
            if (lastPositiveColumnIndex != -1 && lastPositiveColumnIndex < dataGridView1.Columns.Count)
            {
                try
                {
                    SwapColumns(n - 1, lastPositiveColumnIndex); // Уменьшаем индекс на 1, так как индексы в DataGridView начинаются с 0
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при обмене столбцов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private int FindLastPositiveColumn()
        {
            for (int i = dataGridView1.Columns.Count - 1; i >= 0; i--)
            {
                bool allPositive = true;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCell cell = row.Cells[i];
                    if (cell.Value != null && Convert.ToDouble(cell.Value) <= 0)
                    {
                        allPositive = false;
                        break;
                    }
                }

                if (allPositive)
                {
                    return i;
                }
            }

            return -1; // Если нет столбцов с только положительными элементами
        }

        private void SwapColumns(int column1Index, int column2Index)
        {
            // Создаем списки для хранения значений
            List<object> values1 = new List<object>();
            List<object> values2 = new List<object>();

            // Заполняем списки значениями из первых двух столбцов
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                values1.Add(dataGridView1.Rows[i].Cells[column1Index].Value);
                values2.Add(dataGridView1.Rows[i].Cells[column2Index].Value);
            }

            // Обмениваем значения между списками
            

            // Заменяем значения в ячейках
            for (int i = 0; i < values1.Count; i++)
            {
                if (values1[i] != null)
                {
                    dataGridView1.Rows[i].Cells[column1Index].Value = values2[i];
                }
            }

            for (int i = 0; i < values2.Count; i++)
            {
                if (values2[i] != null)
                {
                    dataGridView1.Rows[i].Cells[column2Index].Value = values1[i];
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void task13Button_Click(object sender, EventArgs e)
        {
            // Проверяем, что матрица создана
            if (dataGridView1.Rows.Count == 0 || dataGridView1.Columns.Count == 0)
            {
                MessageBox.Show("Матрица не была создана. Пожалуйста, создайте матрицу с помощью кнопки \"Создать матрицу\".", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получаем количество строк из DataGridView
            int m = dataGridView1.Rows.Count;

            // Проверяем ввод K
            int k;
            while (!int.TryParse(textBox1.Text, out k) || k < 1 || k > m)
            {
                MessageBox.Show("Пожалуйста, введите корректное значение K (от 1 до " + m + ").", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            // Получаем значения из K-й строки
            string[] rowValues = new string[m];
            for (int i = 0; i < m; i++)
            {
                rowValues[i] = dataGridView1.Rows[k - 1].Cells[i].Value?.ToString() ?? "";
            }

            // Выводим элементы K-й строки
            string result = string.Join(", ", rowValues);

            completeTextBox.Text = result ;

            
        }
    }
}
