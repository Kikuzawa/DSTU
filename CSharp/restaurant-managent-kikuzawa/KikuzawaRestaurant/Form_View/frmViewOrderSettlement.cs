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
using KikuzawaRestaurant.Form_View;
using KikuzawaRestaurant.Forms;
using System.Drawing.Printing;
namespace KikuzawaRestaurant.Form_View
{
    public partial class frmViewOrderSettlement : Form
    {
        public frmViewOrderSettlement()
        {
            InitializeComponent();
        }
        clsView viewClass = new clsView();
        clsSelect selectClass = new clsSelect();
        public string fvosBillofOder;
        public string daty, timy;
        public string paymentType;
        string getEmpID;
        string itemName;
        //these variable gets the date and time for the select transaction from the recall form
        //date and time will be used in printing
        public string thisDate, thisTime;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemName = listView1.Items[0].SubItems[2].Text;
            for (int col = 0; col <= listView1.Items.Count - 1; col++)
            {

                //listView1.Items[col].SubItems[1].Text = (Convert.ToInt32(listView1.Items[col].SubItems[1].Text).ToString()) ;
                //listView1.Items[col].SubItems[3].Text = (Convert.ToInt32(listView1.Items[col].SubItems[3].Text).ToString());



                selectClass.calcTaxAmt(decimal.Parse(taxPercsent), decimal.Parse(vatPercsent), decimal.Parse("0.00"), decimal.Parse(lblTotalAmt.Text));
                lblTaxAmt.Text = selectClass.tax1_Amt.ToString();
                lblVat.Text = selectClass.tax2_Amt.ToString();
                lblSubTotal.Text = selectClass.netPrice.ToString();
                lblTotalAmt.Text = subtotal().ToString();

            }
        }

        //Calculate SubTotal
        private double subtotal()
        {
            int i = 0;
            int j = 0;
            int k = 0;
            i = 0;
            j = 0;
            k = 0;


            try
            {

                j = listView1.Items.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    k = k + Convert.ToInt32(listView1.Items[i].SubItems[3].Text);
                }
                return k;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return k;

        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            Change1.Text = "Soup";
            Change2.Text = "Salad";
            Change3.Text = "Appetizer";
            Change4.Text = "Main";
            Change5.Text = "Pasta";
            Change6.Text = "Dessert";

            Change7.Text = "Sandwich";
            Change8.Text = "Hot hors doeuvres";
            Change9.Text = "Traditional Kitchen";
            Change0.Visible = false;
        }

        private void btnDrink_Click(object sender, EventArgs e)
        {
            Change1.Text = "Winery";
            Change2.Text = "Soft Drink";
            Change3.Text = "Beer";
            Change4.Text = "Water";
            Change5.Text = "Juice";
            Change6.Text = "Whisky";
            Change7.Text = "Brandy";
            Change8.Text = "Cocktail";

            Change9.Text = "Liquer";
            Change0.Visible = true;
            Change0.Text = "Cognac";
        }

        private void Change1_Click(object sender, EventArgs e)
        {
            viewClass.SelectMenuByTextDisplay(Change1, dataGridView1);
        }

        private void Change2_Click(object sender, EventArgs e)
        {
            viewClass.SelectMenuByTextDisplay(Change2, dataGridView1);
        }

        private void Change3_Click(object sender, EventArgs e)
        {
            viewClass.SelectMenuByTextDisplay(Change3, dataGridView1);
        }

        private void Change4_Click(object sender, EventArgs e)
        {
            viewClass.SelectMenuByTextDisplay(Change4, dataGridView1);
        }

        private void Change5_Click(object sender, EventArgs e)
        {
            viewClass.SelectMenuByTextDisplay(Change5, dataGridView1);
        }

        private void Change6_Click(object sender, EventArgs e)
        {
            viewClass.SelectMenuByTextDisplay(Change6, dataGridView1);
        }

        private void Change7_Click(object sender, EventArgs e)
        {
            viewClass.SelectMenuByTextDisplay(Change7, dataGridView1);
        }

        private void Change8_Click(object sender, EventArgs e)
        {
            viewClass.SelectMenuByTextDisplay(Change9, dataGridView1);
        }

