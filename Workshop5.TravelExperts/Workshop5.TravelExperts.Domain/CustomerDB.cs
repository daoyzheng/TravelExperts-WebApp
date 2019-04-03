using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop5.TravelExperts.Data;

namespace Workshop5.TravelExperts.Domain
{
    /*
    * Term 2 Threaded Project 
    * Author : Mahda Kazemian
    * Date : April 03,2019
    * Course Name : Threaded Project for OOSD
    * Module : PROJ-207-OOSD
    * Purpose :CustomerDB class to insert customer information
    */
    public static class CustomerDB
    {
        //Add new customer
        public static int AddCustomer(Customer cust)
        {
            int custID = 0;
            SqlConnection con = TravelExpertsDB.GetConnection();//create the connection

            //create a command string
            string insertStatement = "INSERT INTO Customers (CustFirstName, CustLastName, CustAddress, CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, CustBusPhone, CustEmail, AgentId, UserName, Password )" + " VALUES (@CustFirstName, @CustLastName, @CustAddress, @CustCity, @CustProv, @CustPostal, @CustCountry, @CustHomePhone, @CustBusPhone, @CustEmail, @AgentId, @UserName, @Password)";

            //connect to database and execute the command
            SqlCommand cmd = new SqlCommand(insertStatement, con);

            //define the command objects values
            cmd.Parameters.AddWithValue("@CustFirstName", cust.CustFirstName);
            cmd.Parameters.AddWithValue("@CustLastName", cust.CustLastName);
            cmd.Parameters.AddWithValue("@CustAddress", cust.CustAddress);
            cmd.Parameters.AddWithValue("@CustCity", cust.CustCity);
            cmd.Parameters.AddWithValue("@CustProv", cust.CustProv);
            cmd.Parameters.AddWithValue("@CustPostal", cust.CustPostal);
            cmd.Parameters.AddWithValue("@CustCountry", cust.CustCountry);
            cmd.Parameters.AddWithValue("@CustHomePhone", cust.CustHomePhone);
            cmd.Parameters.AddWithValue("@CustBusPhone", cust.CustBusPhone);
            cmd.Parameters.AddWithValue("@CustEmail", cust.CustEmail);
            cmd.Parameters.AddWithValue("@AgentId", cust.AgentId);
            cmd.Parameters.AddWithValue("@UserName", cust.UserName);
            cmd.Parameters.AddWithValue("@Password", cust.Password);

            try
            {
                con.Open();//open the connection
                cmd.ExecuteNonQuery();//execute command
                string selectQuery = "SELECT IDENT_CURRENT('Customers') FROM Customers ";
                SqlCommand selectCommand = new SqlCommand(selectQuery, con);
                custID = Convert.ToInt32(selectCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();//close connection
            }

            return custID;

        }//end of AddCustomer class




    }// end of CustomerDBclass
}//end of namespace
