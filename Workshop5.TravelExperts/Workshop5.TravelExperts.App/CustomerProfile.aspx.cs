﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workshop5.TravelExperts.Data;
using Workshop5.TravelExperts.Domain;
/*
 * Author:Hayley Mead
 * 
 */
namespace Workshop5.TravelExperts.App {
    public partial class CustomerProfile : System.Web.UI.Page {
        ////private Customer oldcust; // might remove
        //public bool updatecust; // 
        //public Customer customer; // current customer
        //private Customer oldcust;
        //private Customer newcust;
        bool dataIsValid;
        protected void Page_Load(object sender, EventArgs e)
        {
            RequiredFieldValidator8.Enabled = false;
            RequiredFieldValidator4.Enabled = false;
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator5.Enabled = false;
            RequiredFieldValidator6.Enabled = false;
            RequiredFieldValidator7.Enabled = false;
            RequiredFieldValidator11.Enabled = false;
            RequiredFieldValidator3.Enabled = false;

            ////need to find customer information based on who is in the session and display it. 

            // Grab Customer session if user logged in
            if (Session["Customer"] != null)
            {
                Customer cust = (Customer)Session["Customer"];
                txtUsername.Text = cust.UserName.ToString();
                txtPassword.Text = cust.Password.ToString();
                txtFirstName.Text = cust.CustFirstName.ToString();
                txtLastName.Text = cust.CustLastName.ToString();
                txtAddress.Text = cust.CustAddress.ToString();
                txtCity.Text = cust.CustCity.ToString();
                DropDownList1.Text = cust.CustProv.ToString();
                txtPostal.Text = cust.CustPostal.ToString();
                txtCountry.Text = cust.CustCountry.ToString();
                txtHomePhone.Text = cust.CustHomePhone.ToString();
                txtBusPhone.Text = cust.CustBusPhone.ToString();
                txtEmail.Text = cust.CustEmail.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Session["Customer"];
            Customer oldCust = new Customer();

                Customer newCust = new Customer();
                newCust.CustFirstName = txtFirstName.Text;
                newCust.CustLastName = txtLastName.Text;
                newCust.CustAddress = txtAddress.Text;
                newCust.CustCity = txtCity.Text;
                newCust.CustProv = DropDownList1.SelectedValue.ToString();
                newCust.CustPostal = txtPostal.Text;
                newCust.CustCountry = txtCountry.Text;
                newCust.CustHomePhone = txtHomePhone.Text;
                newCust.CustBusPhone = txtBusPhone.Text;
                newCust.CustEmail = txtEmail.Text;
                newCust.UserName = txtUsername.Text;
                newCust.Password = txtPassword.Text;

                // Then you could pass the oldCust along with the newCust to your UpdateCustomer  DB method
                CustomerDB.UpdateCust(oldCust, newCust);
            
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true; //when we hit the edit btn the save btn becombes visable

            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtCity.ReadOnly = false;
            DropDownList1.Enabled = true;//province
            txtPostal.ReadOnly = false;
            txtCountry.ReadOnly = false;
            txtHomePhone.ReadOnly = false;
            txtBusPhone.ReadOnly = false;
            txtEmail.Enabled = true; 
            txtUsername.ReadOnly = false;
            txtPassword.ReadOnly = false;

            RequiredFieldValidator8.Enabled = true;
            RequiredFieldValidator4.Enabled = true;
            RequiredFieldValidator1.Enabled = true;
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator5.Enabled = true;
            RequiredFieldValidator6.Enabled = true;
            RequiredFieldValidator7.Enabled = true;
            RequiredFieldValidator11.Enabled = true;
            RequiredFieldValidator3.Enabled = true;
        }
    }
}