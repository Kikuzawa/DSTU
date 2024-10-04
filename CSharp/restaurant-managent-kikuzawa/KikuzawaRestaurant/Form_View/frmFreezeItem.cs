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
namespace KikuzawaRestaurant.Form_View
{
    public partial class frmFreezeItem : Form
    {
        public frmFreezeItem()
        {
            InitializeComponent();
        }
        clsUpdate updateClass = new clsUpdate();
        clsSelect selectClass = new clsSelect();
        
        ErrorProvider err = new ErrorProvider();
        private void btnOK_Click(object sender, EventArgs e)
        {
            bool statues = false;
            valTextBox(textBox1);
            if (checkBox1.Checked && err.GetError(textBox1).Length == 0)
            {
                statues = true;
                updateClass.UpdateProductsStatues(textBox1.Text.Trim(), statues, int.Parse(textBox2.Text));
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Please tick 'freeze item' to perform item freezing" + Environment.NewLine + "Also Assign a reason for freezing the product", "SAVED - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }


        }

        void valTextBox(Control ctrl)
        {
            if (textBox1.Text.Trim() == "")
            {
                err.SetIconAlignment(textBox1, ErrorIconAlignment.MiddleLeft);
                err.SetError(textBox1, "Field Can\'t be empty");
                return;
            }
            else
            {
                err.SetIconAlignment(textBox1, ErrorIconAlignment.MiddleLeft);
                err.SetError(textBox1, "");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            valTextBox(textBox1);
            if (err.GetError(textBox1).Length != 0)
            {
                err.SetIconAlignment(textBox1, ErrorIconAlignment.MiddleLeft);
                err.SetError(textBox1, "Field Can\'t be empty");
                return;
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            valTextBox((Control)sender);
            
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            valTextBox((Control)sender);
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        void selectProductsStatues()
        {
            try
            {

                string sql = "select Reason from tblProducts where Convert(varchar,prodID)='" + textBox2.Text + "'";
                SqlConnection con = new SqlConnection(selectClass.dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                   
                    textBox1.Text = reader["Reason"].ToString();
                   
                    
                }
            }

            catch (Exception ex)
            {
              //  MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
               selectClass.con.Close();
            }



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //selectProductsStatues();
           
        }

        private void frmFreezeItem_Load(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }
    }
}
