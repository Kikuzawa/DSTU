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
    public partial class frmVTaxSales : Form
    {
        public frmVTaxSales()
        {
            InitializeComponent();
        }

        private void frmVTaxSales_Load(object sender, EventArgs e)
        {
            clsView viewClass = new clsView();
            viewClass.viewTaxSales(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
