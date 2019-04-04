﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workshop5.TravelExperts.Data;
using Workshop5.TravelExperts.Domain;

namespace Workshop5.TravelExperts.App {
    /*
    * Term 2 Threaded Project 
    * Author : Mahda Kazemian
    * Date : April 03,2019
    * Course Name : Threaded Project for OOSD
    * Module : PROJ-207-OOSD
    * Purpose :insert customer information and create a session to get customer id
    */
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //submit button to insert(register) new customer information
        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            string un = Convert.ToString(uxUsername.Text);
            if (CustomerDB.CheckUserName(un))
            {
                var cust = new Customer
                {
                    UserName = uxUsername.Text,
                    Password = uxPassword.Text,
                    CustFirstName = uxFirstName.Text,
                    CustLastName = uxLastName.Text,
                    CustAddress = uxAddress.Text,
                    CustCity = uxCity.Text,
                    CustProv = DropDownList1.Text,
                    CustPostal = uxPostal.Text,
                    CustCountry = uxCountry.Text,
                    CustHomePhone = uxHomePhone.Text,
                    CustBusPhone = uxBusPhone.Text,
                    CustEmail = uxEmail.Text
                    // AgentId = Convert.ToInt32(uxAgentId.Text)
                };

                int CustID = CustomerDB.AddCustomer(cust);
                // create a customer session 
                Session["Customer"] = CustID;
                Response.Redirect("~/CustomerOrders.aspx");
            }
            else
            {
                Session["Customer"] = null;
                Response.Write("UserName is already exist,please try another one.");
            }


        }//end of sumit button


    }//end of CustomerRegistration class
}//end of namespace