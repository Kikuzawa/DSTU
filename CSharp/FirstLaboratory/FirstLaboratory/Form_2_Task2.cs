using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstLaboratory
{
    public partial class Form_2_Task2 : Form
    {
        private Form Form1;
        private Button button1;
        public Form_2_Task2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.MouseMove += new MouseEventHandler(Form_MouseMove);
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

       
       private void Form_2_Task2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;

            System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
            myPath.AddPolygon(new Point[] {
        new Point(this.Width / 2, 0),
        new Point(this.Width, this.Height / 2),
        new Point(this.Width / 2, this.Height),
        new Point(0, this.Height / 2)
    });

            Region myRegion = new Region(myPath);
            this.Region = myRegion;
            this.BackColor = Color.Green;

            if (button1 != null)
            {
                button1.Location = new Point((this.Width - button1.Width) / 2, (this.Height - button1.Height) / 2);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1 == null || Form1.IsDisposed)
                Form1 = new Form1();

            Form1.Show();
            this.Close();
        }
    }
}
