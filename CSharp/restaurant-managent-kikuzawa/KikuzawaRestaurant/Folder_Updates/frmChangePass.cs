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
namespace KikuzawaRestaurant.Folder_Updates
{
    public partial class frmChangePass : Form
    {
        public frmChangePass()
        {
            InitializeComponent();
        }


        //Variables and instantiating classes
        ErrorProvider err = new ErrorProvider();
        clsInsert insertClass = new clsInsert();
        clsUpdate updateclass = new clsUpdate();
        public string getEmpName;


        //validate password
        void valPassword(Control ctrl)
        {
            if (txtPassword.Text.Trim().Length > 0)
            {
                err.SetError(txtPassword, string.Empty);
            }
            else
            {

                err.SetIconAlignment(txtPassword, ErrorIconAlignment.MiddleLeft);
                err.SetError(txtPassword, "Field can\'t be empty");
                return;
            }

        }


        //validate confirm password
        void valConfirmPassword(Control ctrl)
        {

            if (txtConfPass.Text.Trim().Length > 0)
            {
                err.SetError(txtConfPass, string.Empty);
            }
            else
            {
                err.SetIconAlignment(txtConfPass, ErrorIconAlignment.MiddleLeft);
                err.SetError(txtConfPass, "Field can\'t be empty");
                return;

            }
        }

        //validate old password
        void valOldPassword(Control ctrl)
        {

            if (txtOldPass.Text.Trim().Length > 0)
            {
                err.SetError(txtOldPass, string.Empty);
            }
            else
            {
                err.SetIconAlignment(txtOldPass, ErrorIconAlignment.MiddleLeft);
                err.SetError(txtOldPass, "Field can\'t be empty");
                return;

            }
        }



        public void CheckUserAndPasswordExist()
        {


            valConfirmPassword(txtConfPass);
            valPassword(txtPassword);
            valOldPassword(txtOldPass);

            if (err.GetError(txtOldPass).Length != 0)
            {
                err.SetIconAlignment(txtOldPass, ErrorIconAlignment.MiddleLeft);
                err.SetError(txtOldPass, "Field can\'t be empty");
                return;
            }
            else if (err.GetError(txtPassword).Length != 0)
            {
                err.SetIconAlignment(txtPassword, ErrorIconAlignment.MiddleLeft);
                err.SetError(txtPassword, "Field can\'t be empty");
                return;
            }
            else if (err.GetError(txtConfPass).Length != 0)
            {
                err.SetIconAlignment(txtConfPass, ErrorIconAlignment.MiddleLeft);
                err.SetError(txtConfPass, "Field can\'t be empty");
                return;

            }

            else
            {

                try
                {

                    SqlConnection con = new SqlConnection(insertClass.dbPath);

                    string sql = "select Uname,Pass from Users where Uname=@Uname and Pass=@Pass";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@Pass", txtOldPass.Text.Trim());



                    cmd.Parameters.AddWithValue("@Uname", getEmpName); //get usename @ login


                    adapt.Fill(ds);
                    con.Close();
                    int count = ds.Tables[0].Rows.Count;

                    //If count is equal to 1
                    //meaning user is found
                    if (count == 1)
                    {

                        if ((txtPassword.Text.Trim().Length > 0 && txtOldPass.Text.Trim().Length > 0) && (txtPassword.Text == txtConfPass.Text))
                        {
                            updateclass.updatePassword(getEmpName, txtPassword.Text);

                        }
                        else
                        {
                            MessageBox.Show("Either Password and Password Confirmation mismatch" + Environment.NewLine + "Please check your input", "Help - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                    }
                    else
                    {
                        MessageBox.Show("Error: " + "Unknown Password or User", "Update - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckUserAndPasswordExist();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOldPass_TextChanged(object sender, EventArgs e)
        {
            valOldPassword((Control)sender);
        }

        private void txtOldPass_Leave(object sender, EventArgs e)
        {
            valOldPassword((Control)sender);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            valPassword((Control)sender);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            valPassword((Control)sender);
        }

        private void txtConfPass_TextChanged(object sender, EventArgs e)
        {
            valConfirmPassword((Control)sender);
        }

        private void txtConfPass_Leave(object sender, EventArgs e)
        {
            valConfirmPassword((Control)sender);
        }


    }
}
