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
    public partial class Form1 : Form
    { 

        private Form FormTask1;
        private Form Form_1_Task2;
        private Form FormTask3;

        public Form1()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.MouseMove += new MouseEventHandler(Form_MouseMove);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FormTask1 == null || FormTask1.IsDisposed)
                FormTask1 = new FormTask1();

            FormTask1.Show();
            this.Hide();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }


        private void BtnTask2_Click(object sender, EventArgs e)
        {
            if (Form_1_Task2 == null || Form_1_Task2.IsDisposed)
                Form_1_Task2 = new Form_1_Task2();

            Form_1_Task2.Show();
            this.Hide();
        }

        private void BtnTask3_Click(object sender, EventArgs e)
        {
            if (FormTask3 == null || FormTask3.IsDisposed)
                FormTask3 = new FormTask3();

            FormTask3.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        private Point mouseOffset;

        

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            mouseOffset = new Point(-e.X, -e.Y);
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }
    }
}
