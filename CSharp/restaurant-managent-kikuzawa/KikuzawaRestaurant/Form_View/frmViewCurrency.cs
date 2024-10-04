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
    public partial class frmViewCurrency : Form
    {
        public frmViewCurrency()
        {
            InitializeComponent();
        }

        clsView viewClass = new clsView();
        clsSelect selectClass = new clsSelect();
        Label label1 = new Label();
        string checkStatues;
        ufrmCurrency updCurrency = new ufrmCurrency();
       string Rate;
        private void frmViewCurrency_Load(object sender, EventArgs e)
        {
            viewClass.viewCurrency(dataGridView1);
            label1.Text = 1.ToString();  //set default id=1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // ufrmCurrency updCurrency = new ufrmCurrency();
            selectClass.SelectCurrency(int.Parse(this.label1.Text));
            updCurrency.txtID.Text = this.label1.Text;
            updCurrency.txtCurrName.Text = selectClass.currName;
            updCurrency.txtCurSymbol.Text = selectClass.curSymbol.ToString();
            updCurrency.txtExchangeRate.Text = Rate;
            if (checkStatues.Equals("Inused"))
            {
                updCurrency.radInuse.Checked = true;
                updCurrency.radNotuse.Checked = false;

            }
            else {
                updCurrency.radInuse.Checked = false;
                updCurrency.radNotuse.Checked =true;
            
            }

            updCurrency.ShowDialog();

            //the below method serves as  backgroud refresh
            viewClass.viewCurrency(dataGridView1);
            }
            catch (Exception)
            {
                
               MessageBox.Show("Please click to select currency", "Help - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ufrmCurrency updCurrency = new ufrmCurrency();

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                label1.Text = row.Cells[0].Value.ToString();
                checkStatues = row.Cells[3].Value.ToString();
               Rate= row.Cells[4].Value.ToString();
            }
        }
    }
}
