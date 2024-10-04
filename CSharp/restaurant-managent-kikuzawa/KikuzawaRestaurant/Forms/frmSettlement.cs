using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KikuzawaRestaurant.Form_View;
using KikuzawaRestaurant.Classes;
using System.Data.SqlClient;
namespace KikuzawaRestaurant.Forms
{
    public partial class frmSettlement : Form
    {
        public frmSettlement()
        {
            InitializeComponent();
        }


        clsSelect selectClass;
        clsInsert insertClass;
        clsUpdate updateClass;
        clsdelete deleteClass;
        double AmtPay, RateConvert, changeDue;
        double parseAmt, parseRateConvert;
        clsView viewClass = new clsView();
        frmViewOrderSettlement fvos = new frmViewOrderSettlement();
        frmReceiptPreview rcs;
        public string getCashierName;
        public string KOTnum;
        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmSettlement_Load(object sender, EventArgs e)
        {
            selectClass = new clsSelect();

            //get the methods from the select class
            selectClass.addCurrencyToComboBox(cboSelectCurrency);
            selectClass.addCurrencyToComboBox(cboPOSCurrency);
            selectClass.selectCurrencyUsedToComboBox(cboPaymentType);
            selectClass.selectCurrencyUsedFromLabel(lblCurcsonvertFrom, "Inused");
            selectClass.addElectronicCurrencyToComboBox(posEelectronicType);
            selectClass.selectCurrencyUsedToLabel(lblConverTo, cboSelectCurrency);


            selectClass.selectInitialCurrencyUsedToComboBox(cboSelectCurrency);

            selectClass.selectCurrencyUsedFromLabel(lblUsedCurrency, "Inused");

            lblGetSymbol.Text = lblcustCurrency.Text;
            lblUsedCurr.Text = lblUsedCurrency.Text;
           btnCashout.Enabled = false;
        }

        private void cboSelectCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectClass = new clsSelect();
            selectClass.selectCurrencyUsedToLabel(lblConverTo, cboSelectCurrency);

            //selectClass.selectCurrencyUsedToLabel(lblcustCurrency, cboSelectCurrency);
            lblcustCurrency.Text = cboSelectCurrency.Text;
            lblCurcsonvertFrom.Text = lblcustCurrency.Text;
            lblGetSymbol.Text = lblcustCurrency.Text;
            label15.Text = lblcustCurrency.Text;
            lblUsedCurr.Text = lblUsedCurrency.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            valAccName(txtAcctName);
            valAccNum(txtAcctNum);
            if (clsInsert.err.GetError(txtAcctName).Length != 0)
            {
                clsInsert.err.SetIconAlignment(txtAcctName, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtAcctName, "Field can\'t be empty");
                return;
            
            }
            else if (clsInsert.err.GetError(txtAcctNum).Length != 0)
            {
                clsInsert.err.SetIconAlignment(txtAcctNum, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtAcctNum, "Field is either empty or text length is less than 13");
                return;

            }

            else
            {

                insertClass = new clsInsert();
                string cashier = selectClass.getEmployeeByID(getCashierName);
                MessageBox.Show(KOTnum);
                insertClass.insertTodetailsSettlement(txtReceiptNum.Text, dateTimePicker1, dateTimePicker1, lblUsedCurrency.Text, double.Parse(txtCustOwes.Text), cboPOSCurrency, double.Parse(txtPosPaid.Text), 0.0, "POS", txtAcctName.Text, txtAcctNum.Text, posEelectronicType.SelectedItem.ToString(), cashier);
                POSupdateBillAndSettlement("PAID");
                this.Close();
            }
        }

        private void txtCustOwes_TextChanged(object sender, EventArgs e)
        {
            txtBill.Text = txtCustOwes.Text;
        }

        private void txtAmtPAid_TextChanged(object sender, EventArgs e)
        {

            //Lets first test to make sure the input and rate is of a number character
            AmtPay = double.TryParse(txtAmtPAid.Text, out parseAmt) ? parseAmt : double.Parse("0");
            RateConvert = double.TryParse(lblConverTo.Text, out parseRateConvert) ? parseRateConvert : double.Parse("0");

            txtAmtToPay.Text = txtAmtPAid.Text;
            txtRateTimesAmtPaid.Text = (AmtPay * RateConvert).ToString();

            valAmtPaid((Control)sender);
        }

        private void txtReceiptNum_TextChanged(object sender, EventArgs e)
        {
            txtReceiptNo.Text = txtReceiptNum.Text;
        }

