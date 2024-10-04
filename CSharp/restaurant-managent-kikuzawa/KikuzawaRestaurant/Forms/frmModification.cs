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
namespace KikuzawaRestaurant.Forms
{
    public partial class frmModification : Form
    {
        public string getEmpName;
        public frmModification()
        {
            InitializeComponent();
        }
       

        clsSelect selectClass = new clsSelect();
        public string getModApplyRate, getModApplyName;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[0];

            getModApplyRate = row.Cells[5].Value.ToString();
            getModApplyName = row.Cells[0].Value.ToString();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtApplyName.Text = row.Cells[0].Value.ToString();
                txtSubTotal.Text = row.Cells[1].Value.ToString();
                txtVat.Text = row.Cells[2].Value.ToString();
                txtTourLevy.Text = row.Cells[3].Value.ToString();
                txtTax3.Text = row.Cells[4].Value.ToString();
                txtApplyRate.Text = row.Cells[5].Value.ToString();
                txtTotal.Text = row.Cells[5].Value.ToString();

            }
        }


        private void btnApplyRate_Click(object sender, EventArgs e)
        {
            valApplyRate(txtApplyRate);

            if (clsSelect.err.GetError(txtApplyRate).Length != 0)
            {
                clsSelect.err.SetIconAlignment(txtApplyRate, ErrorIconAlignment.MiddleLeft);
                clsSelect.err.SetError(txtApplyRate, "Please numeric value");
                return;
            }
            else
            {
                DataGridViewRow row = this.dataGridView1.Rows[0];
                row.Cells[5].Value = txtApplyRate.Text;
            }
        }

        private void btnApplyName_Click(object sender, EventArgs e)
        {
            valApplyName(txtApplyName);

            if (clsSelect.err.GetError(txtApplyName).Length != 0)
            {
                clsSelect.err.SetIconAlignment(txtApplyName, ErrorIconAlignment.MiddleLeft);
                clsSelect.err.SetError(txtApplyName, "Please field can\'t be empty");
                return;
            }

           else
            {
                DataGridViewRow row = this.dataGridView1.Rows[0];
                row.Cells[0].Value = txtApplyName.Text;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            valApplyName(txtApplyName);
            valApplyRate(txtApplyRate);
            if (clsSelect.err.GetError(txtApplyName).Length != 0) {
                clsSelect.err.SetIconAlignment(txtApplyName, ErrorIconAlignment.MiddleLeft);
                clsSelect.err.SetError(txtApplyName, "Please field can\'t be empty");
                return;
            }
            else if (clsSelect.err.GetError(txtApplyRate).Length != 0)
            {
                clsSelect.err.SetIconAlignment(txtApplyRate, ErrorIconAlignment.MiddleLeft);
                clsSelect.err.SetError(txtApplyRate, "Please numeric value");
                return;
            }

            else { 
            
             DataGridViewRow row = this.dataGridView1.Rows[0];

            getModApplyRate = row.Cells[5].Value.ToString();
            getModApplyName = row.Cells[0].Value.ToString();
            this.Hide();
            }

           

        }


        void valApplyName(Control ctrl)
        {

            if (txtApplyName.Text.Trim().Length > 0)
            {
                clsSelect.err.SetIconAlignment(txtApplyName, ErrorIconAlignment.MiddleLeft);
                clsSelect.err.SetError(txtApplyName, string.Empty);

            }
            else
            {

                clsSelect.err.SetIconAlignment(txtApplyName, ErrorIconAlignment.MiddleLeft);
                clsSelect.err.SetError(txtApplyName, "Please field can\'t be empty");
                return;

            }



        }

        void valApplyRate(Control ctrl)
        {
            double num;
            if (txtApplyRate.Text.Trim().Length > 0 && double.TryParse(txtApplyRate.Text, out num))
            {
                clsSelect.err.SetIconAlignment(txtApplyRate, ErrorIconAlignment.MiddleLeft);
                clsSelect.err.SetError(txtApplyRate, string.Empty);

            }
            else
            {

                clsSelect.err.SetIconAlignment(txtApplyRate, ErrorIconAlignment.MiddleLeft);
                clsSelect.err.SetError(txtApplyRate, "Please numeric value");
                return;

            }

        }

        private void txtApplyName_TextChanged(object sender, EventArgs e)
        {
            valApplyName((Control)sender);
        }

        private void txtApplyRate_TextChanged(object sender, EventArgs e)
        {
            valApplyRate((Control)sender);
        }

        private void txtApplyRate_Leave(object sender, EventArgs e)
        {
            valApplyRate((Control)sender);
        }

        private void txtApplyName_Leave(object sender, EventArgs e)
        {
            valApplyName((Control)sender);
        }

        private void frmModification_FormClosing(object sender, FormClosingEventArgs e)
        {
            
               
        }

        private void frmModification_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
