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
    public partial class ufrmCurrency : Form
    {
        public ufrmCurrency()
        {
            InitializeComponent();
        }

        clsSelect selectClass = new clsSelect();
        clsUpdate updClass = new clsUpdate();
        string chekState; //findout the statue of currency
        double exRate;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //IF USERS IGNORES THE WARNING AND PRESSES THIS BUTTON
            //RAISE THE WARNING AGAIN

            valCurName(txtCurrName);
            valCurSymbol(txtCurSymbol);
            valRates(txtExchangeRate);
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
            else if (clsInsert.err.GetError(txtExchangeRate).Length != 0)
            {
                clsInsert.err.SetIconAlignment(txtExchangeRate, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtExchangeRate, "Please enter numeric value");
                return;

            }

            else
            {
               
                
                searchCurrencyTableForStatuesAndRate();
            
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


        void valRates(Control ctrl)
        {
            double num;
            if (txtExchangeRate.Text.Trim().Length > 0 && double.TryParse(txtExchangeRate.Text,out num)==true)
            {
                clsInsert.err.SetError(txtExchangeRate, string.Empty);
            }
            else
            {
                clsInsert.err.SetIconAlignment(txtExchangeRate, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtExchangeRate, "Please enter numeric value");
                return;

            }

        }
        private void txtCurrName_TextChanged(object sender, EventArgs e)
        {
            valCurName((Control)sender);
        }

        private void txtCurSymbol_TextChanged(object sender, EventArgs e)
        {
            valCurSymbol((Control)sender);
        }

        private void txtCurSymbol_Leave(object sender, EventArgs e)
        {
            valCurSymbol((Control)sender);
        }

        private void txtCurrName_Leave(object sender, EventArgs e)
        {
            valCurName((Control)sender);
        }

        private void txtExchangeRate_TextChanged(object sender, EventArgs e)
        {
            valRates((Control)sender);
        }

        private void txtExchangeRate_Leave(object sender, EventArgs e)
        {
            valRates((Control)sender);
        }

        private void ufrmCurrency_Load(object sender, EventArgs e)
        {
            chkSetDefault.Checked = false;
        }

        void searchCurrencyTableForStatuesAndRate() {

            bool statIsFound = false;
            if (chkSetDefault.Checked) {
                try
                {

                        selectClass.con = new SqlConnection(selectClass.dbPath);
                        selectClass.con.Open();
                        string sql = "select Statues,convertAmt from tblCurrency where Statues=@Statues";
                        SqlCommand cmd = new SqlCommand(sql, selectClass.con);
                        cmd.Parameters.AddWithValue("@Statues", "Inused");
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            chekState = reader[0].ToString();
                            exRate = double.Parse(reader[1].ToString());
                            statIsFound = true;

                        }
                        
                    
                        reader.Close();
                        selectClass.con.Close();
               }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                /*The logic behind this condition is that
                 * first it will search for a default currency used
                 * when it finds it, the statues will be change to none
                 * and the rate will be set to 0
                */
                if (statIsFound)
                {
                    //first
                    try
                    {
                        selectClass.con = new System.Data.SqlClient.SqlConnection(selectClass.dbPath);
                        selectClass.con.Open();
                        string updateString = "update tblCurrency set convertAmt=@convertAmt,Statues=@Statues where Statues='Inused'";
                        selectClass.cmd = new System.Data.SqlClient.SqlCommand(updateString, selectClass.con);

                        selectClass.cmd.Parameters.AddWithValue("@Statues", "");
                        selectClass.cmd.Parameters.AddWithValue("@convertAmt", 0);
                        selectClass.cmd.ExecuteNonQuery();
                       // MessageBox.Show("Currency successfully updated", "Update - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    finally
                    {
                        selectClass.con.Close();
                    }


                    //second
                    try
                    {
                       selectClass. con = new System.Data.SqlClient.SqlConnection(selectClass. dbPath);
                       selectClass. con.Open();
                       string updateString = "update tblCurrency set CurName=@CurName,curSymbol=@curSymbol,convertAmt=@convertAmt,Statues=@Statues where curID=@curID";
                       selectClass.cmd = new System.Data.SqlClient.SqlCommand(updateString, selectClass.con);

                       selectClass.cmd.Parameters.AddWithValue("@CurName", txtCurrName.Text.Trim());
                       selectClass.cmd.Parameters.AddWithValue("@curSymbol", txtCurSymbol.Text.Trim());
                       selectClass.cmd.Parameters.AddWithValue("@convertAmt", 1);//default is same local currency note =  same local currency note
                       selectClass.cmd.Parameters.AddWithValue("@Statues", "Inused");
                       selectClass.cmd.Parameters.AddWithValue("@curID",txtID.Text);

                       selectClass.cmd.ExecuteNonQuery();
                        MessageBox.Show("Currency successfully updated", "Update - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    finally
                    {
                       selectClass. con.Close();
                    }

                    
                }
            } 
                
                //when the set default statues is not check just do the regular update

                else if (!chkSetDefault.Checked)
                {

                   updClass.updateCurrency(txtCurrName.Text, char.Parse(txtCurSymbol.Text.Trim()),double.Parse(txtExchangeRate.Text), int.Parse(txtID.Text));
                   
                }
                
        }

        private void chkSetDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSetDefault.Checked)
            {
                txtExchangeRate.ResetText();
                txtExchangeRate.Text = "1";
                txtExchangeRate.ReadOnly = true;
            }
            else {
                txtExchangeRate.ResetText();
                txtExchangeRate.ReadOnly = false;
            
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
