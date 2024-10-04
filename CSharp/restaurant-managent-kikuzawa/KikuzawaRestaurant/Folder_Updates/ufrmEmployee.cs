using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using KikuzawaRestaurant.Classes;
namespace KikuzawaRestaurant.Folder_Updates
{
    public partial class ufrmEmployee : Form
    {
        
        clsSelect selectClass = new clsSelect();
        clsUpdate updClass = new clsUpdate();
        public ufrmEmployee()
        {
            InitializeComponent();
        }

        /// <summary>
        /// pull details by id
        /// </summary>
        void selectDetails()
        {
            try
            {
                clsSelect selectClass = new clsSelect();

                string sql = "select fname,lname,oname,gender,dob,phone,resAddress,emailAdd,ref_fname,ref_lname,ref_phone,photo  from tblEmployee where empID='" + textBox1.Text + "'";
                SqlConnection con = new SqlConnection(selectClass.dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtFname.Text = reader["fname"].ToString();
                    txtLname.Text = reader["lname"].ToString();
                    txtOname.Text = reader["oname"].ToString();
                    cboGender.Text = reader["gender"].ToString();
                    dptBDay.Text = reader["dob"].ToString();
                    txtPhone.Text = reader["phone"].ToString();
                    txtResAddress.Text = reader["resAddress"].ToString();
                    txtEmail.Text = reader["emailAdd"].ToString();
                    txtRFname.Text = reader["ref_fname"].ToString();
                    txtRLname.Text = reader["ref_lname"].ToString();
                    txtRPhone.Text = reader["ref_phone"].ToString();

                    MemoryStream ms = new MemoryStream((byte[])reader["photo"]);
                    PicEmp.Image = new Bitmap(ms);
                }
                else
                {

                    clearAll();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        void clearAll()
        {
            txtFname.Clear();
            txtLname.Clear();
            txtOname.Clear();
            cboGender.SelectedIndex = 0;

            txtPhone.Clear();
            txtResAddress.Clear();
            txtEmail.Clear();
            txtRFname.Clear();
            txtRLname.Clear();
            txtRPhone.Clear();
            PicEmp.Image = null;

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            clsSelect.uploadImage(PicEmp);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            updClass.updateEmployee(textBox1.Text, txtFname.Text, txtLname.Text, txtOname.Text, cboGender, dptBDay, txtPhone.Text, txtResAddress.Text, txtEmail.Text, txtRFname.Text, txtRLname.Text, txtRPhone.Text, PicEmp);
            clearAll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            selectDetails();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ufrmEmployee_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
