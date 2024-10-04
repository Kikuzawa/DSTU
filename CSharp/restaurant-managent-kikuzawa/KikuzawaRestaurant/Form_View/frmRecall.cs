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
namespace KikuzawaRestaurant.Form_View
{
    public partial class btnCancel : Form
    {
        public Label lblGetId = new Label();
        public btnCancel()
        {
            InitializeComponent();
        }

        Label getRep = new Label();
        TextBox txtGetBill = new TextBox();
        public string recallDate,recallTime;
        
         clsSelect selectClass = new clsSelect();

         // frmSettlement settlement = new frmSettlement();
         // settlement.txtReceiptNum.Text = getRep.Text;
         //clsSelect selectClass = new clsSelect();
          frmViewOrderSettlement fvos = new frmViewOrderSettlement();
         private void frmRecall_Load(object sender, EventArgs e)
         {
             cboSearcshMode.SelectedIndex = 0;

             selectClass.selectBillAndSettlement(dataGridView1);
         }

         private void button5_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         private void btnMyOrder_Click(object sender, EventArgs e)
         {
             DateTimePicker dates = new DateTimePicker();
             if (btnMyOrder.Text.Equals("My Order"))
             {
                 btnMyOrder.Text = "All Orders";

                 btnMyOrder.Image = Properties.Resources.Groups_Meeting_Dark_icon;
                 selectClass.selectBySalePersonBillAndSettlement(dataGridView1, lblGetId.Text,dates);
             }
             else if (btnMyOrder.Text.Equals("All Orders"))
             {
                 btnMyOrder.Text = "My Order";
                 btnMyOrder.Image = Properties.Resources.Office_Customer_Male_Light_icon;
                 selectClass.selectAllBillAndSettlement(dataGridView1,dates);
             }
         }

         private void btnDatSearcsh_Click(object sender, EventArgs e)
         {
             selectClass.selectBillAndSettlementByDate(dataGridView1, dateTimePicker1);
         }

         private void btnSearch_Click(object sender, EventArgs e)
         {
             //call clsselect class sort method
             selectClass.selectSortBillAndSettlement(dataGridView1, txtSearcsh.Text, cboSearcshMode);
         }

         private void chkTakeAway_CheckedChanged(object sender, EventArgs e)
         {
             if (chkTakeAway.Checked)
             {
                 selectClass.selectByTakeAwayBillAndSettlement(dataGridView1, "Take Away");

             }
         }

         private void chkDineIn_CheckedChanged(object sender, EventArgs e)
         {
             if (chkDineIn.Checked)
             {
                 selectClass.selectByDineInBillAndSettlement(dataGridView1, "Dine In");

             }
         }

         private void chkNoCharge_CheckedChanged(object sender, EventArgs e)
         {
             if (chkNoCharge.Checked)
             {
                 selectClass.selectByNoChargeBillAndSettlement(dataGridView1, "No Charge");

             }
         }

         private void btnRecall_Click(object sender, EventArgs e)
         {
             if (getRep.Text == "")
             {
                 MessageBox.Show("Please click to select Receipt", "Help - Kikuzawa...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 return;
             }
             selectClass.selectOrderDetailsUsingKOT(getRep.Text, fvos.listView1);

             selectClass.selectOrderFieldsUsingKOT(getRep.Text);
             fvos.lblGetReceipt.Text = getRep.Text;
             fvos.lblTableNo.Text = selectClass.TableNum;
             fvos.lblOrderDescription.Text = selectClass.orderDescript;
             fvos.lblgetDateTime.Text = selectClass.OrderDate + " ";
             fvos.thisDate = selectClass.OrderDate;
             fvos.daty = selectClass.OrderDate;

             fvos.lblgetDateTime.Text += selectClass.OrderTime;
             fvos.timy = selectClass.OrderTime;
             //get number of person
             selectClass.selectAdultAndChildren(getRep.Text);
             fvos.lblAdultNo.Text = selectClass.AdultNum;
             fvos.lblChild.Text = selectClass.ChildrenNum;

             //pull employee-id where the receipt id is known
             string salesPersonID = selectClass.getSalePersonID(getRep.Text);

             //After getting the sale person id 
             //search for the fullname using the the id gotten
             //when the id is match get the Uname and assigned it to the lable
             fvos.lblwaiterName.Text = selectClass.salpersonByID(salesPersonID);

            
             fvos.fvosBillofOder = txtGetBill.Text;
             fvos.ShowDialog();
             //settlement.txtCustOwes.Text = txtGetBill.Text;
             //settlement.ShowDialog();
             getRep.Text = "";

             // serve as refresh
             selectClass.selectBillAndSettlement(dataGridView1);
         }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
         {
             if (e.RowIndex >= 0)
             {
                 DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                 getRep.Text = row.Cells[0].Value.ToString();

                 //get customer name
                 fvos.lblgetGuestName.Text = row.Cells[2].Value.ToString();
                 
                 fvos.thisTime = row.Cells[4].Value.ToString();
                 txtGetBill.Text = row.Cells[5].Value.ToString();
             }
         }

         
    }
}
