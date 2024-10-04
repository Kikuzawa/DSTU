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
namespace KikuzawaRestaurant.Forms
{
    public partial class frmAddUsers : Form
    {
        public frmAddUsers()
        {
            InitializeComponent();
        }
        clsInsert insertClass = new clsInsert();
        clsSelect selectClass = new clsSelect();
        ErrorProvider err = new ErrorProvider();

        Label lblIDText = new Label();//get id of employee
        //REMOVE DULPICATE
        void _CheckUserExist()
        {
            try
            {

                SqlConnection con = new SqlConnection(insertClass.dbPath);

                string sql = "select empID from Users  where empID = @empID";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@empID", lblIDText.Text.Trim());

                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;

                //If count is equal to 1
                //meaning user already exist
                if (count == 1)
                {
                    MessageBox.Show("User Already Exist", "Save Data - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    //PERFORM INSERT
                    insertClass.AddUsers(lblIDText.Text, txtUname.Text, txtPassword.Text, cboPrivilege);
                    txtConfPass.ResetText();
                    txtPassword.ResetText();

                }

            }

            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            valPassword(txtPassword);
            valConfirmPassword(txtConfPass);

            if (err.GetError(txtPassword).Length != 0)
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

                if (txtPassword.Text == txtConfPass.Text)
                {
                    //call this method
                    _CheckUserExist();

                   
                }
                else
                {
                    MessageBox.Show("Password mismatch", "Throwing Exception - Kikuzawa", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            
        }


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

        private void frmAddUsers_Load(object sender, EventArgs e)
        {
            selectClass.selectEmployee(cboSelectEmp);
            cboPrivilege.SelectedIndex = 0;
        }

        private void cboSelectEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectClass.getEmpPic(cboSelectEmp, pictureBox1);
            selectClass.getName_Phone(cboSelectEmp);
            txtEmpName.Text = selectClass.fullName;
            txtEmpPhone.Text = selectClass.phone;
            lblIDText.Text = selectClass.empID(txtEmpName.Text, txtEmpPhone.Text);
            
        }

        private void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            txtUname.Text = txtEmpName.Text.Trim();
        }

        private void txtConfPass_TextChanged(object sender, EventArgs e)
        {
            valConfirmPassword((Control)sender);
        }

        private void txtConfPass_Leave(object sender, EventArgs e)
        {
            valConfirmPassword((Control)sender);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            valPassword((Control)sender);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            valPassword((Control)sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
