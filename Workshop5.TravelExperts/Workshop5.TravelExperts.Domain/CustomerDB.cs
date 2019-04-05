﻿using System;
using System.Collections.Generic;
using System.Data;
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
    * Purpose :CustomerDB class to insert customer information and login
    */
    public static class CustomerDB
    {
        //function to add new customer
        public static int AddCustomer(Customer cust)
        {
            int custID = 0;
            SqlConnection con = TravelExpertsDB.GetConnection();//create the connection

            //create a command string
            string insertStatement = "INSERT INTO Customers (CustFirstName, CustLastName, CustAddress, CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, CustBusPhone, CustEmail, UserName, Password )" + " VALUES (@CustFirstName, @CustLastName, @CustAddress, @CustCity, @CustProv, @CustPostal, @CustCountry, @CustHomePhone, @CustBusPhone, @CustEmail, @UserName, @Password)";

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
            cmd.Parameters.AddWithValue("@UserName", cust.UserName);
            cmd.Parameters.AddWithValue("@Password", cust.Password);

            try
            {
                con.Open();//open the connection
                cmd.ExecuteNonQuery();//execute command
                string selectQuery = "SELECT IDENT_CURRENT('Customers') FROM Customers";
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


        //function to check username to make sure it is uniqe
        public static bool CheckUserName(string username)
        {
            int verify;
            //create the connection
            SqlConnection con = TravelExpertsDB.GetConnection();

            //command string to check the customer username
            string check = "select count(*) from Customers where(Customers.UserName=@UserName)";

            SqlCommand cmd = new SqlCommand(check, con);
            cmd.Parameters.AddWithValue("@UserName", username);
            try
            {
                con.Open();
                //put the result of count in verify
                verify = Convert.ToInt32(cmd.ExecuteScalar());
                //if any customer exists with this username 
                if (verify > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }//end of checkUserName function


        //Login function for existing customer
        public static bool Login(string username, string password)
        {
            int verify;
            //create the connection
            SqlConnection con = TravelExpertsDB.GetConnection();

            //command string to check the customer username and password
            string login = "select count(*) from Customers where(Customers.UserName=@UserName AND Customers.Password=@Password)";

            SqlCommand cmd = new SqlCommand(login, con);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", password);

            try
            {
                con.Open();
                //put the result of count in verify
                verify = Convert.ToInt32(cmd.ExecuteScalar());
                //if any customer exists with those username and password
                if (verify > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            
        }//end of login function


        //function to find customerid through the username for login the existing customer
        public static Customer Find(string userName)
        {
            Customer cust = new Customer();
            SqlConnection con = TravelExpertsDB.GetConnection();
            string findStatement = "select * from Customers where (UserName=@UserName)";
            SqlCommand cmd = new SqlCommand(findStatement, con);

            cmd.Parameters.AddWithValue("@UserName", userName);

            try
            {
                con.Open();
                //read the row of customer information to get customer id
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (reader.Read()) {
                    cust.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                    cust.CustFirstName = reader["CustFirstName"].ToString();
                    cust.CustLastName = reader["CustLastName"].ToString();
                    cust.CustCity = reader["CustCity"].ToString();
                    cust.CustProv = reader["CustProv"].ToString();
                    cust.CustPostal = reader["CustPostal"].ToString();
                    cust.CustCountry = reader["CustCountry"].ToString();
                    cust.CustHomePhone = reader["CustHomePhone"].ToString();
                    cust.CustEmail = reader["CustEmail"].ToString();
                    cust.UserName = reader["UserName"].ToString();
                    cust.Password = reader["Password"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return cust;

        }//end of Find function



    }// end of CustomerDBclass
}//end of namespace
