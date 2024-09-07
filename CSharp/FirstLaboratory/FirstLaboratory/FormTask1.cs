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
    public partial class FormTask1 : Form
    {
        private Form Form1;
        public FormTask1()
        {
            InitializeComponent();
        }

        private void FormTask1_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myPath = new
System.Drawing.Drawing2D.GraphicsPath();
            myPath.AddEllipse(0, 0, this.Width, this.Height);

            Region myRegion = new Region(myPath); this.Region = myRegion;
        }

        private void BtnCloseForm_Click(object sender, EventArgs e)
        {

            if (Form1 == null || Form1.IsDisposed)
                Form1 = new Form1();

            Form1.Show();
            this.Close();

        }
    }
}
