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
    public partial class FormTask3 : Form
    {
        private Form FormSDITask3;
        public FormTask3()
        {
            InitializeComponent();
        }

        private void FormTask3_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FormSDITask3 == null || FormSDITask3.IsDisposed)
                FormSDITask3 = new FormSDITask3();

            FormSDITask3.Show();
            this.Close();
        }
    }
}
