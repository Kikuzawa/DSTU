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
    public partial class frmViewEmployees : Form
    {
        public frmViewEmployees()
        {
            InitializeComponent();
        }
        public Label getIDs = new Label();

        clsView viewClass = new clsView();
        private void frmViewEmployees_Load(object sender, EventArgs e)
        {
            
            viewClass.viewEmployee(dataGridView1);
            textBox1.Text = dataGridView1.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                viewClass.selectImageFromEmployee(row.Cells[0].Value.ToString(), pictureBox1);
                //concartenate firstname lastname and othername and in between set an empty space
                groupBox2.Text = row.Cells[1].Value.ToString() + "'s Image";
                txtFullname.Text = row.Cells[1].Value.ToString() + " " + row.Cells[2].Value.ToString() + " " + row.Cells[3].Value.ToString();
                txtResidence.Text = row.Cells[7].Value.ToString();
                txtEmail.Text = row.Cells[8].Value.ToString();

                //since the first column holds the id
                //we will assign the the label to the first column of the grid
                getIDs.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtSearcshFname.Text.Trim().Length > 0)
            {
                viewClass.searcshEmployeeByFirstName(txtSearcshFname.Text, dataGridView1);

            }
            else
            {

                //recall this method
                viewClass.viewEmployee(dataGridView1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text.Trim().Equals(""))
            {
                MessageBox.Show("please select an employee", "SAVED - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //instantiating the update employee form class
            ufrmEmployee updateEmpForm = new ufrmEmployee();
            updateEmpForm.textBox1.Text = getIDs.Text.Trim();

            updateEmpForm.ShowDialog();

            // refresh datagrid
            viewClass.viewEmployee(dataGridView1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text.Trim().Equals(""))
            {
                MessageBox.Show("please select an employee", "SAVED - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            clsdelete delly = new clsdelete();
            delly.deleteEmployee(getIDs.Text);
        }
    }
}
