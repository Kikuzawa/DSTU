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
namespace KikuzawaRestaurant
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        clsSelect selectClass = new clsSelect();
        clsInsert varinsert = new clsInsert();
        DateTimePicker day = new DateTimePicker();
        clsInsert insertClass = new clsInsert();

        private void frmLogin_Load(object sender, EventArgs e)
        {

            //selectClass.selectUsers(cboUsername);
            //txtPass.Select();
            reload_users();
            frmParent fp = new frmParent();
            if(fp.Visible){
                fp.Close();
            }
        }
       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Logins(cboUsername.SelectedItem.ToString(), txtPass.Text);
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(5000, "Happy Birth day", "Kikuzawa App wishes you a happy birthday", ToolTipIcon.Info);
            
        }

        public void reload_users()
        {
            try
            {
                clsSelect uSelect = new clsSelect();
                cboUsername.Items.Clear();
                cboUsername.ResetText();
                uSelect.selectUsers(cboUsername);
                txtPass.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //LOGIN
        void Logins(string Usernames, string Password)
        {

            try
            {
                SqlConnection con = new SqlConnection(varinsert.dbPath);

                string sql = "select Uname,Pass,privileges from Users where Uname=@Uname and Pass=@Pass";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Uname", Usernames.Trim());
                cmd.Parameters.AddWithValue("@Pass", Password.Trim());
                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;

                //If count is equal to 1, meaning if found=true, then show frmMain form
                if (count == 1)
                {
                    string privel = getPrivilege();
                    frmParent parent = new frmParent();
                    //username,login date,login time, logout date, logout time

                    
                    insertClass.insertToLogHistory(cboUsername.SelectedItem.ToString(), day, day, day, day);

                    int getLogID = 0;
                    int lab;
                    lab = selectClass.callMaxLogHistoryAndEmployee(cboUsername.SelectedItem.ToString(), getLogID);

                    /*
                     *Disable some button based on certain privileges the user has
                     *if user is assigned Administrator he/she  has all button enable at his/her disposal
                     *but in the case where he/she has a privilege called users certain buttons will be greyed out 
                     *meaning he/she can't perform certain operation
                     */
                    if (privel.Equals("Users")) {
                        parent.btnRegEmployee.Enabled = false;
                        parent.btnAddUsers.Enabled = false;
                        parent.btnCuurency.Enabled = false;
                        parent.btnAddPOSCurrency.Enabled = false;
                        parent.btnAddMenuGroup.Enabled = false;
                        parent.btnAddMenus.Enabled = false;
                        parent.btnVEmployee.Enabled = false;
                        parent.btnVUsers.Enabled = false;
                        parent.button9.Enabled = false;
                        parent.button11.Enabled = false;
                        parent.btnBakup.Enabled = false;
                    }

                    parent.statGetUser.Text = cboUsername.SelectedItem.ToString();
                    parent.getLogNum = lab;
                    this.Hide();
                    parent.ShowDialog();
                    cboUsername.Items.Clear();
                    txtPass.Clear();
                    txtPass.Text = "•••••••";
                    txtPass.Select();
                }

                else
                {
                    MessageBox.Show("Invalid Username or Password", "Error - Kikuzawa Restaurant Logins", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error - Throwing Exceptions");
            }




        }


        //getPrivilege reads the privilege the login user has
        
        SqlConnection con;
        SqlDataReader reader;
        string privilege;
        string getPrivilege() { 
         try
            {

                string sql = "select privileges from Users where Uname='" + cboUsername.SelectedItem.ToString() + "'and  Pass='" + txtPass.Text + "'";

                con = new SqlConnection(insertClass.dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    privilege =  reader["privileges"].ToString();
                }
         }
             catch(Exception){
             
             }
            return privilege;
        

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