        private void Change9_Click(object sender, EventArgs e)
        {
            viewClass.SelectMenuByTextDisplay(Change9, dataGridView1);
        }

        private void Change0_Click(object sender, EventArgs e)
        {
            viewClass.SelectMenuByTextDisplay(Change0, dataGridView1);
        }

        private void btnA_Click(object sender, EventArgs e)
        {
          textBox1.Text += btnA.Text.Trim();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnB.Text.Trim();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnC.Text.Trim();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnD.Text.Trim();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnE.Text.Trim();
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnF.Text.Trim();
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnG.Text.Trim();
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnH.Text.Trim();
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnI.Text.Trim();
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnJ.Text.Trim();
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnK.Text.Trim();
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnL.Text.Trim();
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnM.Text.Trim();
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnN.Text.Trim();
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnO.Text.Trim();
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnP.Text.Trim();
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnQ.Text.Trim();
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnR.Text.Trim();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnS.Text.Trim();
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnT.Text.Trim();
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnU.Text.Trim();
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnV.Text.Trim();
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnW.Text.Trim();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnX.Text.Trim();
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnY.Text.Trim();
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnZ.Text.Trim();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            textBox1.Text += btn0.Text.Trim();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            textBox1.Text += btn1.Text.Trim();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            textBox1.Text += btn2.Text.Trim();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            textBox1.Text += btn3.Text.Trim();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            textBox1.Text += btn4.Text.Trim();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            textBox1.Text += btn5.Text.Trim();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            textBox1.Text += btn6.Text.Trim();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            textBox1.Text += btn7.Text.Trim();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            textBox1.Text += btn8.Text.Trim();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            textBox1.Text += btn9.Text.Trim();
        }

