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
    public partial class frmUnFreezeItem : Form
    {
        public frmUnFreezeItem()
        {
            InitializeComponent();
        }

        clsSelect selectClass = new clsSelect();
        clsUpdate updateClass = new clsUpdate();
       
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.ResetText();
                textBox1.ReadOnly = true;
            }
            else if (!checkBox1.Checked)
                {
                    textBox1.ReadOnly = false;
                }
                
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                updateClass.UpdateProductsStatues(textBox1.Text, false, int.Parse(textBox2.Text));
            }
            else 
            {
                MessageBox.Show("Please tick 'Unfreeze item' to perform item unfreezing", "SAVED - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }


            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //selectProductsStatues();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