        double ComputePayment()
        {

            //Lets first test to make sure the input and rate is of a number character
            AmtPay = double.TryParse(txtAmtPAid.Text, out parseAmt) ? parseAmt : double.Parse("0");
            RateConvert = double.TryParse(lblConverTo.Text, out parseRateConvert) ? parseRateConvert : double.Parse("0");

            //customer payement - customer owes

            changeDue = (AmtPay * RateConvert) - double.Parse(txtCustOwes.Text);

            return changeDue;

        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            deleteClass = new clsdelete();
            if (voidID == "")
            {
                MessageBox.Show("Please click to select a row to void", "Help - Kikuzawa...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Font myFont = new Font("Sans Serif", 8, FontStyle.Strikeout, GraphicsUnit.Point);
            dataGridView1.Rows[0].Cells[0].Style.Font = myFont;
            dataGridView1.Rows[0].Cells[1].Style.Font = myFont;
            dataGridView1.Rows[0].Cells[2].Style.Font = myFont;
            dataGridView1.Rows[0].Cells[3].Style.Font = myFont;
            deleteClass.deleteDetailsSettlementByID(voidID);//this is the id used to void the specific kot
            POSupdateBillAndSettlement("UNPAID");
           
        }

        private void btnCashout_Click(object sender, EventArgs e)
        {
            updateClass = new clsUpdate();
            insertClass = new clsInsert();
           
            frmPopupChange popChange = new frmPopupChange();

            popChange.label3.Text = string.Format("{0:n2}", double.Parse(ComputePayment().ToString()));
            popChange.ShowDialog();
            string cashier = selectClass.getEmployeeByID(getCashierName);
             insertClass.insertTodetailsSettlement(txtReceiptNum.Text,dateTimePicker1,dateTimePicker1,lblUsedCurrency.Text,double.Parse(txtCustOwes.Text),cboSelectCurrency,double.Parse(txtAmtPAid.Text),changeDue,"Cash", "-","-","-",cashier);
            
            updateClass.updateBillAndSettlement(this.txtReceiptNum.Text, "PAID");

            this.Close();

        }

        void valAmtPaid(Control ctrl)
        {
            ErrorProvider err = new ErrorProvider();
            double amt;
            if ((txtAmtPAid.Text.Length > 0) && (double.TryParse(txtAmtPAid.Text, out amt) == true))
            {
                btnCashout.Enabled = true;

            }
            else
            {
                btnCashout.Enabled = false;
            }
        }



        void valAmtPOSPaid(Control ctrl)
        {

            double amt;
            if ((txtPosPaid.Text.Trim().Length > 0) && (double.TryParse(txtPosPaid.Text, out amt) == true))
            {
                btnPosPaid.Enabled = true;

            }
            else
            {
                btnPosPaid.Enabled = false;
            }
        }

        private void txtAmtPAid_Leave(object sender, EventArgs e)
        {
            valAmtPaid((Control)sender);
        }

        private void txtPosPaid_TextChanged(object sender, EventArgs e)
        {
            valAmtPOSPaid((Control)sender);
        }

        private void txtPosPaid_Leave(object sender, EventArgs e)
        {
            valAmtPOSPaid((Control)sender);
        }

        private void cboPOSCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            posCurChoice.Text = cboPOSCurrency.SelectedItem.ToString();
        }

        //ACCT NAME
        void valAccName(Control ctrl)
        {
            if (txtAcctName.Text.Trim().Length > 0)
            {
                clsInsert.err.SetError(txtAcctName, string.Empty);

            }
            else
            {
                clsInsert.err.SetIconAlignment(txtAcctName, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtAcctName, "Field can\'t be empty");
                return;
            }

        }
        void valAccNum(Control ctrl)
        {
            double num;
            if ((txtAcctNum.Text.Trim().Length == 13) && double.TryParse(txtAcctNum.Text,out num)==true && !txtAcctNum.Text.Contains("."))
            {
                
                clsInsert.err.SetError(txtAcctNum, string.Empty);

            }
            else
            {
                clsInsert.err.SetIconAlignment(txtAcctNum, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtAcctNum, "Field is either empty or text length is less than 13");
                return;
            }

        }

        private void txtAcctNum_TextChanged(object sender, EventArgs e)
        {
            valAccNum((Control)sender);
        }

        private void txtAcctNum_Leave(object sender, EventArgs e)
        {
            valAccNum((Control)sender);
        }

        private void txtAcctName_TextChanged(object sender, EventArgs e)
        {
            valAccName((Control)sender);
        }

        private void txtAcctName_Leave(object sender, EventArgs e)
        {
            valAccName((Control)sender);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
           viewClass.viewBillTransaction(dataGridView1, txtReceiptNum.Text.Trim());
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }


        //UPDATE THE BILL AND SETTLEMENT TABLE
        
       void POSupdateBillAndSettlement(string mode)
        {

            try
            {
                //getting field members from select class
               selectClass.con = new SqlConnection(selectClass.dbPath);
              selectClass.con.Open();
                string updateString = "update billAndSettlement set mode=@mode where kot='" + txtReceiptNo.Text.TrimEnd() + "'";
                selectClass.cmd = new SqlCommand(updateString, selectClass.con);
                selectClass.cmd.Parameters.AddWithValue("@mode", mode.Trim());

               selectClass.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }
        string voidID = "";
      private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
      {
          if (e.RowIndex >= 0)
          {
              DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

              voidID = row.Cells[0].Value.ToString();
          }
      }

    }
}
