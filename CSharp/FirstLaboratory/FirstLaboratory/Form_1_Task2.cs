using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstLaboratory
{
    public partial class Form_1_Task2 : Form
    {
        private Form Form_2_Task2;
        private Form Form1;

        public Form_1_Task2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.ControlBox = false;
            this.Text = "Котелевец К.А, ВКБ31";
        }

        private void Form_1_Task2_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form_2_Task2 == null || Form_2_Task2.IsDisposed)
                Form_2_Task2 = new Form_2_Task2();

            Form_2_Task2.Show();
            this.Close();
        }

        private void BtnGoToForm1_Click(object sender, EventArgs e)
        {
            if (Form1 == null || Form1.IsDisposed)
                Form1 = new Form1();

            Form1.Show();
            this.Close();
        }
    }
}
