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
using System.Data.SqlClient;
namespace KikuzawaRestaurant.Folder_Updates
{
    public partial class frmUpProducts : Form
    {
        public frmUpProducts()
        {
            InitializeComponent();
        }
        public Label lblupProductID = new Label();
        clsUpdate updateClass = new clsUpdate();
        clsSelect selectClass = new clsSelect();
        ErrorProvider err = new ErrorProvider();
        private void frmUpProducts_Load(object sender, EventArgs e)
        {
           
       

        }
        /// <summary>
        /// pull details by id
        /// </summary>
        void selectDetails()
        {
            try
            {
                clsSelect selectClass = new clsSelect();

                string sql = "select proName,prodTypeName,proType, proDescrip,tax_1,tax_2,tax_3,proPrice, tax_1Amt,tax_2Amt,tax_3Amt, proNetPrice from tblProducts where Convert(varchar,prodID)='" + txtID.Text.Trim() + "'";
                SqlConnection con = new SqlConnection(selectClass.dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    txtProdName.Text = reader["proName"].ToString();
                    cboProductType.Text = reader["prodTypeName"].ToString();
                    cboProSubCate.Text = reader["proType"].ToString();
                    txtProdDecs.Text = reader["proDescrip"].ToString();
                    txtTax1percsentage.Text = reader["tax_1"].ToString();
                    txtTax2percsentage.Text = reader["tax_2"].ToString();
                    txtTax3percsentage.Text = reader["tax_3"].ToString();
                    txtProdPrice.Text = reader["proPrice"].ToString();
                    txtTax1Amt.Text = reader["tax_1Amt"].ToString();
                    txtTax2Amt.Text = reader["tax_2Amt"].ToString();
                    txtTax3Amt.Text = reader["tax_3Amt"].ToString();
                    txtNetAmt.Text = reader["proNetPrice"].ToString();


                }
                else
                {
                    txtID.Text = "";
                    txtProdName.Text = "";
                    //cboProductType.SelectedIndex = 0;
                  //  cboProSubCate.SelectedIndex = 0;
                    txtProdDecs.Text = "";
                    txtTax1percsentage.Text = "";
                    txtTax2percsentage.Text = "";
                    txtTax3percsentage.Text = "";
                    txtProdPrice.Text = "";
                    txtTax1Amt.Text = "";
                    txtTax2Amt.Text = "";
                    txtTax3Amt.Text = "";
                    txtNetAmt.Text = "";

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("The " + ex.Message);
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

        private void upProductID_TextChanged(object sender, EventArgs e)
        {
            
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
                //perform update
                updateClass.UpdateProductsTable(txtProdName.Text.Trim(), cboProductType, cboProSubCate, txtProdDecs.Text.Trim(), double.Parse(txtTax1percsentage.Text), double.Parse(txtTax2percsentage.Text), double.Parse(txtTax3percsentage.Text), double.Parse(txtProdPrice.Text), double.Parse(txtTax1Amt.Text), double.Parse(txtTax2Amt.Text), double.Parse(txtTax3Amt.Text), double.Parse(txtNetAmt.Text), int.Parse(txtID.Text));
       
            }

           
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            selectDetails();
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

        private void txtProdName_TextChanged(object sender, EventArgs e)
        {
            valProdName((Control)sender);
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

        private void txtProdName_Leave(object sender, EventArgs e)
        {
            valProdName((Control)sender);
        }

        private void txtProdPrice_Leave(object sender, EventArgs e)
        {
            valProdPrice((Control)sender);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
