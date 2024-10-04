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
namespace KikuzawaRestaurant.Folder_Updates
{
    public partial class frmUpdateTax : Form
    {
        public frmUpdateTax()
        {
            InitializeComponent();
        }

        //instantiating clsUpdate

        clsUpdate updateClass = new clsUpdate();
        clsSelect selectClass = new clsSelect();

        private void frmUpdateTax_Load(object sender, EventArgs e)
        {
            selectClass.getTaxables();
            txtTax1.Text = selectClass.tax1.ToString();
            txtTax2.Text = selectClass.tax2.ToString();
            txtTax3.Text = selectClass.tax3.ToString();
        }


        void valTax_1(Control ctrl)
        {
            double isNumber;

            if (double.TryParse(txtTax1.Text, out isNumber))
            {

                clsInsert.err.SetError(txtTax1, string.Empty);

            }
            else
            {
                clsInsert.err.SetIconAlignment(txtTax1, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtTax1, "Please enter numberic value");
                return;

            }
        }

        void valTax_2(Control ctrl)
        {
            double isNumber;

            if (double.TryParse(txtTax2.Text, out isNumber))
            {

                clsInsert.err.SetError(txtTax2, string.Empty);

            }
            else
            {
                clsInsert.err.SetIconAlignment(txtTax2, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtTax2, "Please enter numberic value");
                return;

            }
        }

        void valTax_3(Control ctrl)
        {
            double isNumber;

            if (double.TryParse(txtTax3.Text, out isNumber))
            {

                clsInsert.err.SetError(txtTax3, string.Empty);

            }
            else
            {
                clsInsert.err.SetIconAlignment(txtTax3, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtTax3, "Please enter numberic value");
                return;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            valTax_1(txtTax1);
            valTax_2(txtTax2);
            valTax_3(txtTax3);

            if (clsInsert.err.GetError(txtTax1).Length != 0)
            {
                clsInsert.err.SetIconAlignment(txtTax1, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtTax1, "Please enter numberic value");
                return;

            }
            else if (clsInsert.err.GetError(txtTax2).Length != 0)
            {
                clsInsert.err.SetIconAlignment(txtTax2, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtTax2, "Please enter numberic value");
                return;

            }

            else if (clsInsert.err.GetError(txtTax3).Length != 0)
            {
                clsInsert.err.SetIconAlignment(txtTax3, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtTax3, "Please enter numberic value");
                return;

            }
            else
            {
                updateClass.updateTaxes(double.Parse(txtTax1.Text), double.Parse(txtTax2.Text), double.Parse(txtTax3.Text), 1);

            }
        }

        private void txtTax1_TextChanged(object sender, EventArgs e)
        {
            valTax_1((Control)sender);
        }

        private void txtTax1_Leave(object sender, EventArgs e)
        {
            valTax_1((Control)sender);
        }

        private void txtTax2_TextChanged(object sender, EventArgs e)
        {
            valTax_2((Control)sender);
        }

        private void txtTax2_Leave(object sender, EventArgs e)
        {
            valTax_2((Control)sender);
        }

        private void txtTax3_TextChanged(object sender, EventArgs e)
        {
            valTax_3((Control)sender);
        }

        private void txtTax3_Leave(object sender, EventArgs e)
        {
            valTax_3((Control)sender);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
