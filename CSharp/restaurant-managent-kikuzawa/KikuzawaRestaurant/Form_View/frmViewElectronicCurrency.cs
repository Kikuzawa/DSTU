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
using KikuzawaRestaurant.Folder_Updates;
namespace KikuzawaRestaurant.Form_View
{
    public partial class frmViewElectronicCurrency : Form
    {
        public frmViewElectronicCurrency()
        {
            InitializeComponent();
        }
        clsView viewClass = new clsView();
        Label getID = new Label();
        string elecName;

        private void frmViewElectronicCurrency_Load(object sender, EventArgs e)
        {
            viewClass.viewElectronicCurrency(dataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmUpElectronicCurrency updateElectronicCurr = new frmUpElectronicCurrency();
            if (getID.Text.Trim() == "")
            {
                MessageBox.Show("Please click to select name", "Help - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            updateElectronicCurr.txtID.Text = this.getID.Text;
            updateElectronicCurr.txtElecName.Text = elecName;
            updateElectronicCurr.ShowDialog();

            //set the value of getID to null
            getID.Text = "";
            viewClass.viewElectronicCurrency(dataGridView1);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                getID.Text = row.Cells[0].Value.ToString();
                elecName = row.Cells[1].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
