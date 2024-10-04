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
    public partial class frmProductReg : Form
    {
        public frmProductReg()
        {
            InitializeComponent();
        }

        clsSelect selectClass = new clsSelect();
        clsInsert insertClass = new clsInsert();
        ErrorProvider err = new ErrorProvider();
        private void frmProductReg_Load(object sender, EventArgs e)
        {
            _setInitialState();
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

            notifyIcon1.BalloonTipText = "I am a NotifyIcon Balloon";

            notifyIcon1.BalloonTipTitle = "Welcome Message";



            notifyIcon1.ShowBalloonTip(1000);
        }

        //set Initial State of controls
        public void _setInitialState()
        {
            cboProductType.SelectedIndex = 0;
            selectClass.CallingProductCategory(cboProSubCate);

            selectClass.getTaxables();
            txtTax1percsentage.Text = selectClass.tax1.ToString();
            txtTax2percsentage.Text = selectClass.tax2.ToString();
            txtTax3percsentage.Text = selectClass.tax3.ToString();
            txtNetAmt.Text = 0.ToString();
            txtProdPrice.ResetText();

            txtTax1Amt.Text = 0.ToString();
            txtTax2Amt.Text = 0.ToString();
            txtTax3Amt.Text = 0.ToString();

            txtProdDecs.ResetText();
            txtProdName.ResetText();


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //continue to validate if user see the error and ignores it
            // the press the save button
            valProdName(txtProdName);
            valProdPrice(txtProdPrice);

            if (err.GetError(txtProdName).Length != 0)
            {
                err.SetIconAlignment(txtProdName, ErrorIconAlignment.MiddleLeft);
                err.SetError(txtProdName, "Field can't be empty");

            }
            else if (err.GetError(txtProdPrice).Length != 0)
            {
                err.SetIconAlignment(txtProdPrice, ErrorIconAlignment.MiddleLeft);
                err.SetError(txtProdPrice, "input not numeric");

            }
            else
            {

                if (cboProductType.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Type", "Selection Error - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //perform insertion and reset control
                insertClass.insertToProduct(txtProdName.Text, cboProductType, cboProSubCate, txtProdDecs.Text, double.Parse(txtTax1percsentage.Text), double.Parse(txtTax2percsentage.Text), double.Parse(txtTax3percsentage.Text), double.Parse(txtProdPrice.Text), double.Parse(txtTax1Amt.Text), double.Parse(txtTax2Amt.Text), double.Parse(txtTax3Amt.Text), double.Parse(txtNetAmt.Text));
                _setInitialState();
            }
        }


        //creating a method to validate control
        void valProdName(Control ctrl)
        {
            if (txtProdName.Text.Trim().Length > 0)
            {
                err.SetError(txtProdName, string.Empty);

            }
            else
            {

                err.SetIconAlignment(txtProdName, ErrorIconAlignment.MiddleLeft);
                err.SetError(txtProdName, "Field can't be empty");
            }

        }

        void valProdPrice(Control ctrl)
        {
            decimal number;

            if (decimal.TryParse(txtProdPrice.Text, out number))
            {
                err.SetError(txtProdPrice, string.Empty);

            }
            else
            {

                err.SetIconAlignment(txtProdPrice, ErrorIconAlignment.MiddleLeft);
                err.SetError(txtProdPrice, "input not numeric");
            }


        }

        private void cboProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboProSubCate.Items.Clear();
            switch (cboProductType.SelectedIndex)
            {
                case 1:
                    selectClass.comSelectBeverage(cboProSubCate);
                    break;
                case 2:
                    selectClass.comSelectFood(cboProSubCate);
                    break;
                default:
                    cboProSubCate.Items.Add("N/A");
                    cboProSubCate.SelectedIndex = 0;
                    break;

            }
        }

        private void txtProdPrice_TextChanged(object sender, EventArgs e)
        {
            valProdPrice((Control)sender);
            
            decimal prices;
            if ((txtProdPrice.Text.Length > 0) && decimal.TryParse(txtProdPrice.Text, out prices))
            {
                selectClass.calcTaxAmt(decimal.Parse(txtTax1percsentage.Text), decimal.Parse(txtTax2percsentage.Text), decimal.Parse(txtTax3percsentage.Text), decimal.Parse(txtProdPrice.Text));
                txtTax1Amt.Text = selectClass.tax1_Amt.ToString();
                txtTax2Amt.Text = selectClass.tax2_Amt.ToString();
                txtTax3Amt.Text = selectClass.tax3_Amt.ToString();
                txtNetAmt.Text = selectClass.netPrice.ToString();

            }

                //format to two decimal place

            else
            {

                txtTax1Amt.Text = string.Format("{0:n2}", 0);
                txtTax2Amt.Text = string.Format("{0:n2}", 0);
                txtTax3Amt.Text = string.Format("{0:n2}", 0);
                txtNetAmt.Text = string.Format("{0:n2}", 0);

            }
        }

        private void txtProdPrice_Leave(object sender, EventArgs e)
        {
            valProdPrice((Control)sender);
        }

        private void txtProdName_TextChanged(object sender, EventArgs e)
        {
            valProdName((Control)sender);
        }

        private void txtProdName_Leave(object sender, EventArgs e)
        {
            valProdName((Control)sender);
        }
    }
}
