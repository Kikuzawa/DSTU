using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;
namespace KikuzawaRestaurant.Classes
{
    class clsView : clsInsert
    {

        public void viewCurrency(DataGridView dgv)
        {
            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select curID as No, CurName as [Currency Name], curSymbol as [Currency Symbol], Statues as [Statues],convertAmt as [Rates] from tblCurrency order by curID ASC";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void viewElectronicCurrency(DataGridView dgv)
        {
            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select id as NO, name as [Currency Name] from ElectronicCurrency ORDER BY id";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void viewUsers(DataGridView dgv)
        {
            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select empID as No, Uname as Username, privileges as Privilege from Users";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void viewEmployee(DataGridView dgv)
        {

            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select empID as ID,fname as [First name], lname as [Last name], oname as [Other name], gender as [Gender],dob as [Date-Of-Birth], phone as [Phone], resAddress as [Residence Address], emailAdd as [Email], ref_fname as [Ref_First_name], ref_lname as [Ref_Last_name], ref_phone as [Ref_Phone] from tblEmployee";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void viewDetailedSettlement(DataGridView dgv)
        {

            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select KOT as ID,paidDate as [Date], paidTime as [Time], currencyInUsed as [Local Currency], bill as [Actual Amount],custCurrencyChosen as [Currency Chosen], AmountPaid as [Guest Paid], changeDue as [Change Dues], paymentType as [Payment Type], acctName as [Account Name], acctNum as [Account Number],electronicType as [POS Type],empID as [Employee ID] from detailsSettlement";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //get employee image by id
        public void selectImageFromEmployee(string id, PictureBox pics)
        {

            try
            {
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                SqlCommand cmd = new SqlCommand("select photo from tblEmployee where empID = '" + id.Trim() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    MemoryStream ms = new MemoryStream((byte[])reader["photo"]);
                    pics.Image = new Bitmap(ms);
                }
                else
                {
                    //next time set default image
                    pics.Image = null;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        //Using searcsh engine to pull employee data
        public void searcshEmployeeByFirstName(string fname, DataGridView dgv)
        {

            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select empID as ID,fname as [First name], lname as [Last name], oname as [Other name], gender as [Gender],dob as [Date-Of-Birth], phone as [Phone], resAddress as [Residence Address], emailAdd as [Email], ref_fname as [Ref_First_name], ref_lname as [Ref_Last_name], ref_phone as [Ref_Phone] from tblEmployee where fname like '%" + fname.Trim() + "%'";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

                MessageBox.Show("Record(s) " + dgv.RowCount.ToString() + " Found", "Search Result - Kikuzawa...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //selling 

        public void SelectMenuByID(string MenuItem, DataGridView dgv)
        {
            DataGridViewRow row = new DataGridViewRow();

            try
            {

                con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select qty, proName, proPrice from tblProducts where proName ='" + MenuItem.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //searcsh by menu type
        public void SelectMenuByTextDisplay(Button ButtonItemDisplay, DataGridView dgv)
        {
            DataGridViewRow row = new DataGridViewRow();

            try
            {

                con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select proName, proPrice from tblProducts where proType ='" + ButtonItemDisplay.Text.Trim() + "'";

                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);



                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;




            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //all items from product table
        public void viewMenuProduct(DataGridView dgv)
        {

            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select prodID as No, proName as [Menu Item],prodTypeName as [Menu Group],proType as [Sub Group], proDescrip as [Details],tax_1 as [VAT %],tax_2 as [Tourism Levy %],tax_3 as [tax_3 %],proPrice as [Gross Price], tax_1Amt as [VAT Amount], tax_2Amt as [Tourism Levy Amount], tax_3Amt as [Tax_3 Amount], proNetPrice as [Net Price],statues from tblProducts";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }












        }


        //select Product Types
        public void SelectProductType(DataGridView dgv)
        {
            DataGridViewRow row = new DataGridViewRow();

            try
            {
                con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select proTypeID as No, prodTypeName as [Menu Group],proSubCate as [Sub Group] from tblProType";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //all items from product table
        public void viewLogHistory(DataGridView dgv)
        {

            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select id as No,empID as [Log Name],logDate as [Date In], logTime as [Time In], endShiftDate as [Date Out], endShiftTime as [Time Out], statues as [Statues] from LogHistory";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //view order Info
        public void viewOrderInfo(DataGridView dgv)
        {

            try
            {

                con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select KOT as [Receipt No], orderType as [Order Type],tableNo as [Table No],ordDate as [Order Date],ordTime as [Order Time],fname + ' ' + lname as [Guest Name],adultNo as Adult,childrenNo as Children,empID as Servers from tblOrderInfo";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public void viewProductForModification(string prodName, DataGridView dgv)
        {
            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select proName as Description,proNetPrice as [Net Rate],Tax_1 as VAT, Tax_2 as [Tourism Levy], Tax_3, proPrice as [Rate] from tblProducts where proName='" + prodName.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //view order Info
        public void viewBillTransaction(DataGridView dgv, string kot)
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select kot,ordDate as Date, ordTime as Time, totalDue as [Amount] from billAndSettlement where kot='" + kot.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void viewFreezes(DataGridView dgv) {
            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select prodID as No, proName as [Menu Item],prodTypeName as [Menu Group],proType as [Sub Group], Reason from tblProducts where Statues ='True' ";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void viewNetSales(DataGridView dgv)
        {
            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select kot as KOT, orderDecrip as [Order Description],ordDate as [Date],subTotal as [Net Sale] from billAndSettlement where mode ='PAID' ";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void viewTaxSales(DataGridView dgv)
        {
            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select kot as KOT, orderDecrip as [Order Description],ordDate as [Date],tax1_Amt as [VAT],tax2_Amt as [Tourism Levy] from billAndSettlement where mode ='PAID' ";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
