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
    public partial class frmVNetSales : Form
    {
        public frmVNetSales()
        {
            InitializeComponent();
        }

        private void frmVNetSales_Load(object sender, EventArgs e)
        {
            clsView viewClass = new clsView();
            viewClass.viewNetSales(dataGridView1);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
