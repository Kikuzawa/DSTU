using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;
namespace KikuzawaRestaurant.Classes
{
    class clsUpdate : clsInsert
    {
        public void updateTaxes(double tax1, double tax2, double tax3, int taxID)
        {

            try
            {
                con = new System.Data.SqlClient.SqlConnection(dbPath);
                con.Open();
                string updateString = "update tblTax set tax_1=@tax_1, tax_2=@tax_2, tax_3=@tax_3 where taxID=@taxID";
                cmd = new System.Data.SqlClient.SqlCommand(updateString, con);

                cmd.Parameters.AddWithValue("@tax_1", tax1);
                cmd.Parameters.AddWithValue("@tax_2", tax2);
                cmd.Parameters.AddWithValue("@tax_3", tax3);
                cmd.Parameters.AddWithValue("@taxID", taxID);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Tax successfully updated", "Update - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        public void updateCurrency(string curName, char curSymbol,double convertAmt, int id)
        {

            try
            {
                con = new System.Data.SqlClient.SqlConnection(dbPath);
                con.Open();
                string updateString = "update tblCurrency set CurName=@CurName,curSymbol=@curSymbol,convertAmt=@convertAmt where curID=@curID";
                cmd = new System.Data.SqlClient.SqlCommand(updateString, con);
               
                cmd.Parameters.AddWithValue("@CurName", curName.Trim());
                cmd.Parameters.AddWithValue("@curSymbol", curSymbol);
                cmd.Parameters.AddWithValue("@convertAmt", convertAmt);
                cmd.Parameters.AddWithValue("@curID", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Currency successfully updated", "Update - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
        public void updateElectronicCurrency(string curName, int id)
        {
            try
            {

                string sql = "update ElectronicCurrency set name=@name where id=@id";
                con = new SqlConnection(dbPath);
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", curName.Trim());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Electronic Currency updated successfully", "SAVED - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
        public void updatePassword(string Uname, string pass)
        {

            try
            {
                con = new SqlConnection(dbPath);
                con.Open();
                string updateString = "update Users set Pass=@Pass where Uname=@Uname";

                cmd = new SqlCommand(updateString, con);
                cmd.Parameters.AddWithValue("@Uname", Uname.Trim());
                cmd.Parameters.AddWithValue("@Pass", pass.Trim());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Password successfully updated", "Update - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        public void updateEmployee(string empID, string fname, string lname, string oname, ComboBox gender, DateTimePicker dob, string phone, string resAddress, string emailAdd, string ref_fname, string ref_lname, string ref_phone, PictureBox photo)
        {
            try
            {
                string sql = "update tblEmployee set fname=@fname,lname=@lname,oname=@oname,gender=@gender,dob=@dob,phone=@phone,resAddress=@resAddress,emailAdd=@emailAdd,ref_fname=@ref_fname,ref_lname=@ref_lname,ref_phone=@ref_phone,photo=@photo where empID='" + empID.Trim() + "'";
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

                MessageBox.Show("Employee successfully updated", "SAVED - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        public void updateLogHistory(int id, string Name, DateTimePicker endDate, DateTimePicker endTime, string statues = "Logout")
        {

            try
            {
                con = new SqlConnection(dbPath);
                con.Open();
                string updateString = "update LogHistory set endShiftDate=@endShiftDate, endShiftTime=@endShiftTime, statues=@statues where id=@id and empID=@empID";

                cmd = new SqlCommand(updateString, con);
                cmd.Parameters.AddWithValue("@empID", Name.Trim());
                cmd.Parameters.AddWithValue("@id", id);//log id
                cmd.Parameters.AddWithValue("@endShiftDate", endDate.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@endShiftTime", endTime.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@statues", statues.Trim());

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

        public void updateBillAndSettlement(string KOT, string mode)
        {

            try
            {
                con = new SqlConnection(dbPath);
                con.Open();
                string updateString = "update billAndSettlement set mode=@mode where kot='" + KOT.Trim() + "'";

                cmd = new SqlCommand(updateString, con);
               
                cmd.Parameters.AddWithValue("@mode", mode.Trim());

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
           

        }
        public void UpdateProductsTable(string proName, ComboBox prodTypeName, ComboBox proType, string proDescrip, double tax_1, double tax_2, double tax_3, double proPrice, double tax_1Amt, double tax_2Amt, double tax_3Amt, double proNetPrice, int prodID)
        {
            try
            {

                string sql = "update tblProducts set proName=@proName,prodTypeName=@prodTypeName,proType=@proType,proDescrip=@proDescrip,tax_1=@tax_1,tax_2=@tax_2,tax_3=@tax_3,proPrice=@proPrice,tax_1Amt=@tax_1Amt,tax_2Amt=@tax_2Amt,tax_3Amt=@tax_3Amt,proNetPrice=@proNetPrice where prodID=@prodID";
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
                cmd.Parameters.AddWithValue("@prodID", prodID);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Product has been updated successfully ", "SAVED - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        public void UpdateProductsStatues(string reason, bool statues,int prodID)
        {
            try
            {

                string sql = "update tblProducts set Reason=@Reason,Statues=@Statues where prodID=@prodID";
                con = new SqlConnection(dbPath);
                con.Open();
                cmd = new SqlCommand(sql, con);


                cmd.Parameters.AddWithValue("@Reason", reason);
                cmd.Parameters.AddWithValue("@Statues", statues);
                cmd.Parameters.AddWithValue("@prodID", prodID);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Product statues has been set", "SAVED - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        public void BackUp()
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(dbPath, con);
                if (!Directory.Exists(@"C:\dbKikuzawaRestaurantFolder"))
                {
                    Directory.CreateDirectory(@"C:\dbKikuzawaRestaurantFolder");
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "BACKUP DATABASE kikuzawaDB TO DISK = 'C:\\dbKikuzawaRestaurantFolder\\kikuzawaDB.BAK'";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(@"database backup successfully to - " + Environment.NewLine + @"C:\dbKikuzawaRestaurantFolder\KikuzawaDB", "Backup Database - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "BACKUP DATABASE KikuzawaDB TO DISK = 'C:\\dbKikuzawaRestaurantFolder\\KikuzawaDB.BAK'";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(@"database backup successfully to - " + Environment.NewLine + @"C:\dbKikuzawaRestaurantFolder\KikuzawaDB", "Backup Database - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Please contact the developer", " Database Backup Error - Kikuzawa Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }




        }
    }
}
