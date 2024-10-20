using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Laboratory2
{



    public partial class Form1 : Form
    {
        BitReader bRead;
        BitWriter bWrite;
        Huffman huff;
        FileInfo FilePath;

        public Form1()
        {
            InitializeComponent();
            huff = new Huffman();
        }

        private void ButtonLoadFile_Click(object sender, EventArgs e)
        {
            var FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                FilePath = new FileInfo(FD.FileName);
            }
            loadTextBox.Text = FilePath.FullName;

        }

        private void ButtonSelectFolderHaff_Click1(object sender, EventArgs e)
        {
            OpenFileDialog fileNameDialog = new OpenFileDialog();


            fileNameDialog.Filter = "TXT файл (*.txt)|*.txt";
            fileNameDialog.Title = "Введите имя файла";
            fileNameDialog.CheckFileExists = false;

            fileNameDialog.DefaultExt = ".txt";
            fileNameDialog.FileName = "outputTXT.txt";
            fileNameDialog.AddExtension = true;
            string filePath = "C:\\decode.txt";

            // Открываем диалог выбора каталога

            // Если пользователь выбрал каталог, открываем диалог ввода имени файла
            if (fileNameDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = Path.Combine(fileNameDialog.FileName);

                // Здесь вы можете использовать filePath для сохранения файла

            }

            saveTextBoxHaffDecode.Text = filePath;

        }
        private void ButtonSelectFolderHaff_Click(object sender, EventArgs e)
        {

            OpenFileDialog fileNameDialog = new OpenFileDialog();


            fileNameDialog.Filter = "HS файл (*.hs)|*.hs";
            fileNameDialog.Title = "Введите имя файла";
            fileNameDialog.CheckFileExists = false;

            fileNameDialog.DefaultExt = ".hs";
            fileNameDialog.FileName = "outputHS.hs";
            fileNameDialog.AddExtension = true;
            string filePath = "C:\\code.hs";

            // Открываем диалог выбора каталога

            // Если пользователь выбрал каталог, открываем диалог ввода имени файла
            if (fileNameDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = Path.Combine(fileNameDialog.FileName);

                // Здесь вы можете использовать filePath для сохранения файла

            }

            saveTextBoxHaffCode.Text = filePath;
        }

        private void ButtonHaffCode_Click(object sender, EventArgs e)
        {

            string fileName = saveTextBoxHaffCode.Text;

            if (!fileName.Equals(""))
            {
                List<byte> inputList = new List<byte>();
                bRead = new BitReader(FilePath.FullName);
                long fileSize = 8 * new FileInfo(FilePath.FullName).Length;

                do
                {
                    int readBits = 8;
                    if (readBits > fileSize)
                    {
                        readBits = (int)fileSize;
                    }
                    uint value = bRead.ReadNBits(readBits);
                    inputList.Add(Convert.ToByte(value));
                    fileSize -= readBits;
                } while (fileSize > 0);

                bRead.Dispose();

                List<byte> huffCodes = huff.Encode(inputList.ToArray());

                var modelCharacters = huff.GetModel();

                // Создаем список для хранения данных
                List<CharacterCode> characterCodes = new List<CharacterCode>();

                // Преобразуем данные из SortedDictionary
                foreach (var kvp in modelCharacters)
                {
                    characterCodes.Add(new CharacterCode
                    {
                        Character = kvp.Key,
                        Codes = kvp.Value
                    });
                }

                // Очищаем DataGridView от предыдущих данных
                dataGridHaffCode.Rows.Clear();

                // Проверяем, есть ли столбцы в DataGridView
                if (dataGridHaffCode.Columns.Count == 0)
                {
                    // Добавляем столбцы программно
                    dataGridHaffCode.Columns.Add("Character", "Символ");
                    dataGridHaffCode.Columns.Add("Codes", "Коды");
                }

                // Заполняем DataGridView данными
                foreach (var code in characterCodes)
                {
                    dataGridHaffCode.Rows.Add(
                        code.Character,
                        string.Join(", ", code.Codes)
                    );
                }




                bWrite = new BitWriter(Path.Combine(FilePath.DirectoryName, fileName));

                var statistic = huff.GetStatistic();
                var sortedStatistic = new SortedDictionary<byte, int>(statistic);
                for (int i = 0; i <= 255; i++)
                {
                    if (sortedStatistic.ContainsKey((byte)i))
                        bWrite.WriteNBits(1, 1);
                    else
                        bWrite.WriteNBits(1, 0);
                }

                foreach (var item in sortedStatistic)
                {
                    bWrite.WriteNBits(8, (uint)item.Value);
                }

                foreach (var code in huffCodes)
                {
                    bWrite.WriteNBits(8, code);
                }

                bWrite.WriteNBits(7, 1);
                bWrite.Dispose();
            }
            else
            {
                MessageBox.Show("Ошибка, выберите файл для сохранения");
            }
        }

        private void ButtonHaffDecode_Click(object sender, EventArgs e)
        {
            string fileName = saveTextBoxHaffDecode.Text;

            if (!fileName.Equals(""))
            {
                bRead = new BitReader(FilePath.FullName);

                List<byte> statsList = new List<byte>();
                Dictionary<byte, int> statistic = new Dictionary<byte, int>();

                for (int i = 0; i < 256; i++)
                {
                    uint value = bRead.ReadNBits(1);
                    if (value == 1)
                        statsList.Add((byte)i);
                }

                int length = statsList.Count;
                for (int i = 0; i < length; i++)
                {
                    uint nr = bRead.ReadNBits(8);
                    statistic.Add(statsList[i], (int)nr);
                }

                List<byte> codedValues = new List<byte>();
                long fileSize = 8 * new FileInfo(FilePath.FullName).Length - (256 + (length * 8));

                do
                {
                    int readBits = 8;
                    if (readBits > fileSize)
                    {
                        readBits = (int)fileSize;
                    }
                    uint value = bRead.ReadNBits(readBits);
                    codedValues.Add(Convert.ToByte(value));
                    fileSize -= readBits;
                } while (fileSize > 0);

                bRead.Dispose();

                var decodedValues = huff.Decode(codedValues, statistic);

               
                    
                    bWrite = new BitWriter(Path.Combine(fileName));
                

                foreach (var item in decodedValues)
                {
                    bWrite.WriteNBits(8, item);
                }
                bWrite.Dispose();

            }
            else
            {
                MessageBox.Show("Ошибка, выберите файл для сохранения");
            }
        }

        private void dataGridHaffDecode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
