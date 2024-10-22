using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Laboratory2
{



    public partial class Form1 : Form
    {
        FileInfo FilePath;


        Queue<HuffmanNode> queueTempNodes = new Queue<HuffmanNode>();

        List<HuffmanNode> listTempOrderedNodes = new List<HuffmanNode>();

        List<HuffmanNode> listFixedNodes = new List<HuffmanNode>();

        List<EncodedChar> listBinary = new List<EncodedChar>();



        public Form1()
        {
            InitializeComponent();
            
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
            if (fileNameDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = Path.Combine(fileNameDialog.FileName);

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
            if (fileNameDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = Path.Combine(fileNameDialog.FileName);

            }

            saveTextBoxHaffCode.Text = filePath;
        }

        private void ButtonHaffCode_Click(object sender, EventArgs e)
        {


            Huffman_tree_and_log();



        }

        private void Huffman_tree_and_log()
        {
            string inputText;
            using (StreamReader reader = new StreamReader(loadTextBox.Text))
            {
                inputText = reader.ReadToEnd();
            }

            listTempOrderedNodes.Clear();
            queueTempNodes.Clear();
            listFixedNodes.Clear();
            listBinary.Clear();
            listBoxNodeList.Items.Clear();

            string input = inputText;
            while (input != "")
            {
                string txt = input.Substring(0, 1);
                input = input.Remove(0, 1);

                if (listTempOrderedNodes.Count > 0)
                {
                    bool valid = false;
                    for (int i = 0; i < listTempOrderedNodes.Count; i++)
                    {
                        if (listTempOrderedNodes[i].NodeString == txt)
                        {
                            listTempOrderedNodes[i].Frequency += 1;
                            valid = true;
                            break;
                        }
                    }
                    if (!valid) NewNode(txt);
                }
                else NewNode(txt);
            }

            RefreshOrder();


            while (queueTempNodes.Count > 1)
            {
                HuffmanNode leftNode = queueTempNodes.Dequeue();
                HuffmanNode rightNode = queueTempNodes.Dequeue();
                HuffmanNode newParent = new HuffmanNode();
                newParent.NodeString = leftNode.NodeString + rightNode.NodeString;
                newParent.Frequency = leftNode.Frequency + rightNode.Frequency;
                newParent.Left = leftNode;
                newParent.Right = rightNode;
                queueTempNodes.Enqueue(newParent);
                listFixedNodes.Add(newParent);
                RefreshOrder();
            }

            dataGridViewEncodedChars.Rows.Clear();

            for (int i = 0; i < listFixedNodes.Count; i++)
            {
                listBoxNodeList.Items.Add("Node\t\t: " + listFixedNodes[i].NodeString);
                listBoxNodeList.Items.Add("Frequency\t: " + listFixedNodes[i].Frequency);

                if (listFixedNodes[i].Left != null) listBoxNodeList.Items.Add("Left\t\t: " + listFixedNodes[i].Left.NodeString);
                else listBoxNodeList.Items.Add("Left\t\t: " + "Null");
                if (listFixedNodes[i].Right != null) listBoxNodeList.Items.Add("Right\t\t: " + listFixedNodes[i].Right.NodeString);
                else listBoxNodeList.Items.Add("Right\t\t: " + "Null");

                listBoxNodeList.Items.Add("");

                if (listFixedNodes[i].NodeString.Length == 1)
                {
                    EncodedChar en = new EncodedChar();
                    en.Character = listFixedNodes[i].NodeString;
                    en.Binary = AnalyzeBinary(en.Character, listFixedNodes[listFixedNodes.Count - 1]);
                    listBinary.Add(en);
                    dataGridViewEncodedChars.Rows.Add(en.Character, en.Binary);
                }
            }

            input = inputText;
            string output = "";
            while (input != "")
            {
                string txt = input.Substring(0, 1);
                input = input.Remove(0, 1);
                for (int i = 0; i < listBinary.Count; i++)
                {
                    if (listBinary[i].Character == txt) output = output + listBinary[i].Binary;
                }
            }

            textBoxOutput.Text = output;

            using (StreamWriter writer = new StreamWriter(saveTextBoxHaffCode.Text, false))
            {
                writer.Write(output);
            }




        }

        private void ButtonHaffDecode_Click(object sender, EventArgs e)
        {
            string fileName = saveTextBoxHaffDecode.Text;

            if (!fileName.Equals(""))
            {
                DecodeMethod();
            }
            else
            {
                MessageBox.Show("Ошибка, выберите файл для сохранения");
            }


        }




        private void dataGridHaffDecode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridHaffCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        public void RefreshOrder()
        {
            int value = 1;
            if (queueTempNodes.Count > 0)
            {
                listTempOrderedNodes.Clear();
                while (queueTempNodes.Count != 0) listTempOrderedNodes.Add(queueTempNodes.Dequeue());
            }
            while (queueTempNodes.Count < listTempOrderedNodes.Count)
            {
                for (int i = 0; i < listTempOrderedNodes.Count; i++)
                {
                    if (listTempOrderedNodes[i].Frequency == value) queueTempNodes.Enqueue(listTempOrderedNodes[i]);
                }
                value++;
            }
        }

        public void NewNode(string p)
        {
            HuffmanNode node = new HuffmanNode();
            node.NodeString = p;
            node.Frequency = 1;
            node.Left = null;
            node.Right = null;
            listFixedNodes.Add(node);
            listTempOrderedNodes.Add(node);
        }

        public string AnalyzeBinary(string txt, HuffmanNode parent)
        {
            HuffmanNode helper = parent;
            string returnValue = "";
            bool valid = true;
            while ((helper.Left != null || helper.Right != null) && valid)
            {
                if (helper.Left.NodeString.Contains(txt))
                {
                    helper = helper.Left; valid = true; returnValue = returnValue + "0";
                }
                else if (helper.Right.NodeString.Contains(txt))
                {
                    helper = helper.Right; valid = true; returnValue = returnValue + "1";
                }
                else valid = false;
            }
            if (valid) return returnValue;
            else return "error";
        }

        public void DecodeMethod()
        {
            if (listFixedNodes.Count > 0)
            {
                string input;
                using (StreamReader reader = new StreamReader(loadTextBox.Text))
                {
                    input = reader.ReadToEnd();
                }

                string output = "";
                HuffmanNode root = new HuffmanNode();
                for (int i = 0; i < listFixedNodes.Count; i++)
                {
                    if (root.NodeString.Length < listFixedNodes[i].NodeString.Length) root = listFixedNodes[i];
                }
                int repetition = input.Length;
                bool finished = false;
                HuffmanNode helper = new HuffmanNode();
                helper = root;
                for (int j = 0; j < repetition; j++)
                {
                    finished = false;
                    string biner = "";
                    if (input != "") biner = input.Substring(0, 1);
                    if (biner == "0" && helper.Left != null)
                    {
                        helper = helper.Left;
                        input = input.Remove(0, 1);
                    }
                    else if (biner == "1" && helper.Right != null)
                    {
                        helper = helper.Right;
                        input = input.Remove(0, 1);
                    }
                    if (helper.Left == null && helper.Right == null)
                    {
                        output = output + helper.NodeString;
                        helper = root;
                        finished = true;
                    }
                }
                if (finished)
                {
                    textBoxOutput.Text = output;
                    using (StreamWriter writer = new StreamWriter(saveTextBoxHaffDecode.Text, false))
                    {
                        writer.Write(output);
                    }
                }
                else
                {
                    textBoxOutput.Text = "Unknown binary sequence detected. Make sure you've inputed the correct binary sequence according to the tree."
                        + "\n\n" + "Please note that binary numbers consists only number 0 and or 1";
                }
            }
            else
            {
                textBoxOutput.Text = "Please encode something to make the HuffmanTree for decoding process...";
            }
        }

        private void textBoxOutput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