        private void btnCent_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnCent.Text.Trim();
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            textBox1.Text += btndot.Text.Trim();
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                //CONTINUE TO CLEAR TEXT UNTIL NOTHING IS REMAIN
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);

            }
        }

        private void btnPounds_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnPounds.Text.Trim();
        }

        private void btnDollar_Click(object sender, EventArgs e)
        {
            textBox1.Text += btnDollar.Text.Trim();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += " ";
        }

        private void btnCashout_Click(object sender, EventArgs e)
        {
           
                printBill();
         }

        string taxPercsent, vatPercsent;
        private void frmViewOrderSettlement_Load(object sender, EventArgs e)
        {
           // button3.Enabled = false;
            button4.Enabled = true;
           // button49.Enabled = false;
            btnFood_Click(sender, e);//activate the food button when form load
            dataGridView1.Enabled = true;
            selectClass.selectProduct(dataGridView1);
            selectClass.getTaxables();


            taxPercsent = string.Format("{0:n2}", selectClass.tax1.ToString());
            vatPercsent = string.Format("{0:n2}", selectClass.tax2.ToString());

            //test
            for (int col = 0; col <= listView1.Items.Count - 1; col++)
            {

                selectClass.calcTaxAmt(decimal.Parse(taxPercsent), decimal.Parse(vatPercsent), decimal.Parse("0.00"), decimal.Parse(lblTotalAmt.Text));
                lblTaxAmt.Text = selectClass.tax1_Amt.ToString();
                lblVat.Text = selectClass.tax2_Amt.ToString();
                lblSubTotal.Text = selectClass.netPrice.ToString();
                lblTotalAmt.Text = subtotal().ToString();

            }

        }

        private void btnSettlement_Click(object sender, EventArgs e)
        {
            frmSettlement setl = new frmSettlement();
            setl.getCashierName = this.lblwaiterName.Text;
            setl.txtReceiptNum.Text = this.lblGetReceipt.Text;
            setl.KOTnum = this.lblGetReceipt.Text;
            setl.txtCustOwes.Text = this.fvosBillofOder;
            // this.Hide();
            setl.ShowDialog();

           // //wait a bit
            string askme = "Do you wanna print receipt ?";
            DialogResult result = MessageBox.Show(askme, "Print Receipt - Kikuzawa Restaurant", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
            {
            PreviewReceipt();
            printReceipt();
            }
            this.Close();
        }

        //Generate Receipt Preview
        public void PreviewReceipt()
        {
            frmReceiptPreview rcs = new frmReceiptPreview();
            frmSettlement setl = new frmSettlement();

            //get sales id

            rcs.textBox1.AppendText("\t\t" + "Kikuzawa Restaurant" + Environment.NewLine);
            rcs.textBox1.AppendText("\t\t=================================================" + Environment.NewLine);

            rcs.textBox1.AppendText("Receipt No #: " + lblGetReceipt.Text + "\t\t\tDate: " + daty + Environment.NewLine);
            rcs.textBox1.AppendText("Table No #:" + lblTableNo.Text + "\t\t\tTime : " + timy + Environment.NewLine);
            rcs.textBox1.AppendText("Server #: " + "\t" + lblwaiterName.Text + Environment.NewLine);
            rcs.textBox1.AppendText("Guest #: " + "\t" + lblgetGuestName.Text + Environment.NewLine);

            rcs.textBox1.AppendText("=================================================" + Environment.NewLine);
            rcs.textBox1.AppendText(Environment.NewLine + "Item Name" + "\t\tQty" + "\t\tPrice" + Environment.NewLine);
            rcs.textBox1.AppendText("=================================================" + Environment.NewLine);


            //the below section will loop the items from the order sheet

            if (listView1.Items.Count > 0)
            {


                int i, j;
                //let make j the total count of items on listview
                j = listView1.Items.Count;

                for (i = 0; i <= j - 1; i++)
                {

                    string strTotalQty, proPrice, proName;
                    proName = listView1.Items[i].SubItems[2].Text;
                    strTotalQty = Convert.ToInt32(listView1.Items[i].SubItems[1].Text).ToString();
                    proPrice = Convert.ToInt32(listView1.Items[i].SubItems[3].Text).ToString();
                    getEmpID = selectClass.getEmployeeByID(lblwaiterName.Text);

                    //to align perfect when previewed
                    //check and cut short the character length
                    //character is  > 13 cut it short to 13
                    if (proName.Length >= 13)
                    {
                        rcs.textBox1.AppendText(proName.Substring(0, 13) + "\t\t" + strTotalQty + "\t\t" + proPrice + Environment.NewLine);

                    }

                        //character is less than or equal 7
                    else if ((proName.Length >=7) &&  (proName.Length < 13))
                    {
                        rcs.textBox1.AppendText(proName + "\t\t" + strTotalQty + "\t\t" + proPrice + Environment.NewLine);

                    }

                        // is greater than 7
                    else if (proName.Length <7)
                    {
                        rcs.textBox1.AppendText(proName + "\t\t\t\t" + strTotalQty + "\t\t" + proPrice + Environment.NewLine);

                    }


                }
                rcs.textBox1.AppendText("=================================================" + Environment.NewLine);

                rcs.textBox1.AppendText(Environment.NewLine);
                rcs.textBox1.AppendText("\t\t\tSub Total............" + lblSubTotal.Text + Environment.NewLine);
                rcs.textBox1.AppendText("\t\t\tTax....................." + (double.Parse(lblTaxAmt.Text) + double.Parse(lblVat.Text)) + Environment.NewLine);
                rcs.textBox1.AppendText("\t\t\tPayable..............." + lblTotalAmt.Text + Environment.NewLine);
                rcs.textBox1.AppendText("=================================================" + Environment.NewLine);

                rcs.textBox1.AppendText("Description" + "\t\tTaxable" + "\t\tTax" + Environment.NewLine);

                //set subtotal and VAT
                rcs.textBox1.AppendText("VAT" + "\t\t\t" + lblSubTotal.Text + "\t\t" + lblTaxAmt.Text + Environment.NewLine);

                //set subtotal and TAX
                rcs.textBox1.AppendText("Tourism Levy" + "\t\t" + lblSubTotal.Text + "\t\t" + lblVat.Text + Environment.NewLine);

                rcs.textBox1.AppendText(Environment.NewLine + "---------------------------------------------------------------------------------------------------" + Environment.NewLine);


                
                rcs.textBox1.AppendText(Environment.NewLine + "Transaction: " + "PAID" + Environment.NewLine);
                rcs.textBox1.AppendText(Environment.NewLine + "---------------------------------------------------------------------------------------------------" + Environment.NewLine);

                rcs.textBox1.AppendText("Thank you for your visit, Please do visit us again");
                rcs.ShowDialog();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTotalAmt_TextChanged(object sender, EventArgs e)
        {
            for (int col = 0; col <= listView1.Items.Count - 1; col++)
            {

                selectClass.calcTaxAmt(decimal.Parse(taxPercsent), decimal.Parse(vatPercsent), decimal.Parse("0.00"), decimal.Parse(lblTotalAmt.Text));
                lblTaxAmt.Text = selectClass.tax1_Amt.ToString();
                lblVat.Text = selectClass.tax2_Amt.ToString();
                lblSubTotal.Text = selectClass.netPrice.ToString();
                lblTotalAmt.Text = subtotal().ToString();

            }
        }

        private void printReceipt()
        {

            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDialog.Document = printDoc;
            printDoc.PrintPage += printDoc_PrintPage;
            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {

                printDoc.Print();
            }
        }

        void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int i, j;

            //let make j the total count of items on listview
            j =  listView1.Items.Count;
            Graphics grafic = e.Graphics;
            Font font = new Font("Courier New", 11);
            float fontHeight = font.GetHeight();
            int StartX = 10;
            int StartY = 10;
            int offSet = 40;

            grafic.DrawString("\tKikuzawa RESTAURANT", new Font("Courier New", 14,FontStyle.Regular), new SolidBrush(Color.Black), StartX, StartY);
            grafic.DrawString(" ", new Font("Courier New", 8), new SolidBrush(Color.Black), StartX, StartY + 5);

            grafic.DrawString("======================================================", new Font("Courier New", 8), new SolidBrush(Color.Black), StartX, StartY + 20);

            grafic.DrawString("Receipt# ", new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + 40);
            grafic.DrawString("\t\t" + lblGetReceipt.Text.PadRight(30), new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + 40);

            grafic.DrawString("\t\t\tDate: " + thisDate, new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + 40);


            grafic.DrawString("Table #: ", new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
            grafic.DrawString("\t\t" + lblTableNo.Text.PadRight(30), new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
            grafic.DrawString("\t\t\tTime: " + thisTime, new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));

            grafic.DrawString("Server #: ", new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));
            grafic.DrawString("\t\t" + lblwaiterName.Text, new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));

            grafic.DrawString("Guest ", new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));
            grafic.DrawString("\t\t" + lblgetGuestName.Text, new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));


            string Liners = "=======================================================";
            grafic.DrawString(Liners, new Font("Courier New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));


            grafic.DrawString("Item Name ", new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));
            grafic.DrawString("\t\t\tQty", new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));

            grafic.DrawString("\t\t\t\t\tAmount ", new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));


            grafic.DrawString("=======================================================", new Font("Courier New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 120));


            for (i = 0; i <= j - 1; i++)
            {

                string strTotalQty, proPrice, proName;
                proName = listView1.Items[i].SubItems[2].Text;
                strTotalQty = Convert.ToInt32(listView1.Items[i].SubItems[1].Text).ToString();
                proPrice = Convert.ToInt32(listView1.Items[i].SubItems[3].Text).ToString();

                string productLine = proName + "\t\t\t" + strTotalQty + "\t" + proPrice;

                grafic.DrawString(productLine, font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 140));

                offSet += (int)fontHeight + 5;

            }

            string LineDraw = "========================================================";
            grafic.DrawString(LineDraw, new Font("Courier New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 150));


            grafic.DrawString("\t\tSub Total........." + lblSubTotal.Text + Environment.NewLine, font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 160));
            grafic.DrawString("\t\tTax..............." + (double.Parse(lblTaxAmt.Text) + double.Parse(lblVat.Text)), font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 180));
            grafic.DrawString("\t\tPayable..........." + lblTotalAmt.Text + Environment.NewLine, font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 200));
            grafic.DrawString("========================================", font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 210));
            grafic.DrawString("Description" + "\t\tTaxable" + "\tTax", font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 230));
            grafic.DrawString("VAT" + "\t\t\t" + lblSubTotal.Text + "\t\t" + lblTaxAmt.Text, font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 250));
            grafic.DrawString("Tourism Levy" + "\t\t" + lblSubTotal.Text + "\t\t" + lblVat.Text , font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 280));
            grafic.DrawString("----------------------------------------", font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 290));
            grafic.DrawString("Transaction: " + "PAID", font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 310));
            grafic.DrawString("----------------------------------------", font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 330));
            grafic.DrawString("Thank you for your visit.Please do visit us again ", new Font("Courier New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 350));

        }


        private void printBill()
        {

            PrintDialog printDialog = new PrintDialog();
            PrintDocument printBillDoc = new PrintDocument();
            printDialog.Document = printBillDoc;
            printBillDoc.PrintPage += printBillDoc_PrintPage;
            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {

                printBillDoc.Print();
            }
        }
        void printBillDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int i, j;

            //let make j the total count of items on listview
            j = listView1.Items.Count;
            Graphics grafic = e.Graphics;
            Font font = new Font("Courier New", 11);
            float fontHeight = font.GetHeight();
            int StartX = 10;
            int StartY = 10;
            int offSet = 40;

            grafic.DrawString("\tKikuzawa RESTAURANT", new Font("Courier New", 14, FontStyle.Regular), new SolidBrush(Color.Black), StartX, StartY);
            grafic.DrawString(" ", new Font("Courier New", 8), new SolidBrush(Color.Black), StartX, StartY + 5);

            grafic.DrawString("======================================================", new Font("Courier New", 8), new SolidBrush(Color.Black), StartX, StartY + 20);

            grafic.DrawString("Receipt# ", new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + 40);
            grafic.DrawString("\t\t" + lblGetReceipt.Text.PadRight(30), new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + 40);

            grafic.DrawString("\t\t\tDate: " + thisDate, new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + 40);


            grafic.DrawString("Table #: ", new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
            grafic.DrawString("\t\t" + lblTableNo.Text.PadRight(30), new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
            grafic.DrawString("\t\t\tTime: " + thisTime, new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));

            grafic.DrawString("Server #: ", new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));
            grafic.DrawString("\t\t" + lblwaiterName.Text, new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));

            grafic.DrawString("Guest ", new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));
            grafic.DrawString("\t\t" + lblgetGuestName.Text, new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));


            string Liners = "=======================================================";
            grafic.DrawString(Liners, new Font("Courier New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));


            grafic.DrawString("Item Name ", new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));
            grafic.DrawString("\t\t\tQty", new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));

            grafic.DrawString("\t\t\t\t\tAmount ", new Font("Courier New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));


            grafic.DrawString("=======================================================", new Font("Courier New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 120));


            for (i = 0; i <= j - 1; i++)
            {

                string strTotalQty, proPrice, proName;
                proName = listView1.Items[i].SubItems[2].Text;
                strTotalQty = Convert.ToInt32(listView1.Items[i].SubItems[1].Text).ToString();
                proPrice = Convert.ToInt32(listView1.Items[i].SubItems[3].Text).ToString();

               

               string productLine = proName + "\t\t\t" + strTotalQty + "\t" + proPrice;

                grafic.DrawString(productLine, font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 140));
                offSet += (int)fontHeight + 5;
              

            }

            string LineDraw = "========================================================";
            grafic.DrawString(LineDraw, new Font("Courier New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 150));


            grafic.DrawString("\t\tSub Total........." + lblSubTotal.Text + Environment.NewLine, font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 160));
            grafic.DrawString("\t\tTax..............." + (double.Parse(lblTaxAmt.Text) + double.Parse(lblVat.Text)), font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 180));
            grafic.DrawString("\t\tPayable..........." + lblTotalAmt.Text + Environment.NewLine, font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 200));
            grafic.DrawString("========================================", font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 210));
            grafic.DrawString("Description" + "\t\tTaxable" + "\tTax", font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 230));
            grafic.DrawString("VAT" + "\t\t\t" + lblSubTotal.Text + "\t\t" + lblTaxAmt.Text, font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 250));
            grafic.DrawString("Tourism Levy" + "\t\t" + lblSubTotal.Text + "\t\t" + lblVat.Text, font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 280));
            grafic.DrawString("----------------------------------------", font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 290));
            grafic.DrawString("Bill", font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 310));
            grafic.DrawString("----------------------------------------", font, new SolidBrush(Color.Black), StartX, StartY + (offSet + 330));
            grafic.DrawString("Thank you for your visit.Please do visit us again ", new Font("Courier New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 350));

        }
    }
}
