using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Data;


namespace KikuzawaRestaurant.Classes
{
    class clsSelect :clsInsert
    {
        SqlDataReader reader;
        public int getNum;
        public string fullName, getEmployeeID;
        public string phone;
        public string empIDs;
        public decimal tax1, tax2, tax3;
        public decimal tax1_Amt, tax2_Amt, tax3_Amt, netPrice;
        private int kotID;
        public string toolTipping, currName, curSymbol;
        public int noChargeID;

        //UPLOAD IMAGE
        public static void uploadImage(PictureBox pass)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Upload Employee Image...";
            ofd.InitialDirectory = @"C:\";
            ofd.Multiselect = false;
            //ofd.Filter = "Jpeg|*.jpeg; Png|*.png; Gif|*.gif";
            if (ofd.ShowDialog() != DialogResult.Cancel)
            {
                pass.Image = Image.FromFile(ofd.FileName);

            }


        }


        //get  raw Id
        public int callGenEmpID()
        {
            try
            {

                string sql = "select nums from GenEmpID where id = (select max(id) from GenEmpID)";

                con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    getNum = Int16.Parse(reader["nums"].ToString());
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return getNum + 1;

        }

        //get  raw Id
        public int genNochargeIDs()
        {
            try
            {

                string sql = "select genID from genNochargeIDs where genID = (select max(genID) from genNochargeIDs)";

                con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    noChargeID = Int16.Parse(reader["genID"].ToString());
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return noChargeID + 1;

        }


        //PULL ALL EMPLOYEES
        public void selectEmployee(ComboBox emp)
        {
            try
            {


                // string dbPath = @"DataSource=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "select fname + ' ' + lname + ' ' + oname as fullName from tblEmployee";

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    emp.Items.Add(reader["fullName"]);

                }
                emp.SelectedIndex = 0;
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        //PULL ALL EMPLOYEES
        public void selectUsers(ComboBox emp)
        {
            try
            {


              
                string sql = "select Uname from Users";

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    emp.Items.Add(reader["Uname"]);

                }
                emp.SelectedIndex = 0;
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Reason "+ex.Message);
            }



        }


        //PULL EMPLOYEE IMAGE
        public void getEmpPic(ComboBox emp, PictureBox pics)
        {

            try
            {
                // string dbPath = @"DataSource=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();


                SqlCommand cmd = new SqlCommand("select photo from tblEmployee where fname + ' ' + lname + ' ' + oname = '" + emp.SelectedItem + "'", con);

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
                    pics.Image = null; // Properties.Resourcses.index;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        public void getName_Phone(ComboBox comEmpcode)
        {
            try
            {
                // string dbPath = @"DataSource=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select fname + ' ' + lname + ' ' + oname as fullName,phone  from tblEmployee where fname + ' ' + lname + ' ' + oname = '" + comEmpcode.SelectedItem + "'";


                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    fullName = reader[0].ToString();
                    phone = reader[1].ToString();

                }
                else
                {
                    fullName = "";
                    phone = "";

                }

                reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }

        public string empID(string name, string phone)
        {

            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select empID from tblEmployee where fname + ' ' + lname + ' ' + oname = '" + name.Trim() + "'  and phone = '" + phone.Trim() + "'";


                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    empIDs = reader[0].ToString();

                }
                else
                {
                    empIDs = "";

                }

                reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return empIDs;

        }

        //read the maximum sale id 
        public int getKOTNum()
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select genKOT from kotGenerator where genKOT =(Select max(genKOT)  from kotGenerator)";


                con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    kotID = Int16.Parse(reader["genKOT"].ToString());
                }

                reader.Close();
                con.Close();
            }
            // on error do nothing
            catch (Exception ex)
            {

            }
            return kotID;

        }

        //Get the Id of employee when login
        public string getEmployeeByID(string name)
        {

            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select empID from Users where Uname = '" + name + "'";


                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    getEmployeeID = reader[0].ToString();

                }
                else
                {
                    getEmployeeID = "";

                }

