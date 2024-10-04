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
    public partial class frmRegEmp : Form
    {
        public frmRegEmp()
        {
            InitializeComponent();
        }

        clsInsert insertClass = new clsInsert();
        clsSelect selectClass = new clsSelect();
        string empID;
        private void frmRegEmp_Load(object sender, EventArgs e)
        {
            txtFname.Focus();
            cboGender.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //RESETTING
        void setToInitialState()
        {
            DateTimePicker dt = new DateTimePicker();
            empID = "emp" + selectClass.callGenEmpID().ToString();
            txtFname.ResetText();
            txtLname.ResetText();
            txtOname.ResetText();
            txtPhone.ResetText();
            dptBDay.Text = dt.Value.Date.ToString();
            txtEmail.ResetText();
            txtResAddress.ResetText();
            txtRFname.ResetText();
            txtRLname.ResetText();
            txtRPhone.ResetText();
            cboGender.SelectedIndex = 0;
            //set a default value when adding images
            PicEmp.Image = null;
            // MessageBox.Show(empID);

            //RESET ERROR PROVIDER TO EMPTY STRING
            clsInsert.err.SetError(txtFname, string.Empty);
            clsInsert.err.SetError(txtLname, string.Empty);
            clsInsert.err.SetError(cboGender, string.Empty);
            clsInsert.err.SetError(txtPhone, string.Empty);
            clsInsert.err.SetError(dptBDay, string.Empty);
            clsInsert.err.SetError(txtResAddress, string.Empty);
            clsInsert.err.SetError(txtEmail, string.Empty);
            clsInsert.err.SetError(txtRFname, string.Empty);
            clsInsert.err.SetError(txtRLname, string.Empty);
            clsInsert.err.SetError(txtRPhone, string.Empty);

        }


        //FIRST NAME
        void valFname(Control ctrl)
        {
            if (txtFname.Text.Trim().Length > 0)
            {
                clsInsert.err.SetError(txtFname, string.Empty);

            }
            else
            {
                clsInsert.err.SetIconAlignment(txtFname, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtFname, "Field can\'t be empty");
                return;

            }


        }

        //LAST NAME
        void valLname(Control ctrl)
        {
            if (txtLname.Text.Trim().Length > 0)
            {
                clsInsert.err.SetError(txtLname, string.Empty);

            }
            else
            {
                clsInsert.err.SetIconAlignment(txtLname, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtLname, "Field can\'t be empty");
                return;

            }
        }

        //GENDER
        void valGender(Control ctrl)
        {
            if (cboGender.SelectedIndex != 0)
            {
                clsInsert.err.SetError(cboGender, string.Empty);

            }
            else
            {
                clsInsert.err.SetIconAlignment(cboGender, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(cboGender, "Please select gender");
                return;

            }
        }

        //PHONE
        void valPhone(Control ctrl)
        {
            double isNumber;
            if ((txtPhone.Text.Trim().Length > 9) && (double.TryParse(txtPhone.Text, out isNumber)))
            {

                clsInsert.err.SetError(txtPhone, string.Empty);

            }
            else
            {
                clsInsert.err.SetIconAlignment(txtPhone, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtPhone, "Please enter numberic value");
                return;

            }
        }


        //DATE OF BIRTH
        void valDob(Control ctrl)
        {

            DateTimePicker sysDat = new DateTimePicker();

            if ((int.Parse(sysDat.Value.Date.Year.ToString()) - int.Parse(dptBDay.Value.Date.Year.ToString())) > 17)
            {

                clsInsert.err.SetError(dptBDay, string.Empty);

            }
            else
            {
                clsInsert.err.SetIconAlignment(dptBDay, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(dptBDay, "Age must be greater than 17 years");
                return;

            }
        }

        //RESIDENCE
        void valResidence(Control ctrl)
        {
            if (txtResAddress.Text.Trim().Length > 0)
            {
                clsInsert.err.SetError(txtResAddress, string.Empty);

            }
            else
            {
                clsInsert.err.SetIconAlignment(txtResAddress, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtResAddress, "Field can\'t be empty");
                return;

            }
        }

        //EMAIL
        void valEmail(Control ctrl)
        {
            //EMAIL CONTAINS TEXT
            if (txtEmail.Text.Trim().Length > 0)
            {

                //CHECK FOR @ AND .
                if (txtEmail.Text.Contains("@") && txtEmail.Text.Contains("."))
                {

                    clsInsert.err.SetError(txtEmail, string.Empty);

                }
                //IF NOT THEN THROW THIS WARNING
                else
                {
                    clsInsert.err.SetIconAlignment(txtEmail, ErrorIconAlignment.MiddleLeft);
                    clsInsert.err.SetError(txtEmail, "Invalid email, must contain @ and .");
                    return;

                }


            }

                //EMAIL IS EMPTY
            else
            {
                clsInsert.err.SetError(txtEmail, string.Empty);

            }
        }

        //REFERENCE FIRST NAME
        void valRef_fname(Control ctrl)
        {
            if (txtRFname.Text.Trim().Length > 0)
            {
                clsInsert.err.SetError(txtRFname, string.Empty);

            }
            else
            {
                clsInsert.err.SetIconAlignment(txtRFname, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtRFname, "Field can\'t be empty");
                return;
            }

        }

        //REFERENCE LAST NAME
        void valRef_Lname(Control ctrl)
        {
            if (txtRLname.Text.Trim().Length > 0)
            {
                clsInsert.err.SetError(txtRLname, string.Empty);

            }
            else
            {
                clsInsert.err.SetIconAlignment(txtRLname, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtRLname, "Field can\'t be empty");
                return;
            }

        }

        //REFERENCE PHONE
        void valRef_Phone(Control ctrl)
        {
            double isNumber;
            if ((txtRPhone.Text.Trim().Length > 9) && (double.TryParse(txtRPhone.Text, out isNumber)))
            {

                clsInsert.err.SetError(txtRPhone, string.Empty);

            }
            else
            {
                clsInsert.err.SetIconAlignment(txtRPhone, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtRPhone, "Please enter numberic value");
                return;

            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            valFname(txtFname);
            valLname(txtLname);
            valGender(cboGender);
            valPhone(txtPhone);
            valDob(dptBDay);
            valResidence(txtResAddress);
            valEmail(txtEmail);
            valRef_fname(txtRFname);
            valRef_Lname(txtRLname);
            valRef_Phone(txtRPhone);

            if (clsInsert.err.GetError(txtFname).Length != 0)
            {
                clsInsert.err.SetIconAlignment(txtFname, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtFname, "Field can\'t be empty");
                return;
            }

            else if (clsInsert.err.GetError(txtLname).Length != 0)
            {

                clsInsert.err.SetIconAlignment(txtLname, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtLname, "Field can\'t be empty");
                return;
            }
            else if (clsInsert.err.GetError(cboGender).Length != 0)
            {

                clsInsert.err.SetIconAlignment(cboGender, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(cboGender, "Please select gender");
                return;
            }
            else if (clsInsert.err.GetError(txtPhone).Length != 0)
            {
                clsInsert.err.SetIconAlignment(txtPhone, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtPhone, "Please enter numberic value");
                return;

            }
            else if (clsInsert.err.GetError(dptBDay).Length != 0)
            {
                clsInsert.err.SetIconAlignment(dptBDay, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(dptBDay, "Age must be greater than 17 years");
                return;

            }
            else if (clsInsert.err.GetError(txtResAddress).Length != 0)
            {

                clsInsert.err.SetIconAlignment(txtResAddress, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtResAddress, "Field can\'t be empty");
                return;

            }
            else if (clsInsert.err.GetError(txtEmail).Length != 0)
            {

                clsInsert.err.SetIconAlignment(txtEmail, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtEmail, "Invalid email, must contain @ and .");
                return;
            }

            else if (clsInsert.err.GetError(txtRFname).Length != 0)
            {
                clsInsert.err.SetIconAlignment(txtRFname, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtRFname, "Field can\'t be empty");
                return;

            }
            else if (clsInsert.err.GetError(txtRLname).Length != 0)
            {

                clsInsert.err.SetIconAlignment(txtRLname, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtRLname, "Field can\'t be empty");
                return;
            }
            else if (clsInsert.err.GetError(txtRPhone).Length != 0)
            {

                clsInsert.err.SetIconAlignment(txtRPhone, ErrorIconAlignment.MiddleLeft);
                clsInsert.err.SetError(txtRPhone, "Please enter numberic value");
                return;
            }

                //WHEN ALL REQUIREMENTS ARE SATISFIED PERFORM THE INSERTIONS
            else
            {

                insertClass.addEmployee("emp" + selectClass.callGenEmpID().ToString(), txtFname.Text, txtLname.Text, txtOname.Text, cboGender, dptBDay, txtPhone.Text, txtResAddress.Text, txtEmail.Text, txtRFname.Text, txtRLname.Text, txtRPhone.Text, PicEmp);

                insertClass.insertTocallGenEmpID(selectClass.callGenEmpID());

                setToInitialState();

            }
           
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            clsSelect.uploadImage(PicEmp);
        }

        private void txtFname_TextChanged(object sender, EventArgs e)
        {
            valFname((Control)sender);
        }

        private void txtFname_Leave(object sender, EventArgs e)
        {
            valFname((Control)sender);
        }

        private void txtLname_TextChanged(object sender, EventArgs e)
        {
            valLname((Control)sender);
        }

        private void txtLname_Leave(object sender, EventArgs e)
        {
            valLname((Control)sender);
        }

        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            valGender((Control)sender);
        }

        private void cboGender_Leave(object sender, EventArgs e)
        {
            valGender((Control)sender);
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            valPhone((Control)sender);
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
           valPhone ((Control)sender);
        }

        private void txtResAddress_TextChanged(object sender, EventArgs e)
        {
            valResidence((Control)sender);
        }

        private void txtResAddress_Leave(object sender, EventArgs e)
        {
          valResidence  ((Control)sender);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            valEmail((Control)sender);
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            valEmail((Control)sender);
        }

        private void txtRFname_TextChanged(object sender, EventArgs e)
        {
            valRef_fname((Control)sender);
        }

        private void txtRFname_Leave(object sender, EventArgs e)
        {
            valRef_fname((Control)sender);
        }

        private void txtRLname_TextChanged(object sender, EventArgs e)
        {
            valRef_Lname((Control)sender);
        }

        private void txtRLname_Leave(object sender, EventArgs e)
        {
         valRef_Lname   ((Control)sender);
        }

        private void txtRPhone_TextChanged(object sender, EventArgs e)
        {
            valRef_Phone((Control)sender);
        }

        private void txtRPhone_Leave(object sender, EventArgs e)
        {
            valRef_Phone((Control)sender);
        }

        private void dptBDay_ValueChanged(object sender, EventArgs e)
        {
            valDob((Control)sender);
        }

        private void dptBDay_Leave(object sender, EventArgs e)
        {
            valDob((Control)sender);
        }
    }
}
