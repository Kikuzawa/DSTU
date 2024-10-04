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
using KikuzawaRestaurant.Folder_Updates;
namespace KikuzawaRestaurant.Form_View
{
    public partial class frmViewProducts : Form
    {
        public frmViewProducts()
        {
            InitializeComponent();
        }
        clsView viewClass = new clsView();
        clsSelect selectClass = new clsSelect();
        frmUpProducts upProducts = new frmUpProducts();
        frmFreezeItem freezeForm = new frmFreezeItem();
        frmUnFreezeItem unfreezeForm = new frmUnFreezeItem();
        string id = "";
        
        private void frmViewProducts_Load(object sender, EventArgs e)
        {
            viewClass.viewMenuProduct(dataGridView1);
            label2.Text = "[Total Count = " + dataGridView1.RowCount.ToString() + " ]";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[4].Value.ToString();
                id = row.Cells[0].Value.ToString();
               
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim().Length > 0)
            {
                selectClass.SearcshForMenuProduct(textBox2.Text, dataGridView1);
            }
            else
            {

                viewClass.viewMenuProduct(dataGridView1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (id.Trim() != "")
                {
                    upProducts.txtID.Text = id;
                    upProducts.ShowDialog();
                    //refresh datagrid
                    viewClass.viewMenuProduct(dataGridView1);
                    id = "";
                }
                else { 
                    MessageBox.Show("Please click item to update ", "SAVED - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAVED - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFreeze_Click(object sender, EventArgs e)
        {
            try
            {
                if (id.Trim() != "")
                {
                   
                    //refresh dat
                    freezeForm.textBox2.Text = id;

                    freezeForm.ShowDialog();
                    //refresh datagrid
                    viewClass.viewMenuProduct(dataGridView1);
                    id = "";
                   
                }
                else
                {
                    MessageBox.Show("Please click item to update ", "SAVED - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                    return;

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(), "SAVED - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
            }
        }

        private void btnUnfreeze_Click(object sender, EventArgs e)
        {
            getThisID();
        }

        void getThisID() {
            try
            {
                if (id.Trim() != "")
                {

                    //refresh dat
                    unfreezeForm.textBox2.Text = id;

                    unfreezeForm.ShowDialog();
                    //refresh datagrid
                    viewClass.viewMenuProduct(dataGridView1);
                    id = "";

                }
                else
                {
                    MessageBox.Show("Please click item to update ", "SAVED - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;

                }




            }
            catch(Exception)
            {
            }
        }

        
    }
}
