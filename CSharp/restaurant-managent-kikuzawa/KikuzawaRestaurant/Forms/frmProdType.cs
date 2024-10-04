using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using KikuzawaRestaurant.Classes;
namespace KikuzawaRestaurant.Forms
{
    public partial class frmProdType : Form
    {
        public frmProdType()
        {
            InitializeComponent();
        }
        clsInsert insertClass = new clsInsert();

        //RESET CONTROL TO ITS FORMER STATE
        void _setInitialState()
        {
            cboProductTypeName.SelectedIndex = 0;
            txtCategory.ResetText();
        }


        //THIS FORM HELPS TO CREATE PRODUCT
        //e.g  WIN, SOFT DRINK,MAIN DISH
        void valProduct(Control ctrl)
        {
            if (txtCategory.Text.Trim().Length > 0)
            {
                clsInsert.err.SetError(txtCategory, string.Empty);
            }
            else
            {
                clsInsert.err.SetIconAlignment(txtCategory, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtCategory, "Please enter product type");
                return;

            }

        }

        //let user select food beverage
        void ValCategory(Control ctrl)
        {
            if (cboProductTypeName.SelectedIndex == 0)
            {
                clsSelect.err.SetIconAlignment(cboProductTypeName, ErrorIconAlignment.MiddleLeft);
                clsSelect.err.SetError(cboProductTypeName, "Please select category");
                return;
            }
            else
            {

                clsSelect.err.SetError(cboProductTypeName, string.Empty);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            valProduct(txtCategory);
            ValCategory(cboProductTypeName);
            if (clsInsert.err.GetError(txtCategory).Length != 0)
            {
                clsInsert.err.SetIconAlignment(txtCategory, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtCategory, "Please enter product type");
                return;
            }
            else if (clsSelect.err.GetError(cboProductTypeName).Length != 0)
            {
                clsSelect.err.SetIconAlignment(cboProductTypeName, ErrorIconAlignment.MiddleLeft);
                clsSelect.err.SetError(cboProductTypeName, "Please select category");
                return;

            }
            else
            {
                _CheckProductExist();
            }

        }

        private void frmProdType_Load(object sender, EventArgs e)
        {
            _setInitialState();
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            valProduct((Control)sender);
        }

        private void txtCategory_Leave(object sender, EventArgs e)
        {
            valProduct((Control)sender);
        }

        private void cboProductTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValCategory((Control)sender);
        }

        private void cboProductTypeName_Leave(object sender, EventArgs e)
        {
            ValCategory((Control)sender);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //REMOVE DULPICATE
        public void _CheckProductExist()
        {
            try
            {

                SqlConnection con = new SqlConnection(insertClass.dbPath);

                string sql = "select proSubCate from tblProType  where proSubCate = @proSubCate";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@proSubCate", txtCategory.Text.Trim());

                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;

                //If count is equal to 1
                //meaning user already exist
                if (count == 1)
                {
                    MessageBox.Show("Menu Subgroup Already Exist", "Help - Kikuzawa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    //PERFORM INSERT
                    insertClass.insertToProType(cboProductTypeName, txtCategory.Text);
                    _setInitialState();
                }

            }

            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

    }
}
