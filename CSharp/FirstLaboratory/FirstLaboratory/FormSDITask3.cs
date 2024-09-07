using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FirstLaboratory
{
    public partial class FormSDITask3 : Form
    {
        private Button closeButton;
        private Form Form1;
        private Point mouseOffset;
        

        public FormSDITask3()
        {
            InitializeComponent();
            this.Text = "";
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow; // Удаление компонентов управления
            this.BackColor = Color.Black;
            this.ControlBox = false;

            

            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.MouseMove += new MouseEventHandler(Form_MouseMove);
           
        }

        private void FormSDITask3_Load(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            
        }

        

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

        private void closeBtn_Click(object sender, EventArgs e)
        {
            if (Form1 == null || Form1.IsDisposed)
                Form1 = new Form1();

            Form1.Show();
            this.Close();
        }
    }
    }
