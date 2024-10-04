using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KikuzawaRestaurant.Forms
{
    public partial class orderInfo : Form
    {
        public orderInfo()
        {
            InitializeComponent();
        }

        ErrorProvider err = new ErrorProvider();
        public string orderType;
        frmOrder orderTable = new frmOrder();
        frmTheTables table_Forms = new frmTheTables();
       
        public string Dates, Times;
        private void orderInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            valChildNo(txtChild);
            valAdultNo(txtAdultNo);
            if(err.GetError(txtChild).Length !=0){

                err.SetIconAlignment(txtChild, ErrorIconAlignment.MiddleLeft);
                err.SetError(txtChild, "Input not a number");
                return;
            }
            else if (err.GetError(txtAdultNo).Length != 0)
            {
                err.SetIconAlignment(txtAdultNo, ErrorIconAlignment.MiddleLeft);
                err.SetError(txtAdultNo, "Input not a number");
                return;
            
            }
            else{

                //make a default of 1


                if (txtAdultNo.Text.Trim().Length == 0)
                {
                    txtAdultNo.Text = 1.ToString();
                }
                //make a default of 0


                if (txtChild.Text.Trim().Length == 0)
                {
                    txtChild.Text = 0.ToString();

                }


            orderTable.fname = txtFirst.Text;
            orderTable.lname = txtLast.Text;
            Dates = dateTimePicker1.Value.ToShortDateString();
            Times = dateTimePicker1.Value.ToShortTimeString();
            orderTable.lblgetDateTime.Text = Dates + " " + Times;
            orderTable.lblAdultNo.Text = txtAdultNo.Text;
            orderTable.lblChild.Text = txtChild.Text;
            orderTable.lblgetGuestName.Text = txtFirst.Text + " " + txtLast.Text;
            orderTable.lblTableNo.Text = txtTableNo.Text;
            if (txtTableNo.Text.Equals("0"))
            {

                orderTable.lblOrderDescription.Text = orderType;
            }
            else
            {
                orderTable.lblOrderDescription.Text = txtReceiptType.Text.Trim();
            }

            orderTable.lblwaiterName.Text = this.txtWaiterName.Text.Trim();

            table_Forms.Hide(); //make frmTable invisible
            this.Hide();
            orderTable.ShowDialog();
            
            }
        }

        private void txtAdultNo_TextChanged(object sender, EventArgs e)
        {
            valAdultNo((Control)sender);
        }

        private void txtChild_TextChanged(object sender, EventArgs e)
        {
            valChildNo((Control)sender);
        }

       void valAdultNo(Control ctrl){
           int num;

           if (txtAdultNo.Text.Trim().Length == 0) {
               txtAdultNo.Text = "1";
                err.SetIconAlignment(txtAdultNo, ErrorIconAlignment.MiddleLeft);
                err.SetError(txtAdultNo, "");
           }

           else if (txtAdultNo.Text.Trim().Length != 0) { 
                    if (int.TryParse(txtAdultNo.Text, out num) == true)
                   {
                       err.SetIconAlignment(txtAdultNo, ErrorIconAlignment.MiddleLeft);
                       err.SetError(txtAdultNo, "");

                   }
                   else {
                       err.SetIconAlignment(txtAdultNo, ErrorIconAlignment.MiddleLeft);
                       err.SetError(txtAdultNo, "Input not a number");
                       return;
           }
           }
           
          
          
        
        
        }

       void valChildNo(Control ctrl)
       {
           int num;

           if (txtChild.Text.Trim().Length == 0) {
               txtChild.Text = "0";
               err.SetIconAlignment(txtChild, ErrorIconAlignment.MiddleLeft);
               err.SetError(txtChild, "");
           
           }

               //child textbox contain an input
           else if (txtChild.Text.Trim().Length != 0) { 

                 if (int.TryParse(txtChild.Text, out num) == true)
               {
                   err.SetIconAlignment(txtChild, ErrorIconAlignment.MiddleLeft);
                   err.SetError(txtChild, "");

               }
               else
                   {
                       err.SetIconAlignment(txtChild, ErrorIconAlignment.MiddleLeft);
                       err.SetError(txtChild, "Input not a number");
                       return;
                   }
       }
           


       }

       private void txtChild_Leave(object sender, EventArgs e)
       {
           valChildNo((Control)sender);
       }

       private void txtAdultNo_Leave(object sender, EventArgs e)
       {
           valAdultNo((Control)sender);
       }

        private void txtReceiptType_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
       {
           this.Close();
       }
    }
}