                //reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return getEmployeeID;

        }

        public string CallingProductCategory(ComboBox getProductCategory)
        {

            try
            {
                // string dbPath = @"DataSource=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select proSubCate from tblProType";
                SqlCommand cmd = new SqlCommand(sql, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    getProductCategory.Items.Add(reader["proSubCate"]);

                }
                getProductCategory.SelectedIndex = 0;


                reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return empIDs;

        }

        //call taxes
        public void getTaxables()
        {

            try
            {
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select tax_1, tax_2, tax_3 from tblTax";


                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    tax1 = decimal.Parse(reader[0].ToString());
                    tax2 = decimal.Parse(reader[1].ToString());
                    tax3 = decimal.Parse(reader[2].ToString());
                }
                else
                {
                    tax1 = 0;
                    tax2 = 0;
                    tax3 = 0;

                }

                reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        public void calcTaxAmt(decimal tax1, decimal tax2, decimal tax3, decimal totalAmt)
        {
            try
            {
                tax1_Amt = (tax1 / 100) * totalAmt;
                tax2_Amt = (tax2 / 100) * totalAmt;
                tax3_Amt = (tax3 / 100) * totalAmt;
                netPrice = totalAmt - (tax1_Amt + tax2_Amt + tax3_Amt);


            }
            catch (Exception ex)
            {

            }
        }


        //filter type food
        public void comSelectFood(ComboBox food)
        {
            try
            {
               
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select proSubCate from tblProType where prodTypeName='Food'";
                SqlCommand cmd = new SqlCommand(sql, con);


                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    food.Items.Add(reader["proSubCate"].ToString());

                }
                food.SelectedIndex = 0;


                reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }

        //filter type drink
        public void comSelectBeverage(ComboBox drink)
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();//open connection

                string sql = "select proSubCate from tblProType where prodTypeName='Beverage'";
                SqlCommand cmd = new SqlCommand(sql, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    drink.Items.Add(reader["proSubCate"].ToString());

                }
                drink.SelectedIndex = 0;


                reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }

        public void selectProduct(DataGridView dgv)
        {

            try
            {
                
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select proName,proPrice from tblProducts";
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

        public string selectProductDesc(string dgv)
        {

            try
            {
               
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = " select proDescrip from tblProducts where proName='" + dgv.Trim() + "'";
                if (reader.Read())
                {

                    toolTipping = reader[0].ToString();
                }
                else
                {
                    toolTipping = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return toolTipping;
        }


        //SEArcsH FROM DISPLAY DATA MEMBERS
        //USING TEXT BOX AS USER TYPE INTO IT
        public void searcshProduct(string textEntered, DataGridView dgv)
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select proName,proPrice from tblProducts where proName like'%" + textEntered.Trim() + "%'";
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

            }

        }

        //get all currency
        public void SelectCurrency(int ID)
        {
            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select CurName, curSymbol from tblCurrency where curID='" + ID + "'";
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    currName = reader["CurName"].ToString();
                    curSymbol = reader["curSymbol"].ToString();
                }
                else
                {
                    currName = "";
                    curSymbol = "-";
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //select bills where uupaid
        public void selectBillAndSettlement(DataGridView dgv)
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select kot as [Reciept Token #], orderDecrip as[order type],fname + ' ' + lname as [Guest name], ordDate as Date, ordTime as Time, totalDue as [Amount] from billAndSettlement where mode ='UNPAID'";
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


        //view all billing
        public void selectAllBillAndSettlement(DataGridView dgv, DateTimePicker saleDate)
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select kot as [Reciept Token #], orderDecrip as[order type],fname + ' ' + lname as [Guest name], ordDate as Date, ordTime as Time, totalDue as [Amount] from billAndSettlement where ordDate='" + saleDate.Value.ToShortDateString() + "'";
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

        //view unsettled bill by sales person only
        public void selectBySalePersonBillAndSettlement(DataGridView dgv, string salesPerson,DateTimePicker saleDate )
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select kot as [Reciept Token #],orderDecrip as[order type],fname + ' ' +lname as [Guest name],ordDate as Date,ordTime as Time, totalDue as [Amount] from billAndSettlement  where empID='" + salesPerson.Trim() + "' and ordDate='" + saleDate.Value.ToShortDateString() + "'";
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

        //select bills where upaid
        public void selectBillAndSettlementByDate(DataGridView dgv, DateTimePicker dat)
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select kot as [Reciept Token #], orderDecrip as[order type],fname + ' ' + lname as [Guest name], ordDate as Date, ordTime as Time, totalDue as [Amount] from billAndSettlement where ordDate ='" + dat.Value.Date + "'";
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


        //view  billing by names or receipt
        public void selectSortBillAndSettlement(DataGridView dgv, string name, ComboBox selections)
        {
            if (selections.SelectedIndex.Equals(0))
            {
                try
                {

                    SqlConnection con = new SqlConnection(dbPath);
                    con.Open();
                    string sql = "select kot as [Reciept Token #], orderDecrip as[order type],fname + ' ' + lname as [Guest name], ordDate as Date, ordTime as Time, totalDue as [Amount] from billAndSettlement where fname like'%" + name.Trim() + "%'";
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

            else if (selections.SelectedIndex.Equals(1))
            {

                try
                {

                    SqlConnection con = new SqlConnection(dbPath);
                    con.Open();
                    string sql = "select kot as [Reciept Token #], orderDecrip as[order type],fname + ' ' + lname as [Guest name], ordDate as Date, ordTime as Time, totalDue as [Amount] from billAndSettlement where lname like'%" + name.Trim() + "%'";
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

            else if (selections.SelectedIndex.Equals(2))
            {

                try
                {

                    SqlConnection con = new SqlConnection(dbPath);
                    con.Open();
                    string sql = "select kot as [Reciept Token #], orderDecrip as[order type],fname + ' ' + lname as [Guest name], ordDate as Date, ordTime as Time, totalDue as [Amount] from billAndSettlement where kot ='" + name.Trim() + "'";
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

        }


        //view  bill by take Away
        public void selectByTakeAwayBillAndSettlement(DataGridView dgv, string ordescription)
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select kot as [Reciept Token #],orderDecrip as[order type],fname + ' ' + lname as [Guest name],ordDate as Date,ordTime as Time, totalDue as [Amount] from billAndSettlement  where Convert(Varchar,orderDecrip)='" + ordescription + "'";
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

        //view  bill by Dine In
        public void selectByDineInBillAndSettlement(DataGridView dgv, string ordescription)
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select kot as [Reciept Token #],orderDecrip as[order type],fname + ' ' + lname as [Guest name],ordDate as Date,ordTime as Time, totalDue as [Amount] from billAndSettlement  where Convert(Varchar,orderDecrip)='" + ordescription.Trim() + "'";
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

        //view  bill by No Charge
        public void selectByNoChargeBillAndSettlement(DataGridView dgv, string ordescription)
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select kot as [Reciept Token #],orderDecrip as[order type],fname + ' ' + lname as [Guest name],ordDate as Date,ordTime as Time, totalDue as [Amount] from billAndSettlement  where Convert(Varchar,orderDecrip)='" + ordescription.Trim() + "'";
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

        //select tax
        public void selectTAx(DataGridView dgv)
        {


            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select tax_1 as [VAT], Tax_2 as [Tourism Levy],tax_3 as [None] from tblTax";
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


        //get all currency
        public void addCurrencyToComboBox(ComboBox getCurrency)
        {
            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select curSymbol as allCurrency from tblCurrency";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                // SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    getCurrency.Items.Add(reader["allCurrency"]);

                }
                getCurrency.SelectedIndex = 0;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //get  currency
        public void selectCurrencyUsedToComboBox(ComboBox getCurrency)
        {
            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select  CurName + ' (' + curSymbol + ')' as symbolAndName from tblCurrency where Statues='Inused'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                // SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    getCurrency.Items.Add("Cash - " + reader["symbolAndName"]);
                    getCurrency.SelectedIndex = 0;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string selectCurrencyUsedToComboBox(string getCurrency)
        {
            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select curSymbol as symbolAndName from tblCurrency where Statues='Inused'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                // SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    getCurrency =  reader["symbolAndName"].ToString().TrimEnd();

                }
                else {
                    getCurrency = "";
                
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return getCurrency;
        }


        //get  currency
        public void selectInitialCurrencyUsedToComboBox(ComboBox getCurrency)
        {
            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select curSymbol as symbolAndName from tblCurrency where Statues='Inused'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                // SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    getCurrency.Text = reader["symbolAndName"].ToString();
                   
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        //get currency convertor
        public void selectCurrencyUsedFromLabel(Label currencyFrom, String convertState)
        {
            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select curSymbol from tblCurrency where Statues='" + convertState.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                // SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    currencyFrom.Text = reader["curSymbol"].ToString();

                }
                else
                {
                    currencyFrom.Text = "N/A";
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //get currency convertor
        public void selectCurrencyUsedToLabel(Label currencyTo, ComboBox convertState)
        {
            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select convertAmt from tblCurrency where curSymbol ='" + convertState.SelectedItem + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                // SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    currencyTo.Text = reader["convertAmt"].ToString();

                }
                else
                {
                    currencyTo.Text = "N/A";
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //get all electronic currency
        public void addElectronicCurrencyToComboBox(ComboBox getCurrency)
        {
            try
            {

                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select name as allCurrency from ElectronicCurrency";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                // SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    getCurrency.Items.Add(reader["allCurrency"]);

                }
                getCurrency.SelectedIndex = 0;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //RECALL Orders
        public void selectOrderDetailsUsingKOT(string KOT, ListView listView1)
        {
            try
            {
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select Qty,ItemName,ItemPrice from DailySales Where KOT ='" + KOT.Trim() + "'";
                listView1.View = View.Details;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //first item of call
                    ListViewItem Viewitems = new ListViewItem(reader["Qty"].ToString());
                    Viewitems.SubItems.Add(reader["Qty"].ToString());
                    Viewitems.SubItems.Add(reader["ItemName"].ToString());
                    Viewitems.SubItems.Add(reader["ItemPrice"].ToString());
                    listView1.Items.Add(Viewitems);

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }


        }

        //get  raw Id
        public int callMaxLogHistoryAndEmployee(string name, int getLogIDNumb)
        {
            try
            {

                string sql = "select id from LogHistory where id = (select max(id) from LogHistory) AND empID ='" + name + "'";

                con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    getLogIDNumb = Int16.Parse(reader["id"].ToString());
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return getLogIDNumb;

        }

        //searcsh for items from product table
        public void SearcshForMenuProduct(string itemSearcsh, DataGridView dgv)
        {
            try
            {
                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select prodID as No, proName as [Menu Item],prodTypeName as [Menu Group],proType as [Sub Group], proDescrip as [Details],tax_1 as [VAT %],tax_2 as [Tourism Levy %],tax_3 as [tax_3 %],proPrice as [Gross Price], tax_1Amt as [VAT Amount], tax_2Amt as [Tourism Levy Amount], tax_3Amt as [Tax_3 Amount], proNetPrice as [Net Price] from tblProducts where proName like '%" + itemSearcsh + "%'";

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


        //RECALL KOT, Description,Date and Time
        public string TableNum;
        public string orderDescript;
        public string OrderDate;
        public string OrderTime;
        public void selectOrderFieldsUsingKOT(string KOT)
        {
            try
            {
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select ServiceType,TableNum,OrderDate,OrderTime from DailySales Where KOT ='" + KOT.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                //GET THE DESCRIPTION OF THE ABOVE DETAILS
                if (reader.Read())
                {
                    orderDescript = reader["ServiceType"].ToString();
                    TableNum = reader["TableNum"].ToString();
                    OrderDate = reader["OrderDate"].ToString();
                    OrderTime = reader["OrderTime"].ToString();

                }
                else
                {
                    orderDescript = "";
                    TableNum = "";
                    OrderDate = "";
                    OrderTime = "";


                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }


        }


        //sales manipulation
        public string salesPerson;
        public string salpersonByID(string id)
        {

            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select Uname as [persons]  from Users where empID = '" + id.Trim() + "'";


                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    salesPerson = reader["persons"].ToString();

                }
                else
                {
                    salesPerson = "";

                }

                reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


            return salesPerson;

        }

        string getPersonByKOT;
        public string getSalePersonID(string KOT)
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select empID from DailySales where KOT = '" + KOT.Trim() + "'";


                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    getPersonByKOT = reader["empID"].ToString();

                }
                else
                {
                    getPersonByKOT = "";

                }

                reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return getPersonByKOT;



        }


        public string AdultNum, ChildrenNum;
        public void selectAdultAndChildren(string KOT)
        {

            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select adultNo,childrenNo from tblOrderInfo where KOT = '" + KOT.Trim() + "'";


                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    AdultNum = reader["adultNo"].ToString();
                    ChildrenNum = reader["childrenNo"].ToString();
                }
                else
                {
                    AdultNum = "";
                    ChildrenNum = "";

                }

                reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }


        public string tymer,logDates,shifts;
        

        public void selectShiftNumberAndTimeFromLoginHistory(string usernames) {

            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
               
                string sql = "select id, logDate,logTime from LogHistory where id =(select max(id) from LogHistory) and empID ='" + usernames.Trim() + "'";


                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    shifts = reader["id"].ToString();
                    tymer = reader["logTime"].ToString();
                    logDates = reader["logDate"].ToString();
                }
                else
                {
                    shifts = "";
                     tymer = "";
                     logDates = "";

                }

                reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        
        }

        //GET ALL MONETARY TRANSACTION

       public double cashValue,POSvalue;
        public void sumAllCash( string users,DateTime inDate, DateTime outDate) {

            cashValue = 0;
            try
            {

                string sql = "select bill from detailsSettlement where empID ='" + users + "'and paymentType ='Cash' and paidDate in('" + inDate.Date + "','" + outDate.Date + "')";

                con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cashValue += double.Parse(reader["bill"].ToString()); 
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        
        }

        public void sumAllPOS(string users, DateTime inDate, DateTime outDate)
        {

            POSvalue = 0;
            try
            {

                string sql = "select bill from detailsSettlement where empID ='" + users + "'and paymentType ='POS' and paidDate in('" + inDate.Date + "','" + outDate.Date + "')";

                con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSvalue += double.Parse(reader["bill"].ToString());
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

    }
}
