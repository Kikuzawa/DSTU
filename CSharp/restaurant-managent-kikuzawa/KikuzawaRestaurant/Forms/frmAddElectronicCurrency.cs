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
    public partial class frmAddElectronicCurrency : Form
    {
        public frmAddElectronicCurrency()
        {
            InitializeComponent();
        }
        clsInsert insertClass = new clsInsert();
       

        //save button
        private void button1_Click(object sender, EventArgs e)
        {
            valTextBox(textBox1);

            if (clsSelect.err.GetError(textBox1).Length != 0)
            {
                clsSelect.err.SetIconAlignment(textBox1, ErrorIconAlignment.MiddleLeft);
                clsSelect.err.SetError(textBox1, "Field can\'t be empty");
                return;

            }
            else { 
                 _CheckElectCurrencyExist();
            }

        }

        void _CheckElectCurrencyExist()
        {
            try
            {

                SqlConnection con = new SqlConnection(insertClass.dbPath);

                string sql = "select name from ElectronicCurrency  where name = @name";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@name", textBox1.Text.Trim());

                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;

                //If count is equal to 1
                //meaning user already exist
                if (count == 1)
                {
                    MessageBox.Show("Electronic Currency Already Exist", "Save Data - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    //PERFORM INSERT
                    insertClass.insertToElectronicCurrency(textBox1.Text.Trim());
                    textBox1.ResetText();
                }

            }

            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            valTextBox((Control)sender);
        }

        void valTextBox(Control ctrl)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
              clsSelect.err.SetError(textBox1, string.Empty);
            }
            else
            {

                clsSelect.err.SetIconAlignment(textBox1, ErrorIconAlignment.MiddleLeft);
                clsSelect.err.SetError(textBox1, "Field can\'t be empty");
                return;
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            valTextBox((Control)sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
