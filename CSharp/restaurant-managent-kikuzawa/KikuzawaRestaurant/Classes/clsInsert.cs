using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace KikuzawaRestaurant.Classes
{
    class clsInsert
    {
        
        public string dbPath = @"Data Source=MSI\MSSQLSERVER02;Initial Catalog=KikuzawaDB;Integrated Security=True;"; //MSI\MSSQLSERVER01
        public SqlConnection con;
        public SqlCommand cmd;
        public static ErrorProvider err = new ErrorProvider();

        //ADD NEW EMPLOYEE
        public void addEmployee(string empID, string fname, string lname, string oname, ComboBox gender, DateTimePicker dob, string phone, string resAddress, string emailAdd, string ref_fname, string ref_lname, string ref_phone, PictureBox photo)
        {
            try
            {
                string sql = "INSERT INTO tblEmployee(empID,fname,lname,oname,gender,dob,phone,resAddress,emailAdd,ref_fname,ref_lname,ref_phone,photo)VALUES(@empID,@fname,@lname,@oname,@gender,@dob,@phone,@resAddress,@emailAdd,@ref_fname,@ref_lname,@ref_phone,@photo)";
                con = new SqlConnection(dbPath);
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@empID", empID.Trim());
                cmd.Parameters.AddWithValue("@fname", fname.Trim());
                cmd.Parameters.AddWithValue("@lname", lname.Trim());
                cmd.Parameters.AddWithValue("@oname", oname.Trim());
                cmd.Parameters.AddWithValue("@gender", gender.SelectedItem);
                cmd.Parameters.AddWithValue("@dob", dob.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@phone", phone.Trim());
                cmd.Parameters.AddWithValue("@resAddress", resAddress.Trim());
                cmd.Parameters.AddWithValue("@emailAdd", emailAdd.Trim());
                cmd.Parameters.AddWithValue("@ref_fname", ref_fname.Trim());
                cmd.Parameters.AddWithValue("@ref_lname", ref_lname.Trim());
                cmd.Parameters.AddWithValue("@ref_phone", ref_phone.Trim());




                MemoryStream pp = new MemoryStream();
                photo.Image.Save(pp, photo.Image.RawFormat);
                Byte[] pdata = pp.GetBuffer();
                SqlParameter ppic = new SqlParameter("@photo", System.Data.SqlDbType.Image);
                ppic.Value = pdata;

                cmd.Parameters.Add(ppic);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Employee successfully added", "SAVED - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                con.Close();
            }

        }

        //ADD NEW USER
        public void AddUsers(string empID, string Uname, string Pass, ComboBox privileges)
        {

            try
            {
                string sql = "INSERT INTO Users(empID,Uname, Pass,privileges)VALUES(@empID,@Uname, @Pass,@privileges)";
                con = new SqlConnection(dbPath);
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@empID", empID.Trim());
                cmd.Parameters.AddWithValue("@Uname", Uname.Trim());
                cmd.Parameters.AddWithValue("@Pass", Pass.Trim());
                cmd.Parameters.AddWithValue("@privileges", privileges.SelectedItem);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Account Successfully Created", "SAVED - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                con.Close();
            }

        }

        //SEND BACK THE RAW NUMBER USED FOR EMPLOYEE ID
        public void insertTocallGenEmpID(int Num)
        {
            try
            {
                string sql = "INSERT INTO GenEmpID(nums)VALUES(@nums)";
                con = new SqlConnection(dbPath);
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nums", Num);
                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                con.Close();
            }


        }


        //ADDING CATEGORY OF PRODUCT
        public void insertToProType(ComboBox ProdCategory, string productType)
        {
            try
            {
                string sql = "INSERT INTO tblProType( prodTypeName,proSubCate)VALUES(@prodTypeName,@proSubCate)";
                con = new SqlConnection(dbPath);
                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@prodTypeName", ProdCategory.SelectedItem);
                cmd.Parameters.AddWithValue("@proSubCate", productType.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Category Successfully Added", "SAVED - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                con.Close();
            }



        }

        //need to add more things
        //ADD CURRENCY
        public void insertToCurrency(string curName, char curSymbol)
        {
            try
            {

                string sql = "INSERT INTO tblCurrency(CurName,curSymbol)VALUES(@CurName,@curSymbol)";
                con = new SqlConnection(dbPath);
                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@CurName", curName.Trim());
                cmd.Parameters.AddWithValue("@curSymbol", curSymbol);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Currency Successfully Added", "SAVED - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                con.Close();
            }


        }

        //ADDING PRODUCT
        public void insertToProduct(string proName, ComboBox prodTypeName, ComboBox proType, string proDescrip, double tax_1, double tax_2, double tax_3, double proPrice, double tax_1Amt, double tax_2Amt, double tax_3Amt, double proNetPrice, string qty = "1")
        {
            try
            {

                string sql = "INSERT INTO tblProducts(proName,prodTypeName,proType,proDescrip,tax_1,tax_2,tax_3,proPrice,tax_1Amt,tax_2Amt,tax_3Amt,proNetPrice,qty) VALUES(@proName,@prodTypeName,@proType,@proDescrip,@tax_1,@tax_2,@tax_3,@proPrice,@tax_1Amt,@tax_2Amt,@tax_3Amt,@proNetPrice,@qty)";
                con = new SqlConnection(dbPath);
                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@proName", proName.Trim());
                cmd.Parameters.AddWithValue("@prodTypeName", prodTypeName.SelectedItem);
                cmd.Parameters.AddWithValue("@proType", proType.SelectedItem);
                cmd.Parameters.AddWithValue("@proDescrip", proDescrip.Trim());
                cmd.Parameters.AddWithValue("@tax_1", tax_1);
                cmd.Parameters.AddWithValue("@tax_2", tax_2);
                cmd.Parameters.AddWithValue("@tax_3", tax_3);
                cmd.Parameters.AddWithValue("@proPrice", proPrice);
                cmd.Parameters.AddWithValue("@tax_1Amt", tax_1Amt);
                cmd.Parameters.AddWithValue("@tax_2Amt", tax_2Amt);
                cmd.Parameters.AddWithValue("@tax_3Amt", tax_3Amt);
                cmd.Parameters.AddWithValue("@proNetPrice", proNetPrice);
                cmd.Parameters.AddWithValue("@qty", qty);

                cmd.ExecuteNonQuery();
                MessageBox.Show("New Product Successfully Added", "SAVED - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                con.Close();
            }



        }

        public void insertToDailySales(int TableNum, string ServiceType, int Qty, string ItemName, decimal Price, string empID, DateTimePicker OrderDate, DateTimePicker OrderTime, string Statues, string SaleID)
        {

            try
            {
                string sql = "INSERT INTO DailySales(TableNum,ServiceType,Qty,ItemName,ItemPrice,empID,OrderDate,OrderTime,Statues,KOT)VALUES(@TableNum,@ServiceType,@Qty,@ItemName,@ItemPrice,@empID,@OrderDate,@OrderTime,@Statues,@KOT)";
                con = new SqlConnection(dbPath);
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@TableNum", TableNum);
                cmd.Parameters.AddWithValue("@ServiceType", ServiceType.Trim());
                cmd.Parameters.AddWithValue("@Qty", Qty);
                cmd.Parameters.AddWithValue("@ItemName", ItemName.Trim());
                cmd.Parameters.AddWithValue("@ItemPrice", Price);

                cmd.Parameters.AddWithValue("@empID", empID.Trim());
                cmd.Parameters.AddWithValue("@OrderDate", OrderDate.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@OrderTime", OrderTime.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@Statues", Statues.Trim());
                cmd.Parameters.AddWithValue("@KOT", SaleID.Trim());

                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                con.Close();
            }


        }

        //insert back the id we took
        //into the KOT Generator table
        public void insertToKOTGenerator(string letter)
        {

            try
            {
                string sql = "INSERT INTO kotGenerator(done)VALUES(@done)";
                con = new SqlConnection(dbPath);
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@done", letter);
                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                con.Close();
            }
        }

        public void insertTogenNochargeIDs(string letter)
        {

            try
            {
                string sql = "INSERT INTO genNochargeIDs(done)VALUES(@done)";
                con = new SqlConnection(dbPath);
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@done", letter);
                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - KikuzawaRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                con.Close();
            }
        }





        public void insertTobillAndSettlement(string kot, string orderDecrip, string fname, string lname, DateTimePicker ordDate, DateTimePicker ordTime, double totalDue, double tax1_Amt, double tax2_Amt, double subTotal, string mode, string empID)
        {
            try
            {

                string sql = "INSERT INTO billAndSettlement(kot,orderDecrip,fname,lname,ordDate,ordTime,totalDue,tax1_Amt,tax2_Amt,subTotal,mode,empID) VALUES(@kot,@orderDecrip,@fname,@lname,@ordDate,@ordTime,@totalDue,@tax1_Amt,@tax2_Amt,@subTotal,@mode,@empID)";
                con = new SqlConnection(dbPath);
                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@kot", kot.Trim());
                cmd.Parameters.AddWithValue("@orderDecrip", orderDecrip.Trim());
                cmd.Parameters.AddWithValue("@fname", fname.Trim());
                cmd.Parameters.AddWithValue("@lname", lname.Trim());
                cmd.Parameters.AddWithValue("@ordDate", ordDate.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@ordTime", ordTime.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@totalDue", totalDue);
                cmd.Parameters.AddWithValue("@tax1_Amt", tax1_Amt);
                cmd.Parameters.AddWithValue("@tax2_Amt", tax2_Amt);
                cmd.Parameters.AddWithValue("@subTotal", subTotal);
                cmd.Parameters.AddWithValue("@mode", mode.Trim());
                cmd.Parameters.AddWithValue("@empID", empID.Trim());
                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - KikuzawaRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                con.Close();
            }

        }


        //insert to ElectronicCurrency
        public void insertToElectronicCurrency(string electronicCurrency)
        {

            try
            {
                string sql = "INSERT INTO ElectronicCurrency(name)VALUES(@name)";
                con = new SqlConnection(dbPath);
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", electronicCurrency.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Electronic Currency" + Environment.NewLine + "Successfully Added", "SAVED - KikuzawaRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - KikuzawaRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                con.Close();
            }
        }


        public void insertTodetailsSettlement(string KOT, DateTimePicker pDate, DateTimePicker pTime, string currencyInUsed, double bill, ComboBox custCurrencyChosen, double AmountPaid, double changeDue, string paymentType, string acctName, string acctNum, string electronicType, string empID)
        {

            try
            {


                con = new SqlConnection(dbPath);
                con.Open();
                string sql = "insert into detailsSettlement(KOT,paidDate,paidTime,currencyInUsed,bill,custCurrencyChosen,AmountPaid,changeDue,paymentType,acctName,acctNum,electronicType,empID) VALUES(@KOT,@paidDate,@paidTime,@currencyInUsed,@bill,@custCurrencyChosen,@AmountPaid,@changeDue,@paymentType,@acctName,@acctNum,@electronicType,@empID)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@KOT", KOT.Trim());
                cmd.Parameters.AddWithValue("@paidDate", pDate.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@paidTime", pTime.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@currencyInUsed", currencyInUsed.Trim());
                cmd.Parameters.AddWithValue("@bill", bill);
                cmd.Parameters.AddWithValue("@custCurrencyChosen", custCurrencyChosen.SelectedItem);
                cmd.Parameters.AddWithValue("@AmountPaid", AmountPaid);
                cmd.Parameters.AddWithValue("@changeDue", changeDue);
                cmd.Parameters.AddWithValue("@paymentType", paymentType.Trim());
                cmd.Parameters.AddWithValue("@acctName", acctName.Trim());
                cmd.Parameters.AddWithValue("@acctNum", acctNum.Trim());
                cmd.Parameters.AddWithValue("@electronicType", electronicType.Trim());
                cmd.Parameters.AddWithValue("@empID", empID.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Payment successfully taken", "SAVED - KikuzawaRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Throwing Exceptionx - KikuzawaRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        public void insertTotblOrderInfo(string orderType, string tableNo, string KOT, DateTimePicker ordDate, DateTimePicker ordTime, string fname, string lname, string adultNo, string childrenNo, string empID)
        {

            try
            {

                string sql = "INSERT INTO tblOrderInfo(orderType,tableNo,KOT,ordDate,ordTime,fname,lname,adultNo,childrenNo,empID)VALUES(@orderType,@tableNo,@KOT,@ordDate,@ordTime,@fname,@lname,@adultNo,@childrenNo,@empID)";


                con = new SqlConnection(dbPath);
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@orderType", orderType.Trim());
                cmd.Parameters.AddWithValue("@tableNo", tableNo.Trim());
                cmd.Parameters.AddWithValue("@KOT", KOT.Trim());
                cmd.Parameters.AddWithValue("@ordDate", ordDate.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@ordTime", ordTime.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@fname", fname.Trim());
                cmd.Parameters.AddWithValue("@lname", lname.Trim());
                cmd.Parameters.AddWithValue("@adultNo", adultNo.Trim());
                cmd.Parameters.AddWithValue("@childrenNo", childrenNo.Trim());
                cmd.Parameters.AddWithValue("@empID", empID.Trim());
                cmd.ExecuteNonQuery();
                // MessageBox.Show("ordInfos" + Environment.NewLine + "Successfully Added", "SAVED - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                con.Close();
            }




        }

        //log history
        public void insertToLogHistory(string empID, DateTimePicker logDate, DateTimePicker logTime, DateTimePicker endShiftDate, DateTimePicker endShiftTime, string statues = "Login")
        {

            try
            {

                string sql = "INSERT INTO LogHistory(empID,logDate,logTime,endShiftDate,endShiftTime,statues)VALUES(@empID,@logDate,@logTime,@endShiftDate,@endShiftTime,@statues)";
                con = new SqlConnection(dbPath);
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@empID", empID.Trim());
                cmd.Parameters.AddWithValue("@logDate", logDate.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@logTime", logTime.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@endShiftDate", endShiftDate.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@endShiftTime", endShiftTime.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@statues", statues.Trim());

                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                con.Close();
            }

        }



    }
}
