using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KikuzawaRestaurant.Classes;
namespace KikuzawaRestaurant.Form_View
{
    public partial class frmVFreezeItems : Form
    {
        public frmVFreezeItems()
        {
            InitializeComponent();
        }

        private void frmVFreezeItems_Load(object sender, EventArgs e)
        {
            clsView viewClass = new clsView();
            viewClass.viewFreezes(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
