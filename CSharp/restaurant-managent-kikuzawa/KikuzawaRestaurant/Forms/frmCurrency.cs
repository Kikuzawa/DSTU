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
    public partial class frmCurrency : Form
    {
        public frmCurrency()
        {
            InitializeComponent();
        }
        clsInsert insertClass = new clsInsert();
        private void button2_Click(object sender, EventArgs e)
        {
            txtCurrName.ResetText();
            txtCurSymbol.ResetText();
            this.Close();
        }

        private void frmCurrency_Load(object sender, EventArgs e)
        {
            txtCurrName.ResetText();
            txtCurSymbol.ResetText();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //IF USERS IGNORES THE WARNING AND PRESSES THIS BUTTON
            //RAISE THE WARNING AGAIN

            valCurName(txtCurrName);
            valCurSymbol(txtCurSymbol);
            if (clsInsert.err.GetError(txtCurrName).Length != 0)
            {
                clsInsert.err.SetIconAlignment(txtCurrName, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtCurrName, "Please enter currency name");
                return;
            }
            else if (clsInsert.err.GetError(txtCurSymbol).Length != 0)
            {
                clsInsert.err.SetIconAlignment(txtCurSymbol, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtCurSymbol, "Please enter currency symbol");
                return;

            }
            else
            {
                _CheckCurrencyExist();
            }

        }

        //find out currency symbol exist
        // if such symbol exists reject insertion
        void _CheckCurrencyExist()
        {
            try
            {

                SqlConnection con = new SqlConnection(insertClass.dbPath);

                string sql = "select curSymbol from tblCurrency  where curSymbol = @curSymbol";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@curSymbol", txtCurSymbol.Text.Trim());

                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;

                //If count is equal to 1
                //meaning user already exist
                if (count == 1)
                {
                    MessageBox.Show("Currency Already Exist", "Save Data - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    //PERFORM INSERT
                    insertClass.insertToCurrency(txtCurrName.Text, char.Parse(txtCurSymbol.Text));
                    txtCurrName.ResetText();
                    txtCurSymbol.ResetText();

                }

            }

            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }



        void valCurName(Control ctrl)
        {
            if (txtCurrName.Text.Trim().Length > 0)
            {
                clsInsert.err.SetError(txtCurrName, string.Empty);
            }
            else
            {
                clsInsert.err.SetIconAlignment(txtCurrName, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtCurrName, "Please enter currency name");
                return;

            }

        }

        void valCurSymbol(Control ctrl)
        {
            if (txtCurSymbol.Text.Trim().Length > 0)
            {
                clsInsert.err.SetError(txtCurSymbol, string.Empty);
            }
            else
            {
                clsInsert.err.SetIconAlignment(txtCurSymbol, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtCurSymbol, "Please enter currency symbol");
                return;

            }

        }

        private void txtCurrName_TextChanged(object sender, EventArgs e)
        {
            valCurName((Control)sender);
        }

        private void txtCurSymbol_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCurrName_Leave(object sender, EventArgs e)
        {
            valCurName((Control)sender);
        }

        private void txtCurSymbol_Leave(object sender, EventArgs e)
        {
            valCurName((Control)sender);
        }
    }
}
