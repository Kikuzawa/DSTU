using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KikuzawaRestaurant.Folder_Updates;
using KikuzawaRestaurant.Classes;
namespace KikuzawaRestaurant.Form_View
{
    public partial class frmViewTax : Form
    {
        public frmViewTax()
        {
            InitializeComponent();
        }
        clsSelect selectClass;
        private void button1_Click(object sender, EventArgs e)
        {
            //instantiate the tax form
            frmUpdateTax updateTax = new frmUpdateTax();
            updateTax.ShowDialog();

            //function as fresh
            selectClass = new clsSelect();
            selectClass.selectTAx(dataGridView1);
        }

        private void frmViewTax_Load(object sender, EventArgs e)
        {
            selectClass = new clsSelect();
            selectClass.selectTAx(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
